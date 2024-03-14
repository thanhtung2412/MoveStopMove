using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldShop : ItemShop
{
    private ShieldsType[] shieldsTypes;
    private void Awake()
    {
        shieldsTypes = ShopManager.Instance.shields;
    }
    public void UpdateShieldUI()
    {
        UIManager.Instance.ClearChild(gridRoot);
        
        for (int i = 0; i < shieldsTypes.Length; i++)
        {
            int idx = i;
            ShieldsType items = shieldsTypes[i];
            if (items != null)
            {
                ItemsPrefabs itemPrefabs = Instantiate(itemsPrefab, Vector3.zero, Quaternion.identity, gridRoot.transform);
                itemPrefabs.itemsImage.sprite = items.spriteShield;

                if (itemPrefabs.btn != null)
                {
                    itemPrefabs.btn.onClick.RemoveAllListeners();
                    itemPrefabs.btn.onClick.AddListener(() => PressItem(items, idx));
                }
            }
        }
    }

    private void PressItem(ShieldsType items, int idx)
    {
        bool isUnlocked = Pref.GetBool(PrefConst.HAT_ + idx);
        if (isUnlocked)
        {
            
            Pref.CurShield = idx;
            UpdateShieldUI();
            UIManager.Instance.player.ChangeShield();
            priceItemBtn.gameObject.SetActive(false);
            selectItemBtn.gameObject.SetActive(true);
        }
        else
        {
            priceItemBtn.gameObject.SetActive(true);
            selectItemBtn.gameObject.SetActive(false);
            priceItemTxt.text = items.priceShield.ToString();
            if (priceItemBtn != null)
            {
                priceItemBtn.onClick.RemoveAllListeners();
                priceItemBtn.onClick.AddListener(() => PressPriceBtn(items, idx));
            }

        }
    }

    private void PressPriceBtn(ShieldsType items, int idx)
    {
        if (Pref.Coins >= items.priceShield)
        {
            Pref.Coins -= items.priceShield;
            priceItemBtn.gameObject.SetActive(false);
            selectItemBtn.gameObject.SetActive(true);
            Pref.SetBool(PrefConst.SHIELD_ + idx);
            UIManager.Instance.Coin();
            UpdateShieldUI();
            Pref.CurShield = idx;
            UIManager.Instance.player.ChangeShield();
        }
        else
        {
            Debug.Log("you dont have enought mmoney");
        }
    }
    public void ShieldBtn()
    {
        Pref.EquipsType = 3;
        UpdateShieldUI();       
        UIManager.Instance.player.ChangeShield();
    }
}

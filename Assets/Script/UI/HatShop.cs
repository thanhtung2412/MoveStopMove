using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatShop : ItemShop
{
    private HatsType[] hatsTypes;
    private void Awake()
    {
        hatsTypes = ShopManager.Instance.hats;
    }
    public void UpdateHatUI()
    {
        UIManager.Instance.ClearChild(gridRoot);        
        for (int i = 0; i < hatsTypes.Length; i++)
        {
            int idx = i;
            HatsType items = hatsTypes[i];
            if (items != null)
            {
                ItemsPrefabs itemPrefabs = Instantiate(itemsPrefab, Vector3.zero, Quaternion.identity, gridRoot.transform);
                itemPrefabs.itemsImage.sprite = items.spriteHat;

                if (itemPrefabs.btn != null)
                {
                    itemPrefabs.btn.onClick.RemoveAllListeners();
                    itemPrefabs.btn.onClick.AddListener(() => PressItem(items, idx));
                }
            }
        }
    }
    public void PressItem(HatsType item, int idx)
    {        
        bool isUnlocked = Pref.GetBool(PrefConst.HAT_ + idx);
        if (isUnlocked)
        {          
            Pref.CurHat = idx;
            UpdateHatUI();  
            UIManager.Instance.player.ChangeHat();
            priceItemBtn.gameObject.SetActive(false);
            selectItemBtn.gameObject.SetActive(true);
        }
        else
        {         
            priceItemBtn.gameObject.SetActive(true);
            selectItemBtn.gameObject.SetActive(false);
            priceItemTxt.text = item.priceHat.ToString();
            if (priceItemBtn != null)
            {
                priceItemBtn.onClick.RemoveAllListeners();
                priceItemBtn.onClick.AddListener(() => PressPriceBtn(item, idx));
            }

        }
    }
    public void PressPriceBtn(HatsType item, int idx)
    {       
        if (Pref.Coins >= item.priceHat)
        {
            Pref.Coins -= item.priceHat;
            priceItemBtn.gameObject.SetActive(false);
            selectItemBtn.gameObject.SetActive(true);
            Pref.SetBool(PrefConst.HAT_ + idx);
            UIManager.Instance.Coin();
            UpdateHatUI();
            Pref.CurHat = idx;
            UIManager.Instance.player.ChangeHat();
        }
        else
        {
            Debug.Log("you dont have enought mmoney");
        }
    }
    public void HatBtn()
    {
        Pref.EquipsType = 1;
        UpdateHatUI();
        PressItem(hatsTypes[0], 0);              
    }
}

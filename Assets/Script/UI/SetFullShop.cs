using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFullShop : ItemShop
{
    private SetFullType[] setFullType;
    private void Awake()
    {
        setFullType = ShopManager.Instance.setFull;
    }
    public void UpdateSetFullUI()
    {
        UIManager.Instance.ClearChild(gridRoot);
       
        for (int i = 0; i < setFullType.Length; i++)
        {
            int idx = i;
            SetFullType items = setFullType[i];
            if (items != null)
            {
                ItemsPrefabs itemPrefabs = Instantiate(itemsPrefab, Vector3.zero, Quaternion.identity, gridRoot.transform);
                itemPrefabs.itemsImage.sprite = items.spriteSetFull;

                if (itemPrefabs.btn != null)
                {
                    itemPrefabs.btn.onClick.RemoveAllListeners();
                    itemPrefabs.btn.onClick.AddListener(() => PressItem(items, idx));
                }
            }
        }
    }

    private void PressItem(SetFullType items, int idx)
    {
        bool isUnlocked = Pref.GetBool(PrefConst.HAT_ + idx);
        if (isUnlocked)
        {
           
            Pref.CurSetFull = idx;
            UpdateSetFullUI();
            UIManager.Instance.player.ChangeSetFull();
            priceItemBtn.gameObject.SetActive(false);
            selectItemBtn.gameObject.SetActive(true);
        }
        else
        {
            priceItemBtn.gameObject.SetActive(true);
            selectItemBtn.gameObject.SetActive(false);
            priceItemTxt.text = items.priceSetFull.ToString();
            if (priceItemBtn != null)
            {
                priceItemBtn.onClick.RemoveAllListeners();
                priceItemBtn.onClick.AddListener(() => PressPriceBtn(items, idx));
            }

        }
    }

    private void PressPriceBtn(SetFullType items, int idx)
    {
        if (Pref.Coins >= items.priceSetFull)
        {
            Pref.Coins -= items.priceSetFull;
            priceItemBtn.gameObject.SetActive(false);
            selectItemBtn.gameObject.SetActive(true);
            Pref.SetBool(PrefConst.SETFULL_ + idx);
            UIManager.Instance.Coin();
            UpdateSetFullUI();
            Pref.CurSetFull = idx;
            UIManager.Instance.player.ChangeSetFull();
        }
        else
        {
            Debug.Log("you dont have enought mmoney");
        }
    }
    public void SetFullBtn()
    {
        Pref.EquipsType = 4;
        UpdateSetFullUI();
        PressItem(setFullType[0], 0);
    }
}

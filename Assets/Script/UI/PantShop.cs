using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PantShop : ItemShop
{
    private PantsType[] pantsTypes;
    private void Awake()
    {
        pantsTypes = ShopManager.Instance.pants;
    }
    public void UpdatePantUI()
    {
        UIManager.Instance.ClearChild(gridRoot);
       
        for (int i = 0; i < pantsTypes.Length; i++)
        {
            int idx = i;
            PantsType items = pantsTypes[i];
            if (items != null)
            {
                ItemsPrefabs itemPrefabs = Instantiate(itemsPrefab, Vector3.zero, Quaternion.identity, gridRoot.transform);
                itemPrefabs.itemsImage.sprite = items.spritePant;

                if (itemPrefabs.btn != null)
                {
                    itemPrefabs.btn.onClick.RemoveAllListeners();
                    itemPrefabs.btn.onClick.AddListener(() => PressItem(items, idx));
                }
            }
        }
    }
    private void PressItem(PantsType items, int idx)
    {
        bool isUnlocked = Pref.GetBool(PrefConst.HAT_ + idx);
        if (isUnlocked)
        {
           
            Pref.CurPant = idx;
            UpdatePantUI();
            UIManager.Instance.player.ChangePant();
            priceItemBtn.gameObject.SetActive(false);
            selectItemBtn.gameObject.SetActive(true);
        }
        else
        {
            priceItemBtn.gameObject.SetActive(true);
            selectItemBtn.gameObject.SetActive(false);
            priceItemTxt.text = items.pricePant.ToString();
            if (priceItemBtn != null)
            {
                priceItemBtn.onClick.RemoveAllListeners();
                priceItemBtn.onClick.AddListener(() => PressPriceBtn(items, idx));
            }

        }
    }

    private void PressPriceBtn(PantsType items, int idx)
    {
        if (Pref.Coins >= items.pricePant)
        {
            Pref.Coins -= items.pricePant;
            priceItemBtn.gameObject.SetActive(false);
            selectItemBtn.gameObject.SetActive(true);
            Pref.SetBool(PrefConst.PANT_ + idx);
            UIManager.Instance.Coin();
            UpdatePantUI();
            Pref.CurPant = idx;
            UIManager.Instance.player.ChangePant();
        }
        else
        {
            Debug.Log("you dont have enought mmoney");
        }
    }
    public void PantBtn()
    {
        Pref.EquipsType = 2;
        UpdatePantUI();       
        UIManager.Instance.player.ChangePant();
    }
}

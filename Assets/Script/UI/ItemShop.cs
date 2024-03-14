using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemShop : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI priceItemTxt;   
    [SerializeField] protected Button priceItemBtn;
    [SerializeField] protected Button selectItemBtn;
    [SerializeField] private GameObject shopPanel;
    public ItemsPrefabs itemsPrefab;
    public GameObject gridRoot;   
   
    public void CloseItemShop()
    {
        gameObject.SetActive(false);
        shopPanel.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuDialog : MonoBehaviour
{   
    [SerializeField] private Character playerChar;
    [SerializeField] private GameObject weaponPanel;
    [SerializeField] private GameObject shopPanel; 
    [SerializeField] private GameObject itemShopPanel;
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private GameObject coinPanel;
   
    public void PlayGame()
    {      
        playerChar.isCanMove = true;
        LevelManager.Instance.OnPlayGame();
        LevelManager.Instance.isCanDespawn = true;
        inGamePanel.SetActive(true);
        coinPanel.SetActive(false);
        shopPanel.SetActive(false);      
    }
    public void OnPressWeapon()
    {
        shopPanel.SetActive(false);
        weaponPanel.SetActive(true);
    }
    public void OnPressItemShop()
    {
        shopPanel.SetActive(false);
        itemShopPanel.SetActive(true);          
    }   
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public TextMeshProUGUI coins;
    public Player player;
   
    public Canvas canvas;
    public GameObject boxIndicator;
    public Camera MainCamera;
    public GameObject coinPanel;
    public GameObject shopPanel;
    public GameObject inGamePanel;
    public GameObject deadPanel;
    public void Coin()
    {
        coins.text = "" + Pref.Coins;
    }
    public void ClearChild(GameObject gameObject)
    {
        if (gameObject == null || gameObject.transform.childCount == 0)
        {
            return;
        }
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
    }
}

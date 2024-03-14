using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private void Start()
    {
        if (!PlayerPrefs.HasKey(PrefConst.COINS_))
        {
            Pref.Coins = 1000;
        }
        UIManager.Instance.Coin();
    }
}

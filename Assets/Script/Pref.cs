using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Pref : MonoBehaviour
{
    public static int CurWeaponID
    {
        set => PlayerPrefs.SetInt(PrefConst.WEAPON_ID_, value);
        get => PlayerPrefs.GetInt(PrefConst.WEAPON_ID_);
    }
    public static int Coins
    {
        set => PlayerPrefs.SetInt(PrefConst.COINS_, value);
        get => PlayerPrefs.GetInt(PrefConst.COINS_);
    }
    public static int EquipsType
    {
        set => PlayerPrefs.SetInt(PrefConst.EQUIPSTYPE_, value);
        get => PlayerPrefs.GetInt(PrefConst.EQUIPSTYPE_);
    }
    public static int CurHat
    {
        set => PlayerPrefs.SetInt(PrefConst.HAT_,value);
        get => PlayerPrefs.GetInt(PrefConst.HAT_);
    }
    public static int CurPant
    {
        set => PlayerPrefs.SetInt(PrefConst.PANT_, value);
        get => PlayerPrefs.GetInt(PrefConst.PANT_);
    }
    public static int CurShield
    {
        set => PlayerPrefs.SetInt(PrefConst.SHIELD_, value);
        get => PlayerPrefs.GetInt(PrefConst.SHIELD_);
    }
    public static int CurSetFull
    {
        set => PlayerPrefs.SetInt(PrefConst.SETFULL_, value);
        get => PlayerPrefs.GetInt(PrefConst.SETFULL_);
    }
   

    public static void SetBool(string value)
    {
        if(value != null) 
        {
            PlayerPrefs.SetInt(value, 1);
        }
        else
        {
            PlayerPrefs.SetInt(value, 0);
        }
    }
    public static bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1 ? true : false;
    }
  
}

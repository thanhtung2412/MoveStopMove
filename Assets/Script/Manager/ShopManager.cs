using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : Singleton<ShopManager>
{
    public WeaponTypes[] weaponTypes;
    public HatsType[] hats;
    public PantsType[] pants;
    public ShieldsType[] shields;
    public SetFullType[] setFull;
}
[System.Serializable]
public class WeaponTypes
{
    public string name;
    public int price;    
    public bool isUnlocked;
}

[System.Serializable]
public class HatsType
{
    public int priceHat;
    public Sprite spriteHat;
}   
[System.Serializable]
public class PantsType
{
    public int pricePant;
    public Sprite spritePant;  
}
[System.Serializable]
public class ShieldsType
{
    public int priceShield;
    public Sprite spriteShield;   
}
[System.Serializable]
public class SetFullType
{
    public int priceSetFull;
    public Sprite spriteSetFull;   
}

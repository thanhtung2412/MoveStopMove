using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : GameUnit
{
    [SerializeField] protected Weapon[] weaponBulletPrefabs;
    [SerializeField] protected Transform boxContainBullet;
    public GameObject boxWeapon;
    public GameObject[] weaponCur;

    public Renderer skinModel;
    public Material[] matSkinOriginals;
   
    public GameObject boxHat;
    public GameObject[] hats;

    public Renderer boxPant;
    public Material[] matPants;

    public GameObject boxShield;
    public GameObject[] shields;

    public Material[] matSkinSetFull;
    public GameObject[] hatSetFull;
    public GameObject[] shieldSetFull;

    public GameObject boxWing;
    public GameObject[] wingSetFull;

    public void ChangeWeapon()
    {
        UIManager.Instance.ClearChild(boxWeapon);
        Instantiate(weaponCur[Pref.CurWeaponID], boxWeapon.transform);
    }
    public void ChangeHat()
    {
        UIManager.Instance.ClearChild(boxHat);
        Instantiate(hats[Pref.CurHat], boxHat.transform);
    }
    public void ChangePant()
    {
        boxPant.material = matPants[Pref.CurPant];
    }
    public void ChangeShield()
    {
        UIManager.Instance.ClearChild(boxShield);
        Instantiate(shields[Pref.CurShield], boxShield.transform);
    }
    public void ChangeSetFull()
    {
        UIManager.Instance.ClearChild(boxHat);
        Instantiate(hatSetFull[Pref.CurSetFull], boxHat.transform);

        skinModel.material = matSkinSetFull[Pref.CurSetFull];

        UIManager.Instance.ClearChild(boxShield);
        Instantiate(shieldSetFull[Pref.CurSetFull], boxShield.transform);

        UIManager.Instance.ClearChild(boxWing);
        Instantiate(wingSetFull[Pref.CurSetFull], boxWing.transform);
    }
}

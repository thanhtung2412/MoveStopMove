using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponShop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI PriceTxt;
    [SerializeField] private TextMeshProUGUI weaponNameTxt;
    [SerializeField] private GameObject priceWeaponBtn;
    [SerializeField] private GameObject selectWeaponBtn;
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private GameObject shopPanel;
    public int indexWeapon;
    private WeaponTypes[] weaponTypes;
    private void Awake()
    {
        weaponTypes = ShopManager.Instance.weaponTypes;
    }
    private void Start()
    {
        indexWeapon = Pref.CurWeaponID;      
        for(int i =0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
            weapons[indexWeapon].SetActive(true);
        }
        for(int i =0; i< weaponTypes.Length; i++)
        {
            weaponTypes[i].isUnlocked = Pref.GetBool(weaponTypes[i].name);
        }
        UpdateUI();
    }
    public void UpdateUI()
    {      
        UIManager.Instance.Coin();
        weaponNameTxt.text = weaponTypes[indexWeapon].name;
        if (weaponTypes[indexWeapon].isUnlocked == true)
        {
            priceWeaponBtn.SetActive(false);
            selectWeaponBtn.SetActive(true);
        }
        else
        {
            priceWeaponBtn.SetActive(true);
            selectWeaponBtn.SetActive(false);
            PriceTxt.text = weaponTypes[indexWeapon].price.ToString();
        }
    }
    public void ChangeNext()
    {
        weapons[indexWeapon].SetActive(false);
        indexWeapon++;      
        if(indexWeapon == weapons.Length) 
        { 
            indexWeapon = 0;
        }
        weapons[indexWeapon].SetActive(true);
        if (weaponTypes[indexWeapon].isUnlocked == true)
        {
            Pref.CurWeaponID = indexWeapon;
        }
        UpdateUI() ;
    }
    public void ChangeBack()
    {
        weapons[indexWeapon].SetActive(false);
        indexWeapon--;
        if(indexWeapon == -1)
        {
            indexWeapon = weapons.Length - 1;
        }
        weapons[indexWeapon].SetActive(true);
        if (weaponTypes[indexWeapon].isUnlocked == true)
        {
            Pref.CurWeaponID = indexWeapon;
        }
        UpdateUI() ;
    }
    public void UnLock()
    {
        if(Pref.Coins >= weaponTypes[indexWeapon].price)
        {
            Pref.Coins -= weaponTypes[indexWeapon].price;
            weaponTypes[indexWeapon].isUnlocked = true;
            Pref.SetBool(weaponTypes[indexWeapon].name);
            Pref.CurWeaponID = indexWeapon;
            UpdateUI();
        }
        else
        {
            Debug.Log("You dont have enough money");
        }
    }
    public void CloseWeaponBtn()
    {
        gameObject.SetActive(false);
        shopPanel.SetActive(true);
        UIManager.Instance.player.ChangeWeapon();
    }
}

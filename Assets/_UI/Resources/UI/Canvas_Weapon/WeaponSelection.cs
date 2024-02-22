using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class WeaponSelection : Singleton<WeaponSelection>
{
    [SerializeField] private WeaponDisplay weaponDisplay;
    [SerializeField] public WeaponData[] weaponData;
    public TextMeshProUGUI currentCoinLeft;
    private UserData data;
    private Weapon currentWeapShownIndex = (Weapon)0; 

    private void Start()
    {
        data = GameManager.Ins.UserData;
        ShowWeaponAndCoin(currentWeapShownIndex);
    }

    private void Update()
    {
        Debug.Log(currentWeapShownIndex);
    }

    public void BuyWeapon()
    {
        if (!data.BoughtWeapons.Contains((int)currentWeapShownIndex) && data.CurrentCoins >= weaponData[(int)currentWeapShownIndex].price)
        {       
            Debug.Log(weaponData[(int)currentWeapShownIndex].price);
            data.BoughtWeapons.Add((int)currentWeapShownIndex);
            data.CurrentCoins -= weaponData[(int)currentWeapShownIndex].price;
            currentCoinLeft.SetText(data.CurrentCoins.ToString());
            weaponDisplay.DisplayWeaponAndCoin(weaponData[(int)currentWeapShownIndex], data);
            SaveManager.Ins.SaveData(data);
        }

        if (weaponData[(int)currentWeapShownIndex].price.ToString() == Constant.EQUIP_SKIN)
        {
            data.EquippedWeapon = (int)currentWeapShownIndex;
            SaveManager.Ins.SaveData(data);
        }
    }

    public void NextWeaponInShop()
    {
        if (currentWeapShownIndex == (Weapon)2)
        {
            currentWeapShownIndex = (Weapon)0;
            ShowWeaponAndCoin(currentWeapShownIndex);
        }
        else
        {
            currentWeapShownIndex++;
            ShowWeaponAndCoin(currentWeapShownIndex);
        }
    }

    public void PrevWeaponInShop()
    {
        print(1);
        if (currentWeapShownIndex == (Weapon)0)
        {
            print(1);
            currentWeapShownIndex = (Weapon)2;
            ShowWeaponAndCoin(currentWeapShownIndex);
        }
        else
        {
        print(1);
            currentWeapShownIndex--;
            ShowWeaponAndCoin(currentWeapShownIndex);
        }
    }
    private void ShowWeaponAndCoin(Weapon weapon)
    {
        weaponDisplay.DisplayWeaponAndCoin(weaponData[(int)weapon], data);
    }
}
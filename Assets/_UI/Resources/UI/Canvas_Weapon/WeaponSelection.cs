using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class WeaponSelection : Singleton<WeaponSelection>
{
    [SerializeField] private WeaponDisplay weaponDisplay;
    [SerializeField] public WeaponData[] WeaponData;
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
        if (!data.BoughtWeapons.Contains((int)currentWeapShownIndex) && data.CurrentCoins >= WeaponData[(int)currentWeapShownIndex].price)
        {       
            Debug.Log(WeaponData[(int)currentWeapShownIndex].price);
            data.BoughtWeapons.Add((int)currentWeapShownIndex);
            data.CurrentCoins -= WeaponData[(int)currentWeapShownIndex].price;
            currentCoinLeft.SetText(data.CurrentCoins.ToString());
            weaponDisplay.DisplayWeaponAndCoin(WeaponData[(int)currentWeapShownIndex], data);
            string displayPrice = (WeaponData[(int)currentWeapShownIndex].price.ToString() == Constant.EQUIP_SKIN) ? "Equip" : WeaponData[(int)currentWeapShownIndex].price.ToString();
            SaveManager.Ins.SaveData(data);
        }

        if (WeaponData[(int)currentWeapShownIndex].price.ToString() == Constant.EQUIP_SKIN)
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

    //public void PrevWeaponInShop()
    //{
    //    currentWeapShownIndex--;
    //    if (currentWeapShownIndex == (Weapon)0)
    //    {
    //        currentWeapShownIndex = (Weapon)2;
    //    }
    //    ShowWeaponAndCoin(currentWeapShownIndex);
    //}

    private void ShowWeaponAndCoin(Weapon weapon)
    {
        if (weaponDisplay != null)
        {
            weaponDisplay.DisplayWeaponAndCoin(WeaponData[(int)currentWeapShownIndex], data);
            
        }
        else
        {
            Debug.LogError("weaponDisplay is null!");
        }
    }
}

//public class WeaponSelection : Singleton<WeaponSelection>
//{
//    private WeaponDisplay weaponDisplay;
//    [SerializeField] public WeaponData[] WeaponData;
//    public TextMeshProUGUI currentCoinLeft;
//    private UserData data;
//    private Weapon currentWeapShownIndex = (Weapon)0;

//    private void Start()
//    {
//        data = GameManager.Ins.UserData;
//        // Rest of your initialization code
//        //Debug.Log(data.CurrentCoins);
//        //Debug.Log(data.BoughtWeapons);
//        //Debug.Log("2" + (int)currentWeapShownIndex);
//        //Debug.Log(WeaponData[(int)currentWeapShownIndex].price);      
//    }
//    private void Update()
//    {
//        Debug.Log(WeaponData[(int)currentWeapShownIndex].price);
//    }

//    public void BuyWeapon()
//    {
//        Debug.Log("Siu");
//        if (!data.BoughtWeapons.Contains((int)currentWeapShownIndex) && data.CurrentCoins >= WeaponData[(int)currentWeapShownIndex].price)
//        {
//            Debug.Log("Siu2");
//            Debug.Log(WeaponData[(int)currentWeapShownIndex].price);
//            data.BoughtWeapons.Add((int)currentWeapShownIndex);
//            data.CurrentCoins -= WeaponData[(int)currentWeapShownIndex].price;
//            currentCoinLeft.SetText(data.CurrentCoins.ToString());
//            weaponDisplay.UpdateCoint(data);  // Set text Coint
//            SaveManager.Ins.SaveData(data);
//        }

//        if (WeaponData[(int)currentWeapShownIndex].price.ToString() == Constant.EQUIP_SKIN)
//        {
//            data.EquippedWeapon = (int)currentWeapShownIndex;
//            SaveManager.Ins.SaveData(data);

//        }
//    }
//    public void NextWeaponInShop()
//    {
//        if ((int)currentWeapShownIndex == 2)
//        {
//            currentWeapShownIndex = (Weapon)0;
//            showWeapon(currentWeapShownIndex);          
//        }
//        else
//        {
//            currentWeapShownIndex++;
//            showWeapon(currentWeapShownIndex);
//        }

//    }

//    public void PrevWeaponInShop()
//    {
//        if (currentWeapShownIndex == 0)
//        {
//            currentWeapShownIndex = (Weapon)2;

//            showWeapon(currentWeapShownIndex);
//        }
//        else
//        {
//            currentWeapShownIndex--;
//            showWeapon(currentWeapShownIndex);
//        }
//    }

//    private void showWeapon(WeaponData weapon)
//    {
//        // Your code to display the weapon goes here
//        // Assuming you have a method in WeaponDisplay to handle this, e.g., weaponDisplay.DisplayWeapon(WeaponData[weapon]);
//        weaponDisplay.DisplayWeapon(WeaponData[weapon);
//    }
//}

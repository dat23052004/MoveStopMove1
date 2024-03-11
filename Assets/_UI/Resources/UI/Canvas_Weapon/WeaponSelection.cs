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
    private WeaponType currentWeapShownIndex = (WeaponType)0;
    public Button price;
    public Button unequip;
    public Button equip;
    private void Start()
    {
        data = GameManager.Ins.UserData;
        ShowWeaponAndCoin(currentWeapShownIndex);
    }

    private void Update()
    {
        SetWeaponsAvailability(currentWeapShownIndex);
        CheckEquip();
    }

    public void BuyWeapon()
    {
        SoundManager.Ins.Sound.Play();
        if (!data.BoughtWeapons.Contains((int)currentWeapShownIndex) && data.CurrentCoins >= weaponData[(int)currentWeapShownIndex].price)
        {
            Debug.Log(weaponData[(int)currentWeapShownIndex].price);
            data.BoughtWeapons.Add((int)currentWeapShownIndex);
            data.CurrentCoins -= weaponData[(int)currentWeapShownIndex].price;
            currentCoinLeft.SetText(data.CurrentCoins.ToString());
            weaponDisplay.DisplayWeaponAndCoin(weaponData[(int)currentWeapShownIndex], data);
            SaveManager.Ins.SaveData(data);
        }

    }

    public void CheckEquip()
    {
        if (!data.BoughtWeapons.Contains((int)currentWeapShownIndex))
        {
            price.gameObject.SetActive(true);  
            equip.gameObject.SetActive(false);  
            unequip.gameObject.SetActive(false);
        }
        else
        {
            price.gameObject.SetActive(false);
            if (data.EquippedWeapon != (int)currentWeapShownIndex)
            {
                unequip.gameObject.SetActive(true);
                equip.gameObject.SetActive(false);
            }
            else
            {
                unequip.gameObject.SetActive(false);
                equip.gameObject.SetActive(true);
            }
        }
    }
    public void UseWeapon()
    {
        Debug.Log(1);
        if (weaponDisplay.CanChange())
        {
            Debug.Log(2);
            data.EquippedWeapon = (int)currentWeapShownIndex;
            SaveManager.Ins.SaveData(data);
            LevelManager.Ins.player.ChangeWeapon();
        }
    }
    public void NextWeaponInShop()
    {
        SoundManager.Ins.Sound.Play();
        if (currentWeapShownIndex == (WeaponType)2)
        {
            currentWeapShownIndex = (WeaponType)0;
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
        SoundManager.Ins.Sound.Play();
        print(1);
        if (currentWeapShownIndex == (WeaponType)0)
        {
            print(1);
            currentWeapShownIndex = (WeaponType)2;
            ShowWeaponAndCoin(currentWeapShownIndex);
        }
        else
        {
        print(1);
            currentWeapShownIndex--;
            ShowWeaponAndCoin(currentWeapShownIndex);
        }
    }
    private void ShowWeaponAndCoin(WeaponType weapon)
    {
        weaponDisplay.DisplayWeaponAndCoin(weaponData[(int)weapon], data);
    }
    private void SetWeaponsAvailability(WeaponType currentWeaponType)
    {
        if (data.BoughtWeapons.Contains((int)currentWeaponType))
        {
            weaponDisplay.Equiped();
        }
    }
}
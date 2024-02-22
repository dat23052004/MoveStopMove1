﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeItem : Singleton<ChangeItem>
{
    [SerializeField] public HairData[] hairData;
    [SerializeField] private HairDisplay[] hairDisplay;

    [SerializeField] public PantData[] pantData;
    [SerializeField] public PantDisplay[] pantDisplay;

    [SerializeField] public ShieldData[] shieldData;
    [SerializeField] public ShieldDisplay[] shieldDisplay;

    [SerializeField] public SetData[] setData;
    [SerializeField] public SetDisplay[] setDisplay;

    public TextMeshProUGUI currentCoinLeft;
    private UserData data;
    private HatType currentHairShownIndex = (HatType)0;
    private PantType currentPantShownIndex = (PantType)0;
    private ShieldType currentShieldShownIndex = (ShieldType)0;
    private SetType currentSetShownIndex = (SetType)0;

    private void Awake()
    {
        data = GameManager.Ins.UserData;
        Display_Hair(0);
        Display_Pant(0);
        Display_Shield(0);
        Display_Set(0);
    }
    private void Start()
    {
        
    }

    public void BuyItem()
    {
        // Hair
        if (!data.BoughtHats.Contains((int)currentHairShownIndex) && data.CurrentCoins >= hairData[(int)currentHairShownIndex].price)
        {
            Debug.Log(hairData[(int)currentHairShownIndex].price);
            data.BoughtHats.Add((int)currentHairShownIndex);
            data.CurrentCoins -= hairData[(int)currentHairShownIndex].price;
            currentCoinLeft.SetText(data.CurrentCoins.ToString());   
            hairDisplay[(int)currentHairShownIndex].DisplayHairAndUpdatCoint(hairData[(int)currentHairShownIndex], data);
            SaveManager.Ins.SaveData(data);
        }

        if (hairData[(int)currentHairShownIndex].price.ToString() == Constant.EQUIP_SKIN)
        {
            data.EquippedHat = (int)currentHairShownIndex;
            SaveManager.Ins.SaveData(data);
        }

        // Pant
        if (!data.BoughtPants.Contains((int)currentPantShownIndex) && data.CurrentCoins >= pantData[(int)currentPantShownIndex].price)
        {
            Debug.Log(pantData[(int)currentPantShownIndex].price);
            data.BoughtPants.Add((int)currentPantShownIndex);
            data.CurrentCoins -= pantData[(int)currentPantShownIndex].price;
            currentCoinLeft.SetText(data.CurrentCoins.ToString());
            pantDisplay[(int)currentPantShownIndex].DisplayPantAndUpdatCoint(pantData[(int)currentPantShownIndex], data);
            SaveManager.Ins.SaveData(data);
        }

        if (pantData[(int)currentPantShownIndex].price.ToString() == Constant.EQUIP_SKIN)
        {
            data.EquippedPant = (int)currentPantShownIndex;
            SaveManager.Ins.SaveData(data);
        }

        // Shield
        if (!data.bought.Contains((int)currentPantShownIndex) && data.CurrentCoins >= pantData[(int)currentPantShownIndex].price)
        {
            Debug.Log(pantData[(int)currentPantShownIndex].price);
            data.BoughtPants.Add((int)currentPantShownIndex);
            data.CurrentCoins -= pantData[(int)currentPantShownIndex].price;
            currentCoinLeft.SetText(data.CurrentCoins.ToString());
            pantDisplay[(int)currentPantShownIndex].DisplayPantAndUpdatCoint(pantData[(int)currentPantShownIndex], data);
            SaveManager.Ins.SaveData(data);
        }

        if (hairData[(int)currentPantShownIndex].price.ToString() == Constant.EQUIP_SKIN)
        {
            data.EquippedPant = (int)currentPantShownIndex;
            SaveManager.Ins.SaveData(data);
        }

    }


    // CHOOSE HAIR
    private void ShowDisplayAndCoin_Hair(HatType type)
    {
        hairDisplay[(int)type].DisplayHairAndUpdatCoint(hairData[(int)currentHairShownIndex], data);
    }

    public void ButtonHair(int index)
    {
        if (index >= 0 && index < hairData.Length)
        {
            currentHairShownIndex = (HatType)index; // Cập nhật giá trị hiện tại
            ShowDisplayAndCoin_Hair(currentHairShownIndex);
        }
        else
        {
            Debug.LogWarning("Invalid button index: " + index);
        }
    }
    public void Display_Hair(int index)
    {
        for (int i = 0; i < pantData.Length; i++)
        {
            hairDisplay[i].DisplayHair(hairData[i]);
        }
    }


    // CHOOSE PANT
    private void ShowDisplayAndCoin_Pant(PantType type)
    {
            pantDisplay[(int)type].DisplayPantAndUpdatCoint(pantData[(int)currentPantShownIndex], data);
    }

    public void ButtonPant(int index)
    {
        if (index >= 0 && index < pantData.Length)
        {
            currentPantShownIndex = (PantType)index; // Cập nhật giá trị hiện tại
            ShowDisplayAndCoin_Pant(currentPantShownIndex);
        }
        else
        {
            Debug.LogWarning("Invalid button index: " + index);
        }
    }
    public void Display_Pant(int index)
    {
        for (int i = 0; i < pantData.Length; i++)
        {
            pantDisplay[i].DisplayPant(pantData[i]);
        }
    }

    // CHOOSE Shield
    private void ShowDisplayAndCoin_Shield(ShieldType type)
    {
        shieldDisplay[(int)type].DisplayShieldAndUpdatCoint(shieldData[(int)currentShieldShownIndex], data);
    }

    public void ButtonShield(int index)
    {
        if (index >= 0 && index < shieldData.Length)
        {
            currentShieldShownIndex = (ShieldType)index; // Cập nhật giá trị hiện tại
            ShowDisplayAndCoin_Shield(currentShieldShownIndex);
        }
        else
        {
            Debug.LogWarning("Invalid button index: " + index);
        }
    }
    public void Display_Shield (int index)
    {
        for (int i = 0; i < shieldData.Length; i++)
        {
            shieldDisplay[i].DisplayShield(shieldData[i]);
        }
    }


    // CHOOSE SET
    private void ShowDisplayAndCoin_Set(SetType type)
    {
        setDisplay[(int)type].DisplaySetAndUpdatCoint(setData[(int)currentSetShownIndex], data);
    }

    public void ButtonSet(int index)
    {
        if (index >= 0 && index < setData.Length)
        {
            currentSetShownIndex = (SetType)index; // Cập nhật giá trị hiện tại
            ShowDisplayAndCoin_Set(currentSetShownIndex);
        }
        else
        {
            Debug.LogWarning("Invalid button index: " + index);
        }
    }
    public void Display_Set(int index)
    {
        for (int i = 0; i < setData.Length; i++)
        {
            setDisplay[i].DisplaySet(setData[i]);
        }
    }


}

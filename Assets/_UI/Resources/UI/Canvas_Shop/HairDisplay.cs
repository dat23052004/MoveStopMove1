using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HairDisplay : MonoBehaviour
{   
    [SerializeField] private TextMeshProUGUI hairBonus;   
    [SerializeField] private TextMeshProUGUI hairPrice;
    [SerializeField] private Image HairImage;
    [SerializeField] private TextMeshProUGUI coinText;

    public void DisplayHairAndUpdatCoint(HairData hairData, UserData userData)
    {
        DisplayHair(hairData);
        UpdateCoin(userData);
    }
    public void DisplayHair(HairData HairData)
    {       
        hairBonus.text = HairData.bonus;
        hairPrice.text = HairData.price.ToString();
        HairImage.sprite = HairData.image;       
    }
    public bool CanChange()
    {
        if (hairPrice.text == Constant.EQUIP_SKIN)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private void UpdateCoin(UserData userData)
    {
        coinText.text = userData.CurrentCoins.ToString();   
    }

    public void Equiped()
    {
        hairPrice.SetText(Constant.EQUIP_SKIN);
    }
}

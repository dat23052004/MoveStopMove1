using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HairDisplay : MonoBehaviour
{   
    [SerializeField] private TextMeshProUGUI HairBonus;   
    [SerializeField] private TextMeshProUGUI HairPrice;
    [SerializeField] private Image HairImage;
    [SerializeField] private TextMeshProUGUI coinText;

    public void DisplayHairAndUpdatCoint(HairData hairData, UserData userData)
    {
        DisplayHair(hairData);
        UpdateCoin(userData);
    }
    public void DisplayHair(HairData HairData)
    {        
        HairBonus.text = HairData.bonus;
        HairPrice.text = HairData.price.ToString();
        HairImage.sprite = HairData.image;       
    }

    private void UpdateCoin(UserData userData)
    {
        coinText.text = userData.CurrentCoins.ToString();
    }
}

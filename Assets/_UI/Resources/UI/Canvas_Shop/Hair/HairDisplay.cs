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

    public void DisplayHair(HairData HairData)
    {
        
        HairBonus.text = HairData.bonus;       
        HairPrice.text = HairData.price.ToString();
        HairImage.sprite = HairData.image;       
    }   
}

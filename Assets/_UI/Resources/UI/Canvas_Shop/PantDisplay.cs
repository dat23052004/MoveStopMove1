using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PantDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI PantBonus;
    [SerializeField] private TextMeshProUGUI PantPrice;
    [SerializeField] private Image pantImage;

    public void DisplayPant(PantData PantData)
    {

        PantBonus.text = PantData.bonus;
        PantPrice.text = PantData.price.ToString();
        pantImage.sprite = PantData.image;

    }
}

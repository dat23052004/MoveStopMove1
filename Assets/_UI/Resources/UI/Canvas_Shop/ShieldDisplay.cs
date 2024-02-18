using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShieldDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ShieldBonus;
    [SerializeField] private TextMeshProUGUI ShieldPrice;
    [SerializeField] private Image ShieldImage;

    public void DisplayShield(ShieldData ShieldData)
    {

        ShieldBonus.text = ShieldData.bonus;
        ShieldPrice.text = ShieldData.price.ToString();
        ShieldImage.sprite = ShieldData.image;

    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI SetBonus;
    [SerializeField] private TextMeshProUGUI SetPrice;
    [SerializeField] private Image SetImage;

    public void DisplaySet(SetData SetData)
    {

        SetBonus.text = SetData.bonus;
        SetPrice.text = SetData.price.ToString();
        SetImage.sprite = SetData.image;

    }
}

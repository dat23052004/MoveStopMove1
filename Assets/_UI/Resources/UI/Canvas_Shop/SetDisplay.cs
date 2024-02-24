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
    [SerializeField] private TextMeshProUGUI coinText;

    public void DisplaySetAndUpdatCoint(SetData setData, UserData userData)
    {
        DisplaySet(setData);
        UpdateCoin(userData);
    }
    public void DisplaySet(SetData setData)
    {
        SetBonus.text = setData.bonus;
        SetPrice.text = setData.price.ToString();
        SetImage.sprite = setData.image;
    }

    private void UpdateCoin(UserData userData)
    {
        coinText.text = userData.CurrentCoins.ToString();
    }

    public void Equiped()
    {
        SetPrice.SetText(Constant.EQUIP_SKIN);
    }
}

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
    [SerializeField] private TextMeshProUGUI coinText;

    public void DisplayPantAndUpdatCoint(PantData pantData, UserData userData)
    {
        DisplayPant(pantData);
        UpdateCoin(userData);
    }
    public void DisplayPant(PantData PantData)
    {
        PantBonus.text = PantData.bonus;
        PantPrice.text = PantData.price.ToString();
        pantImage.sprite = PantData.image;
    }

    private void UpdateCoin(UserData userData)
    {
        coinText.text = userData.CurrentCoins.ToString();
    }
    public void Equiped()
    {
        PantPrice.SetText(Constant.EQUIP_SKIN);
    }
}

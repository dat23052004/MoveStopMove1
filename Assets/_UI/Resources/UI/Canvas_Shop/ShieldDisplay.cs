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
    [SerializeField] private TextMeshProUGUI coinText;

    public void DisplayShieldAndUpdatCoint(ShieldData shieldData, UserData userData)
    {
        DisplayShield(shieldData);
        UpdateCoin(userData);
    }
    public void DisplayShield(ShieldData ShieldData)
    {
        ShieldBonus.text = ShieldData.bonus;
        ShieldPrice.text = ShieldData.price.ToString();
        ShieldImage.sprite = ShieldData.image;
    }

    private void UpdateCoin(UserData userData)
    {
        coinText.text = userData.CurrentCoins.ToString();
    }
}

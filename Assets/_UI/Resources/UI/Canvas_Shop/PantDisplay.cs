using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PantDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI PantBonus;
    [SerializeField] private TextMeshProUGUI PantPrice;
    [SerializeField] private TextMeshProUGUI PantEquip;
    [SerializeField] private Image pantImage;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private Outline equipOutline;
    [SerializeField] private Outline unequipOutline;

    public void SetOutlineVisibility(bool equipOutlineVisible, bool unequipOutlineVisible)
    {
        if (equipOutline != null)
        {
            equipOutline.enabled = equipOutlineVisible;
        }

        if (unequipOutline != null)
        {
            unequipOutline.enabled = unequipOutlineVisible;
        }
    }

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
    public bool CanChange()
    {
        if (PantEquip.text == Constant.UNEQUIP_SKIN)
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
        PantEquip.SetText(Constant.UNEQUIP_SKIN);
    }
}

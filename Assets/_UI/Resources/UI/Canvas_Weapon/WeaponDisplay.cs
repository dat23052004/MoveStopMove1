using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//public class WeaponDisplay : MonoBehaviour
//{
//    [SerializeField] private TextMeshProUGUI weaponName;
//    [SerializeField] private TextMeshProUGUI weaponBonus;
//    [SerializeField] private TextMeshProUGUI weaponDescription;
//    [SerializeField] private TextMeshProUGUI weaponPrice;
//    [SerializeField] private Transform weaponHolder;
//    [SerializeField] private TextMeshProUGUI coinText;
//    public void DisplayWeapon(WeaponData weaponData)
//    {
//        weaponName.text = weaponData.name;
//        weaponBonus.text = weaponData.bonus;
//        weaponDescription.text = weaponData.description;
//        weaponPrice.text = weaponData.price.ToString();


//        if (weaponHolder.childCount > 0)
//            Destroy(weaponHolder.GetChild(0).gameObject);

//        Instantiate(weaponData.Model, weaponHolder.position, weaponHolder.rotation, weaponHolder);
//    }    

//    public void UpdateCoint(UserData userData)
//    {
//        coinText.text = userData.CurrentCoins.ToString();
//    }
//}
public class WeaponDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI weaponName;
    [SerializeField] private TextMeshProUGUI weaponBonus;
    [SerializeField] private TextMeshProUGUI weaponDescription;
    [SerializeField] private TextMeshProUGUI weaponPrice;
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private TextMeshProUGUI coinText;

    public void DisplayWeaponAndCoin(WeaponData weaponData, UserData userData)
    {
        ShowWeapon(weaponData);
        UpdateCoin(userData);
    }

    private void ShowWeapon(WeaponData weaponData)
    {
        weaponName.text = weaponData.name;
        weaponBonus.text = weaponData.bonus;
        weaponDescription.text = weaponData.description;
        weaponPrice.text = weaponData.price.ToString();

        if (weaponHolder.childCount > 0)
            Destroy(weaponHolder.GetChild(0).gameObject);

        Instantiate(weaponData.Model, weaponHolder.position, weaponHolder.rotation, weaponHolder);
    }

    private void UpdateCoin(UserData userData)
    {
        coinText.text = userData.CurrentCoins.ToString();
    }
}

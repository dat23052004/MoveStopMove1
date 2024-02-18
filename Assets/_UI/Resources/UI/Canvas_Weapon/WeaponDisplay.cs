using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI weaponName;
    [SerializeField] private TextMeshProUGUI weaponBonus;
    [SerializeField] private TextMeshProUGUI weaponDescription;
    [SerializeField] private TextMeshProUGUI weaponPrice;
    [SerializeField] private Transform weaponHolder;

    public void DisplayWeapon(WeaponData weaponData)
    {
        weaponName.text = weaponData.name;
        weaponBonus.text = weaponData.bonus;
        weaponDescription.text = weaponData.description;
        weaponPrice.text = weaponData.price.ToString();

        if (weaponHolder.childCount > 0)
            Destroy(weaponHolder.GetChild(0).gameObject);

        Instantiate(weaponData.Model, weaponHolder.position, weaponHolder.rotation, weaponHolder);
    }    
}

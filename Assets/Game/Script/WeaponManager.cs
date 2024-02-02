using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public Image weaponImage;
    public Sprite[] weaponSprites; // Mảng chứa hình ảnh của các vũ khí

    private int currentWeaponIndex = 0; // Index của vũ khí hiện tại

    void Start()
    {
        UpdateWeaponImage();
    }

    void Update()
    {
        // Logic để thay đổi vũ khí (ví dụ: bằng cách nhấn một phím)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeWeapon();
        }
    }

    void ChangeWeapon()
    {
        currentWeaponIndex = (currentWeaponIndex + 1) % weaponSprites.Length;
        UpdateWeaponImage();
    }

    void UpdateWeaponImage()
    {
        weaponImage.sprite = weaponSprites[currentWeaponIndex];
    }
}

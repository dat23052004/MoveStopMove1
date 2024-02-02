using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject[] weaponPrefabs; // Mảng chứa các prefab vũ khí khác nhau
    public int numberOfWeapons = 3;
    public float spacing = 2f; // Khoảng cách giữa các vũ khí

    void Start()
    {
        SpawnWeapons();
    }

    void SpawnWeapons()
    {
        for (int i = 0; i < numberOfWeapons; i++)
        {
            Debug.Log(1);
            
            // Tính toán vị trí cho mỗi vũ khí
            float xOffset = i * spacing;
            Vector3 spawnPosition = new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z);

            // Lấy prefab vũ khí tương ứng từ mảng
            GameObject weaponPrefab = weaponPrefabs[i % weaponPrefabs.Length];

            // Spawn vũ khí
            GameObject weapon = Instantiate(weaponPrefab, spawnPosition, Quaternion.identity);
            Debug.Log(weapon.transform.position);
            // Đặt parent của vũ khí là cha của script (WeaponSpawner)
            weapon.transform.parent = transform;
        }
    }
}

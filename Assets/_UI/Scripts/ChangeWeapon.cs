using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject[] weaponPrefabs; // Mảng chứa các prefab vũ khí khác nhau
    public int numberOfWeapons = 3;
    public Vector3 spawnPosition; // Điểm spawn vũ khí

    void Start()
    {
        SpawnWeapons();
    }

    void SpawnWeapons()
    {
        for (int i = 1; i < numberOfWeapons; i++)
        {
            Debug.Log(1);

            // Lấy prefab vũ khí tương ứng từ mảng
            GameObject weaponPrefab = weaponPrefabs[i % weaponPrefabs.Length];

            // Spawn vũ khí tại điểm cố định
            GameObject weapon = Instantiate(weaponPrefab, spawnPosition, Quaternion.identity);
            Debug.Log(weapon.transform.position);

            // Đặt parent của vũ khí là cha của script (WeaponSpawner)
            weapon.transform.parent = transform;
        }
    }
}

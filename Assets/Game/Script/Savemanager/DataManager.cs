using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.LightingExplorerTableColumn;

public class DataManager : Singleton<DataManager>
{
    public WeaponData[] weaponData;
    public HairData[] hairData;
    public PantData[] pantData;

    public WeaponData GetWeaponData(int weaponIndex)
    {
        return weaponData[weaponIndex];
    }
    public HairData GetHatData(int HairData)
    {
        return hairData[HairData];

    }

    public PantData GetPantData(int PantIndex)
    {
        return pantData[PantIndex];

    }

}

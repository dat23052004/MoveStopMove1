using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public WeaponData[] weaponData;
    public WeaponData[] hatData;
    public PantData[] pantData;


    //public WeaponData GetWeaponData(WeaponType weaponType)
    //{
    //    List<WeaponData> weaponData = weaponDataSO.weaponDataList;
    //    for (int i = 0; i < weaponData.Count; i++)
    //    {
    //        if(weaponType == weaponData[i].weaponType)
    //        {
    //            //return weaponData[i];
    //            return weaponData[i].Clone();
    //        }
    //    }

    //    return null;
    //}

    public WeaponData GetWeaponData(int weaponIndex)
    {
        return weaponData[weaponIndex];
    }

    
}

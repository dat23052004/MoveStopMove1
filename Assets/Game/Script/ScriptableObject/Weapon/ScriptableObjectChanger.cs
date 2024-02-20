using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class ScriptableObjectChanger : MonoBehaviour
{
   [SerializeField] private ScriptableObject[] scriptableObjects;
    [SerializeField] private WeaponDisplay weaponDisplay;
    private int currentIndex;

    private void Awake()
    {
        ChangeScriptableObject(0);
    }

    public void ChangeScriptableObject(int _change)
    {
        currentIndex += _change;
        Debug.Log(currentIndex.ToString());
        if(currentIndex < 0 ) currentIndex = scriptableObjects.Length-1;
        else if(currentIndex > scriptableObjects.Length-1) currentIndex = 0;

        if (weaponDisplay != null) weaponDisplay.DisplayWeapon((WeaponData)scriptableObjects[currentIndex]);
    }
}

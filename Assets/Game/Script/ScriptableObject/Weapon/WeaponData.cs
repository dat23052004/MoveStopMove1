using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Custom/Model Weapon", order = 1)]
public class WeaponData : ScriptableObject
{
    public string name;
    public string bonus;
    public string description;
    public int price;
    public GameObject Model;

}

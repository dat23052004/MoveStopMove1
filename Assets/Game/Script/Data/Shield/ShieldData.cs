using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Custom/Shield", order = 1)]
public class ShieldData : ScriptableObject
{
    public string bonus;
    public int price;
    public Sprite image;
}

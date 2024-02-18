using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Custom/Pants", order = 1)]
public class PantData : ScriptableObject
{
    public string bonus;
    public int price;
    public Sprite image;
}

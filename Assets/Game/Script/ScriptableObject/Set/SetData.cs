using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Custom/Set", order = 1)]

public class SetData : ScriptableObject
{
    public string bonus;
    public int price;
    public Sprite image;
}

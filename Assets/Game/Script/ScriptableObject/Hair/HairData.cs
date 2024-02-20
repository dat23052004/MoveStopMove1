using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "Custom/Hair", order = 1)]
public class HairData : ScriptableObject
{   
    public string bonus;
    public int price;
    public Sprite image;
}

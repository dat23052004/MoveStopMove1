using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum PantType
{
    Default = 0,
    Pant_1 = 1,
    Pant_2 = 2,
    Pant_3 = 3,
    Pant_4 = 4,
    Pant_5 = 5,
    Pant_6 = 6,
    Pant_7 = 7,
    Pant_8 = 8,
    Pant_9 = 9
}

public enum HatType
{
    Default = 0,
    Cap = 1,
    Cowboy = 2,
    Crown = 3,
    Ear = 4,
    Arrow = 5,
    Horn = 6,
    headPhone = 7,
    PoliceCap = 8,
    StrawHat = 9
}

public enum ShieldType
{
    Default = 0,
    Shield = 1,
    CaptainShield = 2
}



public enum Weapon
{
    Arrow = 0,
    Axe = 1,
    Boomerang = 2
}
public class ShopManager : Singleton<ShopManager>
{
    
    private UserData data;
    //public bool hatSession;
    //public bool pantSession;
    public int currentSession;
}

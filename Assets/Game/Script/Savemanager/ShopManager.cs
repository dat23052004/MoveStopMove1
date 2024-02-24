using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum PantType
{
    Pant_0 = 0,
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

public enum HairType
{   
    Cap = 0,
    Cowboy = 1,
    Crown = 2,
    Ear = 3,
    Arrow = 4,
    Horn = 5,
    headPhone = 6,
    PoliceCap = 7,
    StrawHat = 8,
}

public enum ShieldType
{
    Default = 0,
    Shield = 1,
    CaptainShield = 2
}

public enum SetType
{
    Default = 0,
    Shield = 1,
    CaptainShield = 2
}


public enum WeaponType
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

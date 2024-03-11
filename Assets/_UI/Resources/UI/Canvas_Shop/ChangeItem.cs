using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeItem : Singleton<ChangeItem>
{
    [SerializeField] public HairData[] hairData;
    [SerializeField] private HairDisplay[] hairDisplay;

    [SerializeField] public PantData[] pantData;
    [SerializeField] public PantDisplay[] pantDisplay;

    [SerializeField] public ShieldData[] shieldData;
    [SerializeField] public ShieldDisplay[] shieldDisplay;

    [SerializeField] public SetData[] setData;
    [SerializeField] public SetDisplay[] setDisplay;

    public TextMeshProUGUI currentCoinLeft;
    private UserData data;
    private HairType currentHairShownIndex = (HairType)0;
    private PantType currentPantShownIndex = (PantType)0;
    private ShieldType currentShieldShownIndex = (ShieldType)0;
    private SetType currentSetShownIndex = (SetType)0;
    public int currentTypeItem;
    public Button price;
    public Button unequip;
    public Button equip;

    private void Awake()
    {
        data = GameManager.Ins.UserData;
        Display_Hair(0);
        Display_Pant(0);
        Display_Shield(0);
        Display_Set(0);
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        SetItemAvailability(currentHairShownIndex, currentPantShownIndex, currentShieldShownIndex, currentSetShownIndex);
        CheckEquip();
        CheckOutline();
    }

    public void BuyItem()
    {
        // Hair
        SoundManager.Ins.Sound.Play();
        if (!data.BoughtHats.Contains((int)currentHairShownIndex) && data.CurrentCoins >= hairData[(int)currentHairShownIndex].price)
        {
            data.BoughtHats.Add((int)currentHairShownIndex);
            data.CurrentCoins -= hairData[(int)currentHairShownIndex].price;
            currentCoinLeft.SetText(data.CurrentCoins.ToString());   
            hairDisplay[(int)currentHairShownIndex].DisplayHairAndUpdatCoint(hairData[(int)currentHairShownIndex], data);
            SaveManager.Ins.SaveData(data);
        }

        // Pant
        if (!data.BoughtPants.Contains((int)currentPantShownIndex) && data.CurrentCoins >= pantData[(int)currentPantShownIndex].price)
        {
            Debug.Log(pantData[(int)currentPantShownIndex].price);
            data.BoughtPants.Add((int)currentPantShownIndex);
            data.CurrentCoins -= pantData[(int)currentPantShownIndex].price;
            currentCoinLeft.SetText(data.CurrentCoins.ToString());
            pantDisplay[(int)currentPantShownIndex].DisplayPantAndUpdatCoint(pantData[(int)currentPantShownIndex], data);
            SaveManager.Ins.SaveData(data);
        }
    }
    public void UseItem()
    {
        if(currentTypeItem == 0)
        {
            if (hairDisplay[(int)currentHairShownIndex].CanChange())
            {
                Debug.Log(2);
                data.EquippedHat = (int)currentHairShownIndex;
                SaveManager.Ins.SaveData(data);
                LevelManager.Ins.player.ChangeHair();
            }

        }
        if(currentTypeItem == 1)
        {
            if (pantDisplay[(int)currentPantShownIndex].CanChange())
            {
                Debug.Log(3);
                data.EquippedPant = (int)currentPantShownIndex;
                SaveManager.Ins.SaveData(data);
                LevelManager.Ins.player.ChangePant();
            }
        }
    }


    public void CheckEquip()
    {
        if(currentTypeItem == 0)
        {
            if (!data.BoughtHats.Contains((int)currentHairShownIndex))
            {
                price.gameObject.SetActive(true);
                equip.gameObject.SetActive(false);
                unequip.gameObject.SetActive(false);
            }
            else
            {
                price.gameObject.SetActive(false);
                if (data.EquippedHat != (int)currentHairShownIndex)
                {
                    Debug.Log(333);
                    unequip.gameObject.SetActive(true);
                    equip.gameObject.SetActive(false);
                }
                else
                {
                    Debug.Log(222);
                    unequip.gameObject.SetActive(false);
                    equip.gameObject.SetActive(true);
                }
            }
        }


        if(currentTypeItem == 1)
        {
            if (!data.BoughtPants.Contains((int)currentPantShownIndex))
            {
                price.gameObject.SetActive(true);
                equip.gameObject.SetActive(false);
                unequip.gameObject.SetActive(false);     
            }
            else
            {
                price.gameObject.SetActive(false);
                if (data.EquippedPant != (int)currentPantShownIndex)
                {
                    Debug.Log(333);
                    unequip.gameObject.SetActive(true);
                    equip.gameObject.SetActive(false);
                }
                else
                {
                    Debug.Log(222);
                    unequip.gameObject.SetActive(false);
                    equip.gameObject.SetActive(true);
                }
            }
        }
  
    }

    // CHOOSE HAIR
    private void ShowDisplayAndCoin_Hair(HairType type)
    {
        hairDisplay[(int)type].DisplayHairAndUpdatCoint(hairData[(int)currentHairShownIndex], data);
    }

    public void ButtonHair(int index)
    {
        SoundManager.Ins.Sound.Play();
        if (index >= 0 && index < hairData.Length)
        {
            currentHairShownIndex = (HairType)index; // Cập nhật giá trị hiện tại
            ShowDisplayAndCoin_Hair(currentHairShownIndex);
            currentTypeItem = 0;
            LevelManager.Ins.player.TryHair(index);
        }
        else
        {
            Debug.LogWarning("Invalid button index: " + index);
        }
    }
    public void Display_Hair(int index)
    {
        SoundManager.Ins.Sound.Play();
        for (int i = 0; i < hairData.Length; i++)
        {
            hairDisplay[i].DisplayHair(hairData[i]);
            
        }
    }

    public void CheckOutline()
    {
        if(currentTypeItem == 0)
        {
            for (int i = 0; i < hairData.Length; i++)
            {
                if (!data.BoughtHats.Contains(i))
                {
                    hairDisplay[i].SetOutlineVisibility(false, false);
                }
                else
                {
                    if (data.EquippedHat != i)
                    {
                        hairDisplay[i].SetOutlineVisibility(true, false);
                    }
                    else
                    {
                        hairDisplay[i].SetOutlineVisibility(false, true);
                    }
                }
            }
        }
        if (currentTypeItem == 1)
        {
            Debug.Log(1);
            for (int i = 0; i < pantData.Length; i++)
            {
                Debug.Log(2);
                if (!data.BoughtPants.Contains(i))
                {
                    Debug.Log(3);
                    pantDisplay[i].SetOutlineVisibility(false, false);
                }
                else
                {
                    if (data.EquippedPant != i)
                    {
                        Debug.Log(4);
                        pantDisplay[i].SetOutlineVisibility(true, false);
                    }
                    else
                    {
                        Debug.Log(5);
                        pantDisplay[i].SetOutlineVisibility(false, true);
                    }
                }
            }
        }    
    }


    // CHOOSE PANT
    private void ShowDisplayAndCoin_Pant(PantType type)
    {
            pantDisplay[(int)type].DisplayPantAndUpdatCoint(pantData[(int)currentPantShownIndex], data);
    }

    public void ButtonPant(int index)
    {
        SoundManager.Ins.Sound.Play();
        if (index >= 0 && index < pantData.Length)
        {
            currentPantShownIndex = (PantType)index; // Cập nhật giá trị hiện tại
            ShowDisplayAndCoin_Pant(currentPantShownIndex);
            currentTypeItem = 1;
            LevelManager.Ins.player.TryPant(index);
        }
        else
        {
            Debug.LogWarning("Invalid button index: " + index);
        }
    }
    public void Display_Pant(int index)
    {
        for (int i = 0; i < pantData.Length; i++)
        {
            pantDisplay[i].DisplayPant(pantData[i]);
        }
    }

    // CHOOSE Shield
    private void ShowDisplayAndCoin_Shield(ShieldType type)
    {
        shieldDisplay[(int)type].DisplayShieldAndUpdatCoint(shieldData[(int)currentShieldShownIndex], data);
    }

    public void ButtonShield(int index)
    {
        SoundManager.Ins.Sound.Play();
        if (index >= 0 && index < shieldData.Length)
        {
            currentShieldShownIndex = (ShieldType)index; // Cập nhật giá trị hiện tại
            ShowDisplayAndCoin_Shield(currentShieldShownIndex);
            currentTypeItem = 2;
        }
        else
        {
            Debug.LogWarning("Invalid button index: " + index);
        }
    }
    public void Display_Shield (int index)
    {
        for (int i = 0; i < shieldData.Length; i++)
        {
            shieldDisplay[i].DisplayShield(shieldData[i]);
        }
    }


    // CHOOSE SET
    private void ShowDisplayAndCoin_Set(SetType type)
    {
        setDisplay[(int)type].DisplaySetAndUpdatCoint(setData[(int)currentSetShownIndex], data);
    }

    public void ButtonSet(int index)
    {
        SoundManager.Ins.Sound.Play();
        if (index >= 0 && index < setData.Length)
        {
            currentSetShownIndex = (SetType)index; // Cập nhật giá trị hiện tại
            ShowDisplayAndCoin_Set(currentSetShownIndex);
            currentTypeItem = 3;
        }
        else
        {
            Debug.LogWarning("Invalid button index: " + index);
        }
    }
    public void Display_Set(int index)
    {
        for (int i = 0; i < setData.Length; i++)
        {
            setDisplay[i].DisplaySet(setData[i]);
        }
    }

    private void SetItemAvailability(HairType currentHair, PantType currentPant, ShieldType currentShield, SetType currentSet)
    {
        if(currentTypeItem == 0)
        {
            if (data.BoughtHats.Contains((int)currentHair))
            {
                hairDisplay[(int)currentHair].Equiped();
            }
        }
        else if (currentTypeItem == 1)
        {
            if (data.BoughtPants.Contains((int)currentPant))
            {
                pantDisplay[(int)currentPant].Equiped();
            }
            
        }

        else if(currentTypeItem == 2)
        {
            if (data.BoughtShields.Contains((int)currentShield))
            {
                shieldDisplay[(int)currentShieldShownIndex].Equiped();
            }
        }        
        else
        {
            if (data.BoughtSets.Contains((int)currentSet))
            {
                setDisplay[(int)currentSetShownIndex].Equiped();
            }
        }      
    }
}

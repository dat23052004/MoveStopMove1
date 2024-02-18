using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeItem : MonoBehaviour
{
    [SerializeField] public HairData[] hairData;
    [SerializeField] public HairDisplay[] hairDisplay;

    [SerializeField] public PantData[] pantData;
    [SerializeField] public PantDisplay[] pantDisplay;

    [SerializeField] public ShieldData[] shieldData;
    [SerializeField] public ShieldDisplay[] shieldDisplay;

    [SerializeField] public SetData[] setData;
    [SerializeField] public SetDisplay[] setDisplay;
    private int currentIndex;

    private void Awake()
    {
        Display_Hair(0);
        Display_Pant(0);
        Display_Shield(0);
        Display_Set(0);
    }

    public void ButtonHair(int index)
    {

        if (index >= 0 && index < hairData.Length)
        {
            hairDisplay[index].DisplayHair(hairData[index]);
        }
        else
        {
            Debug.LogWarning("Invalid button index: " + index);
        }
    }

    public void Display_Hair(int index)
    {
        for (int i = 0; i < hairData.Length; i++)
        {
            hairDisplay[i].DisplayHair(hairData[i]);
        }
    }

    public void ButtonPant(int index)
    {

        if (index >= 0 && index < pantData.Length)
        {
            pantDisplay[index].DisplayPant(pantData[index]);
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

    public void ButtonShield(int index)
    {

        if (index >= 0 && index < shieldData.Length)
        {
            shieldDisplay[index].DisplayShield(shieldData[index]);
        }
        else
        {
            Debug.LogWarning("Invalid button index: " + index);
        }
    }
    public void Display_Shield(int index)
    {
        for (int i = 0; i < shieldData.Length; i++)
        {
            shieldDisplay[i].DisplayShield(shieldData[i]);
        }
    }

    public void ButtonSet(int index)
    {

        if (index >= 0 && index < setData.Length)
        {
            setDisplay[index].DisplaySet(setData[index]);
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

}

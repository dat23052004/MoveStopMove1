using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorType { Blue, Red, Yellow, Green, Violet }
public class ColorObject : MonoBehaviour
{
    public ColorType colorType;
    [SerializeField] private Renderer Renderer;
    public Material[] colorMats;

    public void ChangeColor(ColorType colorType)
    {
        this.colorType = colorType;
        Renderer.material = GetColorMats(colorType);
    }

    public Material GetColorMats(ColorType colorType)
    {
        return colorMats[(int)colorType];
    }
}

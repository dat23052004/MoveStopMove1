using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductUI : MonoBehaviour
{
    public GameObject Price;

    TextMeshProUGUI PriceText;
    public Button buyButton;

    private ProductInfo productInfo;



    private void Start()
    {
        PriceText = Price.GetComponent<TextMeshProUGUI>();
    }

    public void SetProductInfo(ProductInfo info)
    {
        productInfo = info;
        UpdateUI();
    }

    private void UpdateUI()
    {
        PriceText.text = "$" + productInfo.Price.ToString();
    }

    public void OnBuyButtonClick()
    {
        
        
        Debug.Log($"Bought: {productInfo.Price}");
    }
}

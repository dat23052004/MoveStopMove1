using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class HairShop : MonoBehaviour
{
    public TextMeshPro descriptionText;
    public TextMeshPro priceText;

    public HairData[] pantDatas; // Mảng chứa thông tin về quần

    private void Start()
    {
        // Khởi đầu hiển thị thông tin của quần đầu tiên
        DisplayPantData(0);
    }

    public void DisplayPantData(int pantIndex)
    {
        // Đảm bảo pantIndex hợp lệ
        if (pantIndex >= 0 && pantIndex < pantDatas.Length)
        {
            // Lấy thông tin từ ScriptableObject tương ứng
            HairData currentPant = pantDatas[pantIndex];

            // Hiển thị thông tin lên UI
            descriptionText.text = currentPant.description;
            priceText.text = $"Price: {currentPant.price}";
        }
        else
        {
            Debug.LogError("Invalid pant index");
        }
    }
}

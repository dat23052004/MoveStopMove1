using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public List<ProductInfo> products;
    public ProductUI productUI;

    private int currentIndex = 0;

    private void Start()
    {
        if (products.Count > 0)
        {
            // Cập nhật thông tin sản phẩm cho ProductUI với sản phẩm đầu tiên
            productUI.SetProductInfo(products[currentIndex]);
        }
        else
        {
            Debug.LogWarning("No products found!");
        }
    }

    public void ChangeProduct(int productIndex)
    {
        // Đảm bảo chỉ số sản phẩm nằm trong khoảng hợp lý
        if (productIndex >= 0 && productIndex < products.Count)
        {
            // Cập nhật thông tin sản phẩm cho ProductUI
            currentIndex = productIndex;
            productUI.SetProductInfo(products[currentIndex]);
        }
        else
        {
            Debug.LogWarning("Invalid product index.");
        }
    }

    //public void ChangeProduct(bool next)
    //{
    //    // Thay đổi sản phẩm hiển thị
    //    if (next)
    //    {
    //        currentIndex = (currentIndex + 1) % products.Count;
    //    }
    //    else
    //    {
    //        currentIndex = (currentIndex - 1 + products.Count) % products.Count;
    //    }

    //    // Cập nhật thông tin sản phẩm cho ProductUI
    //    productUI.SetProductInfo(products[currentIndex]);
    //}

}

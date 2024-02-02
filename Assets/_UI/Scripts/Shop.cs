using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shop : UICanvas
{
    public GameObject scrollView1;
    public GameObject scrollView2;
    public GameObject scrollView3;
    public GameObject scrollView4;


    private void Start()
    {
        ActivateScrollView(scrollView1);
        DeactivateOtherScrollViews(scrollView1);
    }

    public void OnButtonPants()
    {
        ActivateScrollView(scrollView1);
        DeactivateOtherScrollViews(scrollView1);
    }

    public void OnButtonHair()
    {
        ActivateScrollView(scrollView2);
        DeactivateOtherScrollViews(scrollView2);
    }

    public void OnButtonSet()
    {
        ActivateScrollView(scrollView3);
        DeactivateOtherScrollViews(scrollView3);
    }
    public void OnButtonShield()
    {
        ActivateScrollView(scrollView4);
        DeactivateOtherScrollViews(scrollView4);
    }

    private void ActivateScrollView(GameObject scrollView)
    {
        scrollView.SetActive(true);
    }

    private void DeactivateOtherScrollViews(GameObject activeScrollView)
    {
        GameObject[] allScrollViews = { scrollView1, scrollView2, scrollView3, scrollView4 };

        foreach (GameObject scrollView in allScrollViews)
        {
            if (scrollView != activeScrollView)
            {
                scrollView.SetActive(false);
            }
        }
    }
}

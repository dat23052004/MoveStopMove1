using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Level : MonoBehaviour
{
    public float planeWidth = 10f;
    public float planeDepth = 10f;
    public List<Vector3> pointList = new List<Vector3>();
                
    private void Awake()
    {         
        GeneratePoints();
    }
    public void GeneratePoints()   // Duyệt các điểm để bot đi đến lần lượt.
    {
        // Số lượng điểm muốn tạo
        int numberOfPoints = 200;

        int i = 0;
        while (i < numberOfPoints)
        {
            float randomX = Random.Range(-planeWidth / 2f, planeWidth / 2f);
            float randomZ = Random.Range(-planeDepth / 2f, planeDepth / 2f);
            float yPosition = 0f;
            Vector3 pointPosition = new Vector3(randomX, yPosition, randomZ);
            pointList.Add(pointPosition);
      
            //Debug.Log(i + ": " + pointList[i]); // In ra giá trị sau khi thêm vào
            i++;
        }
    }

    public void SpawnBot()
    {

    }
}

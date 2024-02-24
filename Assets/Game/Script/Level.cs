using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[Serializable]
public class Level : MonoBehaviour
{
    public float planeWidth;
    public float planeDepth;
    public int totalBotSpawn;
    public int levelId;
    public GameObject levelEnvironment;
    public Transform playerSpawnPoint;

    //public List<Vector3> pointList = new List<Vector3>();

    //public GameObject botPrefab;    // Gán prefab của bot trong Inspector
    //public List<GameObject> botList = new List<GameObject>();
    //public int maxBotCount = 10;

    //private void Awake()
    //{         
    //    GeneratePoints();        
    //}

    //private void Start()
    //{
    //    SpawnInitialBots();
    //}
    //private void Update()
    //{
    //    CheckAndSpawnMoreBots();
    //}

    //private void SpawnInitialBots()
    //{
    //    for (int i = 0; i < maxBotCount; i++)
    //    {
    //        SpawnBot();
    //    }
    //}
    //public void GeneratePoints()   // Duyệt các điểm để bot đi đến lần lượt.
    //{
    //    // Số lượng điểm muốn tạo
    //    int numberOfPoints = 200;

    //    int i = 0;
    //    while (i < numberOfPoints)
    //    {
    //        float randomX = Random.Range(-planeWidth / 2f, planeWidth / 2f);
    //        float randomZ = Random.Range(-planeDepth / 2f, planeDepth / 2f);
    //        float yPosition = 0f;
    //        Vector3 pointPosition = new Vector3(randomX, yPosition, randomZ);
    //        pointList.Add(pointPosition);
      
    //        //Debug.Log(i + ": " + pointList[i]); // In ra giá trị sau khi thêm vào
    //        i++;
    //    }
    //}

    //public void SpawnBot()
    //{
    //    if (botList.Count < maxBotCount)
    //    {
    //        // Chọn một điểm ngẫu nhiên từ danh sách
    //        Vector3 spawnPoint = pointList[Random.Range(0, pointList.Count)];

    //        // Tạo bot tại điểm đã chọn
    //        GameObject newBot = Instantiate(botPrefab, spawnPoint, Quaternion.identity);

    //        // Thêm bot vào danh sách
    //        botList.Add(newBot);
    //    }
    //}

    //// Gọi hàm này khi muốn kiểm tra và spawn thêm bot
    //private void CheckAndSpawnMoreBots()
    //{
    //    if (botList.Count < maxBotCount)
    //    {
    //        SpawnBot();
    //    }
    //}

    // Gọi hàm này khi muốn kiểm tra và spawn thêm bot, có thể là từ một hàm khác hoặc từ Update() chẳng hạn.
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private Player playerPrefab;
    [SerializeField] private LevelDataSO levelDataSO;
    [SerializeField] public GameObject botPrefab;
    [NonSerialized] public Level levelPrefab;
    [NonSerialized] public Player player;
    [NonSerialized] public List<GameObject> botList = new List<GameObject>();
    public List<Vector3> pointList = new List<Vector3>();
    public int maxBotCount = 10;

    public float width = 100;
    public float depth =100;
    public int totalBotSpawn;
    private Level currentLevel;
    public int levelCount;
    public bool finishedLevel = false;

    private void Awake()
    {
        GeneratePoints();
    }

    private void Start()
    {
        LoadLevel();
    }
    private void Update()
    {
        CheckAndSpawnMoreBots();
    }

    public void LoadLevel()
    {
        List<Level> levels = levelDataSO.listLevels;
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }

        currentLevel = Instantiate(levels[levelCount]);
        totalBotSpawn = currentLevel.totalBotSpawn;

        player = playerPrefab;
        player.OnInit();
        player.transform.position = currentLevel.playerSpawnPoint.position;
        SpawnBotAtStart();
    }

    private void SpawnBotAtStart()
    {
        for (int i = 0; i < maxBotCount; i++)
        {
            SpawnBot();
        }
    }
    public void GeneratePoints()   
    {
        // Số lượng điểm muốn tạo
        int numberOfPoints = 200;

        int i = 0;
        while (i < numberOfPoints)
        {
            //width = currentLevel.planeWidth;
            //depth = currentLevel.planeDepth;
            float randomX = UnityEngine.Random.Range(-width / 2f, width / 2f);
            float randomZ = UnityEngine.Random.Range(-depth / 2f, depth / 2f);
            float yPosition = 0f;
            Vector3 pointPosition = new Vector3(randomX, yPosition, randomZ);
            pointList.Add(pointPosition);

            //Debug.Log(i + ": " + pointList[i]); // In ra giá trị sau khi thêm vào
            i++;
        }
    }

    public void SpawnBot()
    {        
            // Chọn một điểm ngẫu nhiên từ danh sách
            Vector3 spawnPoint = pointList[UnityEngine.Random.Range(0, pointList.Count)];
            // Tạo bot tại điểm đã chọn
            GameObject newBot = Instantiate(botPrefab, spawnPoint, Quaternion.identity);
            // Thêm bot vào danh sách
            totalBotSpawn--;
            botList.Add(newBot);              
    }

    // Gọi hàm này khi muốn kiểm tra và spawn thêm bot
    private void CheckAndSpawnMoreBots()
    {
        if (botList.Count < maxBotCount && totalBotSpawn != 0)
        {
            SpawnBot();
        }
        if(botList.Count == 0)
        {
            Debug.Log("Finished Game!");
            finishedLevel = true;
            OnFinish();
        }
    }

    public void OnLose()
    {
        UIManager.Ins.CloseUI<GamePlay>();
        GameManager.ChangeState(GameState.Lose);
        UIManager.Ins.OpenUI<Lose>();
    }
    public void OnFinish()
    {
        GameManager.ChangeState(GameState.Win);
        UIManager.Ins.OpenUI<Win>();
    }


}

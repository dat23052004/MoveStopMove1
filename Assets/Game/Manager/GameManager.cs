using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

public enum GameState { MainMenu, Weapon, Shop, Gameplay, Setting, Pause, Win, Lose }
public class GameManager : Singleton<GameManager>
{
    //[SerializeField] UserData userData;
    //[SerializeField] CSVData csv;
    private static GameState gameState = GameState.MainMenu;
    public UserData UserData;
    // Start is called before the first frame update
    protected void Awake()
    {

        if (SaveManager.Ins.HasData<UserData>())
        {
            Debug.Log("Load Data");
            UserData = SaveManager.Ins.LoadData<UserData>();
        }
        else
        {
            Debug.Log("Created Data");
            UserData = new UserData();
            SaveManager.Ins.SaveData(UserData);
        }
        UIManager.Ins.OpenUI<MianMenu>();
        //ChangeState(GameState.MainMenu);

        Input.multiTouchEnabled = false;
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        int maxScreenHeight = 1280;
        float ratio = (float)Screen.currentResolution.width / (float)Screen.currentResolution.height;
        if (Screen.currentResolution.height > maxScreenHeight)
        {
            Screen.SetResolution(Mathf.RoundToInt(ratio * (float)maxScreenHeight), maxScreenHeight, true);
        }       
    }

    public static void ChangeState(GameState state)
    {
        gameState = state;
    }

    public static bool IsState(GameState state)
    {
        return gameState == state;
    }

}

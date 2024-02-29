using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : UICanvas
{
    public Text score;

    public void MainMenuButton()
    {
        SoundManager.Ins.Sound.Play();
        UIManager.Ins.OpenUI<MianMenu>();
        LevelManager.Ins.LoadLevel();
        GameManager.ChangeState(GameState.MainMenu);
        Close(0);
    }
    public void RetryButton()
    {
        SoundManager.Ins.Sound.Play();
        UIManager.Ins.OpenUI<GamePlay>();
        LevelManager.Ins.LoadLevel();
        GameManager.ChangeState(GameState.Gameplay);
        Close(0);
    }
}

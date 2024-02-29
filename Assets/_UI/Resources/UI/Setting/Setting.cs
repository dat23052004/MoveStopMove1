using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : UICanvas
{
    public void ContinueButton()
    {
        SoundManager.Ins.Sound.Play();
        UIManager.Ins.OpenUI<GamePlay>();
        GameManager.ChangeState(GameState.Gameplay);
        Time.timeScale = 1;
        Close(0);
    }

    public void HomeButton()
    {
        SoundManager.Ins.Sound.Play();
        UIManager.Ins.OpenUI<MianMenu>();
        GameManager.ChangeState(GameState.MainMenu);
        
        Close(0);
    }    
}

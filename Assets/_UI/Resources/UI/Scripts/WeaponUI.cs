using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUI : UICanvas
{
    public void ButtonNext()
    {

    }
    public void CloseButton()
    {
        UIManager.Ins.OpenUI<MianMenu>();
        GameManager.ChangeState(GameState.MainMenu);
        Time.timeScale = 1;
        Close(0);
    }
}
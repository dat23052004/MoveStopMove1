using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MianMenu : UICanvas
{
    public void PlayButton()
    {
        UIManager.Ins.OpenUI<GamePlay>();       
        GameManager.ChangeState(GameState.Gameplay);       
        Time.timeScale = 1;
        Close(0);
    }

    public void WeaponButton()
    {
        UIManager.Ins.OpenUI<WeaponUI>();
        Close(0);
    }   
    
    public void ShopButton()
    {
        UIManager.Ins.Cam_Gameplay.SetActive(false);
        UIManager.Ins.OpenUI<Shop>();
        GameManager.ChangeState(GameState.Shop);
        Close(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MianMenu : UICanvas
{
    public void PlayButton()
    {
        SoundManager.Ins.Sound.Play();
        UIManager.Ins.OpenUI<GamePlay>();       
        GameManager.ChangeState(GameState.Gameplay);       
        Time.timeScale = 1;
        Close(0);
    }

    public void WeaponButton()
    {
        SoundManager.Ins.Sound.Play();
        UIManager.Ins.OpenUI<WeaponUI>();
        Close(0);
    }   
    
    public void ShopButton()
    {
        SoundManager.Ins.Sound.Play();
        UIManager.Ins.Cam_Gameplay.SetActive(false);
        UIManager.Ins.OpenUI<Shop>();
        GameManager.ChangeState(GameState.Shop);
        Close(0);
    }
}

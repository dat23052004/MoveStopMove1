using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUI : UICanvas
{
    private void Start()
    {
        LevelManager.Ins.player.ChangeAnim(Constant.ANIM_DANCE);
    }
    public void ButtonNext()
    {

    }
    public void CloseButton()
    {
        SoundManager.Ins.Sound.Play();
        UIManager.Ins.OpenUI<MianMenu>();
        GameManager.ChangeState(GameState.MainMenu);
        UIManager.Ins.Cam_Gameplay.SetActive(true);
        Time.timeScale = 1;
        Close(0);
    }
}

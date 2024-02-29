using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : UICanvas
{
    public void SettingButton()
    {
        SoundManager.Ins.Sound.Play();
        UIManager.Ins.OpenUI<Setting>();
        GameManager.ChangeState(GameState.Setting);
        // Sau khi sửa về pooling bot thì Instance changeAnim về idle.
        Time.timeScale = 0;
        
        Close(0);
    }
}

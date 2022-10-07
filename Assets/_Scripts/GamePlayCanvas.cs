using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayCanvas : UIBase
{
    //Bholeshvar Mahadev
    
    public void GameOver()
    {
        ScreenManager.instance.OpenScreen(ScreenType.GameOver);
    }
    
}


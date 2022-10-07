using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvas : UIBase
{
    public void Play()
    {
        ScreenManager.instance.OpenScreen(ScreenType.GamePlay);
    }
    
}

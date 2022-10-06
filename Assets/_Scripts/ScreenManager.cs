using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public List<Screen> listOfScreen;
    public enum ScreenType
    {
        MainMenu,
        GamePlay,
        Pause,
        GameOver
    }

    private void Start()
    {
        OnClickMainMenu();
    }
    [System.Serializable]
    public class Screen
    {
        public ScreenType screenType;
        public Canvas canvas;
    }

    public void OnClickGamePlayScreen()
    {
        SetScreen((int)ScreenType.GamePlay);
    }
    public void GameOver()
    {
        SetScreen((int)ScreenType.GameOver);
    }
    public void OnClickPause()
    {
        SetScreen((int)ScreenType.Pause);
    }

    public void OnClickResume()
    {
        SetScreen((int)ScreenType.GamePlay);
    }
    public void OnClickMainMenu()
    {
        SetScreen((int)ScreenType.MainMenu);
    }
    public void SetScreen(int index)
    {
        for (int i = 0; i < listOfScreen.Count; i++)
        {
            if ((int)listOfScreen[i].screenType == index)
            {
                listOfScreen[i].canvas.enabled = true;
            }
            else
            {
                listOfScreen[i].canvas.enabled = false;
            }
        }
    }
}

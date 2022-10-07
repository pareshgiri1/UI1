using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum ScreenType
    {
        MainMenu,
        GamePlay,
        Pause,
        GameOver
    }
public class ScreenManager : MonoBehaviour
{
    #region Singletone
    public static ScreenManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public List<Screen> listOfScreen;

    private void Start()
    {
        StartEnable();
    }

    [System.Serializable]
    public struct Screen
    {
        public ScreenType screenType;
        public Canvas canvas;
    }

    Screen currenetScreen;

    public void StartEnable()
    {
        OpenScreen(ScreenType.MainMenu);
    }
    public void OpenScreen(ScreenType screenType)
    {
        if(currenetScreen.canvas != null)
        {
            currenetScreen.canvas.enabled = false;
        }
        for (int i = 0; i < listOfScreen.Count; i++)
        {
            if (listOfScreen[i].screenType == screenType)
            {
                //listOfScreen[i].canvas.enabled = true;
                currenetScreen.canvas = listOfScreen[i].canvas;
                break;
            }
        }
        currenetScreen.canvas.enabled = true;
    }
}

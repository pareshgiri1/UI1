using System.Collections.Generic;
using UnityEngine;


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
        //public Canvas canvas;
        public UIBase uIBase;
    }

    Screen currenetScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PopUpManager.instance.currenetPopUp.uIBase == null)
            {
                currenetScreen.uIBase.Back();
            }
            else
            {
                PopUpManager.instance.currenetPopUp.uIBase.Back();
                
            }
        }
    }
    public void StartEnable()
    {
        OpenScreen(ScreenType.MainMenu);
    }
    public void OpenScreen(ScreenType screenType)
    {
        if (currenetScreen.uIBase != null)
        {
            //currenetScreen.canvas.enabled = false;
            currenetScreen.uIBase.Hide();
        }
        for (int i = 0; i < listOfScreen.Count; i++)
        {
            if (listOfScreen[i].screenType == screenType)
            {
                currenetScreen = listOfScreen[i];
                break;
            }
        }
        currenetScreen.uIBase.Show();
    }
    public Screen GetCurrentScreen()
    {
        return currenetScreen;
    }
}


public enum ScreenType
{
    MainMenu,
    GamePlay,
    GameOver
}

public enum Direction
{
    Left,
    Right,
    Up,
    Down
}

public enum Transition
{
    Forward,
    Reverse
}
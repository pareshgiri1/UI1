using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PopUpType
{
    Pause,
    Setting
}
public class PopUpManager : MonoBehaviour
{

    #region Singletone
    public static PopUpManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public List<PopUp> listOfPopUp;
    [System.Serializable]
    public struct PopUp
    {
        public PopUpType popUpType;
        public UIBase uIBase;
    }
    public PopUp currenetPopUp;
    
    public void OpenPopUp(PopUpType popUpType)
    {
        for (int i = 0; i < listOfPopUp.Count; i++)
        {
            if (listOfPopUp[i].popUpType == popUpType)
            {
                currenetPopUp = listOfPopUp[i];
                //listOfPopUp[i].uIBase.Show(); ;
                break;
            }
        }
        currenetPopUp.uIBase.Show();
    }


}
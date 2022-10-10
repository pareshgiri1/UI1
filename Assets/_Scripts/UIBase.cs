using System.Collections;
using UnityEngine;

public class UIBase : Base
{
    public override void Back()
    {

    }

    //Bholeshvar Mahadev
    public override void Hide()
    {
        StartCoroutine(DelayHide());
        if (PopUpManager.instance.currenetPopUp.uIBase != null)
        {
            PopUpManager.instance.currenetPopUp.uIBase = null;
        }
    }
    public override void Show()
    {
        canvas.enabled = true;
        foreach (var item in uiAnimatePositions)
        {
            item.ShowAnimation();
        }
    }
    IEnumerator DelayHide()
    {
        foreach (var item in uiAnimatePositions)
        {
            item.HideAnimation();
        }
        yield return new WaitForSeconds(0.5f);
        canvas.enabled = false;
    }


}

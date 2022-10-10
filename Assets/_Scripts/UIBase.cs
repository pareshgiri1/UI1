using System.Collections;
using UnityEngine;

public class UIBase : Base
{
    //Bholeshvar Mahadev
    public override void Hide()
    {
        StartCoroutine(DelayHide());
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvas : UIBase
{
    public UiAnimatePosition uiAnimatePosition;
    public override void Hide()
    {
        StartCoroutine(DelayHide());
    }

    public override void Show()
    {
        StartCoroutine(DelayShow());
    }
    public void Play()
    {
        ScreenManager.instance.OpenScreen(ScreenType.GamePlay);
    }
    IEnumerator DelayHide()
    {
        yield return StartCoroutine(uiAnimatePosition.Animation()); ;
       // canvas.enabled = false;
    }

    IEnumerator DelayShow()
    {
        //canvas.enabled = true;
        yield return StartCoroutine(uiAnimatePosition.AnimationReverse());
    }
}

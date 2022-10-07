using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseCanvas : UIBase
{
    //Bholeshvar Mahadev
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
        yield return StartCoroutine(uiAnimatePosition.SlideOut());
        Play();
        uiAnimatePosition.rect.position = uiAnimatePosition.startPosition;
        canvas.enabled = false;
    }

    IEnumerator DelayShow()
    {
        canvas.enabled = true;
        yield return StartCoroutine(uiAnimatePosition.SlideIn());
    }
}

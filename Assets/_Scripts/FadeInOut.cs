using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class FadeInOut : AnimationBase
{
    public CanvasGroup canvasGroup;
    public override void HideAnimation()
    {
        StartCoroutine(FadeOut());
    }

    public override void ShowAnimation()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        timer = 0;
        while (timer < showTime)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, timer / showTime);
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        timer = 0;
        while (timer < hideTime)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, timer / hideTime);
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnimatePosition : AnimationBase
{


    private RectTransform rect;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        startPosition = rect.anchoredPosition;
        rect.anchoredPosition = targetPosition;
    }
    IEnumerator SlideOut()
    {
        timer = 0;
        while (timer < hideTime)
        {
            timer += Time.deltaTime;
            rect.anchoredPosition = Vector3.Lerp(startPosition, targetPosition, timer / hideTime);
            yield return null;
        }
    }
    IEnumerator SlideIn()
    {
        timer = 0;
        while (timer < showTime)
        {
            timer += Time.deltaTime;
            rect.anchoredPosition = Vector3.Lerp(targetPosition, startPosition, timer / showTime);
            yield return null;
        }
    }

    public override void ShowAnimation()
    {
        StartCoroutine(SlideIn());
    }

    public override void HideAnimation()
    {
        StartCoroutine(SlideOut());
    }
}
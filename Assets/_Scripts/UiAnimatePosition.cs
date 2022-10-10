using System.Collections;
using UnityEngine;

public class UiAnimatePosition : AnimationBase
{
    private RectTransform rect;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    public int layer;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        startPosition = rect.localPosition;
        rect.localPosition = targetPosition;
    }
    IEnumerator SlideOut()
    {
       
        timer = 0;
        while (timer < hideTime)
        {
            timer += Time.deltaTime;
            rect.localPosition = Vector3.Lerp(startPosition, targetPosition, timer / hideTime);
            yield return null;
        }
    }
    IEnumerator SlideIn()
    {
        yield return new WaitForSeconds(layer * showTime/2);
        timer = 0;
        while (timer < showTime)
        {
            timer += Time.deltaTime;
            rect.localPosition = Vector3.Lerp(targetPosition, startPosition, timer / showTime);
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
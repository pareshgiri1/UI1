using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUpDown : AnimationBase
{
    private RectTransform rect;
    private Vector3 startScale;
    private Vector3 endScale;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        startScale = rect.localScale;
        endScale = new Vector3(0, 0, 0);
    }
    public override void HideAnimation()
    {
        StartCoroutine(ScaleUp());
    }

    public override void ShowAnimation()
    {
        StartCoroutine(ScaleDown());
    }

    IEnumerator ScaleUp()
    {
        timer = 0;

        while (timer < hideTime)
        {
            timer += Time.deltaTime;
            rect.localScale = Vector3.Lerp(startScale,Vector3.one*5,animationCurve.Evaluate(timer/hideTime));
            yield return null;
        }
    }

    IEnumerator ScaleDown()
    {
        timer = 0;
        while (timer < showTime)
        {
            timer += Time.deltaTime;
            rect.localScale = Vector3.Lerp( endScale, startScale, animationCurve.Evaluate(timer / showTime));
            yield return null;
        }
    }
}

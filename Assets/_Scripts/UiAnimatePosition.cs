using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnimatePosition : MonoBehaviour
{
    float estimate = 0.5f;
    float timer = 0f;
    float ptc = 0f;
    public RectTransform rect;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    private void Awake()
    {
        rect.anchoredPosition3D = targetPosition;
    }
    public void OnClickAnimation()
    {
        StartCoroutine(SlideOut());
    }
    public IEnumerator SlideOut()
    {
        timer = 0;
        startPosition = rect.anchoredPosition;
        while (timer < estimate)
        {
            timer += Time.deltaTime;
            ptc = timer / estimate;
            rect.anchoredPosition3D = Vector3.Lerp(startPosition, targetPosition, ptc);
            yield return null;
        }
    }
    public IEnumerator SlideIn()
    {
        timer = 0;
        float estimate = 1f;
        startPosition = rect.anchoredPosition3D;
        while (timer < estimate)
        {
            timer += Time.deltaTime;
            ptc = timer / estimate;
            rect.anchoredPosition3D = Vector3.Lerp(startPosition, new Vector3(0, 0, 0), ptc);
            yield return null;
        }
    }
}
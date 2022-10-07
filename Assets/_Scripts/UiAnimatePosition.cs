using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnimatePosition : MonoBehaviour
{
    
    float estimate = 1f;
    float timer = 0f;
    float ptc = 0f;
    public RectTransform rect;
    Vector3 startPosition;
    
    public Vector3 targetPosition;
    public void OnClickAnimation()
    {
        StartCoroutine(Animation());
    }
    public IEnumerator Animation()
    {
        timer = 0;
        startPosition = rect.anchoredPosition3D;
        Debug.Log(startPosition);
        while (timer < estimate)
        {
            timer += Time.deltaTime;
            ptc = timer / estimate;
            rect.anchoredPosition3D = Vector3.Lerp(startPosition, targetPosition, ptc);
            yield return null;
        }
        startPosition = rect.anchoredPosition3D;
        Debug.Log(startPosition);
    }

    public IEnumerator AnimationReverse()
    {
        timer = 0;
        float estimate = 1f;
        startPosition = rect.anchoredPosition3D;
        Debug.Log(startPosition);
        Debug.Log(rect.anchoredPosition3D);
        while (timer < estimate)
        {
            timer += Time.deltaTime;
            ptc = timer / estimate;
            rect.anchoredPosition3D = Vector3.Lerp(startPosition,new Vector3(0,0,0), ptc);
            yield return null;
        }
    }
}
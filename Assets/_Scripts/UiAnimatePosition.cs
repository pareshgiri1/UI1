using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnimatePosition : MonoBehaviour
{
    
    float estimate = 5f;
    float timer = 0f;
    float ptc = 0f;
    public RectTransform rect;
    Vector3 startPosition;
    //public Vector2 positions;
    private void Start()
    {
        StartCoroutine(Animation());
    }
    public Vector3 targetPosition;
    IEnumerator Animation()
    {
        timer = 0;
        startPosition = rect.anchoredPosition3D;
        
        while (timer < estimate)
        {
            timer += Time.deltaTime;
            ptc = timer / estimate;
            rect.anchoredPosition3D = Vector3.Lerp(startPosition, targetPosition, ptc);
            yield return null;
        }
    }


}
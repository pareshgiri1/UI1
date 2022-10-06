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
    public Vector3 targetPosition;
    IEnumerator Animation()
    {
        #region if
        //if (y > 0)
        //{
        //    while (y > 0)
        //    {
        //        y -= change * 2;
        //        shopRect.anchoredPosition3D = new Vector3(shopRect.anchoredPosition3D.x, y, shopRect.anchoredPosition3D.z);
        //        Debug.Log(y);
        //        yield return new WaitForSeconds(0.1f);
        //    }
        //}
        //else if (y <= 0)
        //{
        //    while (y < Screen.height)
        //    {
        //        y += change * 2;
        //        shopRect.anchoredPosition3D = new Vector3(shopRect.anchoredPosition3D.x, y, shopRect.anchoredPosition3D.z);
        //        Debug.Log(y);
        //        yield return new WaitForSeconds(0.1f);
        //    }

        //}
        #endregion
        timer = 0;
        startPosition = rect.anchoredPosition3D;
        
            //targetPosition = new Vector3(targetPositionX, rect.anchoredPosition3D.y, rect.anchoredPosition3D.z);
        
        while (timer < estimate)
        {
            timer += Time.deltaTime;
            ptc = timer / estimate;
            rect.anchoredPosition3D = Vector3.Lerp(startPosition, targetPosition, ptc);
            yield return null;
        }
    }


}
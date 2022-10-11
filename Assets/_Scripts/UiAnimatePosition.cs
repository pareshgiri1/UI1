using System.Collections;
using UnityEngine;

public class UiAnimatePosition : AnimationBase
{
    private RectTransform rect;
    Vector3 startPosition;
    public Direction direction;
    public Transition transition;
    Vector3 targetPosition;
    public int layer;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        startPosition = rect.localPosition;
        SettargetPosition(direction);
        SetTransition(transition,direction);
        rect.localPosition = targetPosition;//new Vector3(targetPosition.x,startPosition.y,startPosition.z);
    }
    float xMult ;
    float yMult ;
    public void SetTransition(Transition transition,Direction animation)
    {
        //switch (transition)
        //{
        //    case Transition.Forward:
        //        xMult = 1f;
        //        yMult = 1f;
        //        break;

        //    case Transition.Reverse  :
                
        //        xMult = 1f;
        //        yMult = -1;
        //        break;
        //}
        
        if( (Direction.Left == animation || Direction.Right == animation ) && Transition.Reverse == transition)
        {
            xMult = -1f;
            yMult = 1f;
        }
        else if ((Direction.Up == animation || Direction.Down == animation) && Transition.Reverse == transition)
        {
            xMult = 1f;
            yMult = -1f;
        }
        else
        {
            xMult = yMult =1f;
        }

    }
    public void SettargetPosition(Direction animation)
    {
        switch (animation)
        {
            case Direction.Left:
                targetPosition = new Vector3(Screen.width * 2, startPosition.y, startPosition.z);
                break;
            case Direction.Right:
                targetPosition = new Vector3(-Screen.width * 2, startPosition.y, startPosition.z);
                break;
            case Direction.Up:
                targetPosition = new Vector3(startPosition.x, -Screen.height * 2, startPosition.z);
                break;
            case Direction.Down:
                targetPosition = new Vector3(startPosition.x, Screen.height * 2, startPosition.z);
                break;

        }
    }
    IEnumerator SlideOut()
    {
        targetPosition = new Vector3(targetPosition.x * xMult, targetPosition.y * yMult, targetPosition.z * yMult);
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
        targetPosition = new Vector3(targetPosition.x * xMult, targetPosition.y * yMult, targetPosition.z * yMult);
        yield return new WaitForSeconds(layer * showTime / 2);
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
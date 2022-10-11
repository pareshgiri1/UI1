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
        rect.localPosition = targetPosition;
    }
    float xMult = 1;
    float yMult = 1;
    public void SettargetPosition(Direction animation)
    {
        switch (animation)
        {
            case Direction.Left:
                
                xMult = Transition.Reverse == transition ? -1f : 1;
                targetPosition = new Vector3(Screen.width * 2, startPosition.y, startPosition.z);
                break;
            case Direction.Right:
                xMult = Transition.Reverse == transition ? -1f : 1;
                targetPosition = new Vector3(-Screen.width * 2, startPosition.y, startPosition.z);
                break;
            case Direction.Up:
                yMult = Transition.Reverse == transition ? -1f : 1;
                targetPosition = new Vector3(startPosition.x, -Screen.height * 2, startPosition.z);
                break;
            case Direction.Down:
                yMult = Transition.Reverse == transition ? -1f : 1;
                targetPosition = new Vector3(startPosition.x, Screen.height * 2, startPosition.z);
                break;

        }
    }
    IEnumerator SlideOut()
    {
        targetPosition = new Vector3(targetPosition.x * xMult, targetPosition.y * yMult, targetPosition.z);
        timer = 0;
        while (timer < hideTime)
        {
            timer += Time.deltaTime;
            rect.localPosition = Vector3.Lerp(startPosition, targetPosition, animationCurve.Evaluate(timer / hideTime));
            yield return null;
        }
    }
    IEnumerator SlideIn()
    {
        targetPosition = new Vector3(targetPosition.x * xMult, targetPosition.y * yMult, targetPosition.z);
        yield return new WaitForSeconds(layer * showTime / 2);
        timer = 0;
        while (timer < showTime)
        {
            timer += Time.deltaTime;
            rect.localPosition = Vector3.Lerp(targetPosition, startPosition, animationCurve.Evaluate(timer / showTime));
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
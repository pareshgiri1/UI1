using UnityEngine;

public abstract class AnimationBase : MonoBehaviour
{
    public float showTime = 0.5f;
    [HideInInspector]
    public float hideTime = 0.5f;
    [HideInInspector]
    public float timer = 0f;
    public AnimationCurve animationCurve;
    public abstract void ShowAnimation();
    public abstract void HideAnimation();
}


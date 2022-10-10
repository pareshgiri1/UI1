using UnityEngine;

public abstract class AnimationBase : MonoBehaviour
{
    //Bholeshvar Mahadev
    public float showTime = 0.5f;
    public float hideTime = 0.5f;
    public float timer = 0f;

    public abstract void ShowAnimation();
    public abstract void HideAnimation();
}

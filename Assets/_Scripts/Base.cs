using System.Collections.Generic;
using UnityEngine;

public abstract class Base : MonoBehaviour
{
    //Bholeshvar Mahadev

    public Canvas canvas;

    public List<AnimationBase> uiAnimatePositions;

    public abstract void Hide();

    public abstract void Show();
}

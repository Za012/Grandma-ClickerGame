using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTween : MonoBehaviour
{
    private bool isOpen = false;

    public void manageLetter()
    {
        if (!isOpen)
        {
            LeanTween.scale(gameObject, new Vector3(-592,-212,0), 0.5f);
            isOpen = true;
        }
        else
        {
            LeanTween.scale(gameObject, new Vector3(0, 0, 0), 0.5f);
        }
    }
}

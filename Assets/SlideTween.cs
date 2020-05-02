using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTween : MonoBehaviour
{
    private bool storeOpen = false;
    public void manageStore()
    {
        if (!storeOpen)
        {
            LeanTween.moveX(gameObject, -4, 0.5f);
            storeOpen = true;
            SoundScript.Instance.PlaySound("drawer_open");
        }
        else
        {
            LeanTween.moveX(gameObject, -782, 0.5f);
            storeOpen = false;
            SoundScript.Instance.PlaySound("drawer_close");
        }
    }
}

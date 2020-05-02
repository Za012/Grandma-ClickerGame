using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Touch_UI : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Clicked on the UI");
            }
        }
    }
}
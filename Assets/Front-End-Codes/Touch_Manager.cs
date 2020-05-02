using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// CODE FOR TESTING PURPOSE ONLY!!! (MOBILE TAPPING )
// CODE FOR TESTING PURPOSE ONLY!!! (MOBILE TAPPING )
// CODE FOR TESTING PURPOSE ONLY!!! (MOBILE TAPPING )
// CODE FOR TESTING PURPOSE ONLY!!! (MOBILE TAPPING )

public class Touch_Manager : MonoBehaviour
{
    public Text tCount;
    private Touch theTouch;

    void Update()
    {
        tCount.text = Input.GetMouseButton(0).ToString();
    }
}

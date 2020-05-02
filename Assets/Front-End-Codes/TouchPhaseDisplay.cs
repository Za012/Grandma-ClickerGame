using UnityEngine;
using UnityEngine.UI;
// CODE FOR TESTING PURPOSE ONLY!!! (MOBILE TAPPING )
// CODE FOR TESTING PURPOSE ONLY!!! (MOBILE TAPPING )
// CODE FOR TESTING PURPOSE ONLY!!! (MOBILE TAPPING )
// CODE FOR TESTING PURPOSE ONLY!!! (MOBILE TAPPING )

public class TouchPhaseDisplay : MonoBehaviour
{
    public Text phaseDisplayText;
    private Touch theTouch;
    private float timeTouchEnded;
    private float displayTime = .5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            phaseDisplayText.text = theTouch.phase.ToString();

            if (theTouch.phase == TouchPhase.Ended)
            {
                timeTouchEnded = Time.time;
            }
        }

        else if (Time.time - timeTouchEnded > displayTime)
        {
            phaseDisplayText.text = "";
        }
    }
}

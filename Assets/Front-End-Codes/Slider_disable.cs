using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class Slider_disable : MonoBehaviour
{
    public Slider mainSlider;
    public GameObject disableimg;


    public void DisableImageActivate()
    {

        if (mainSlider.value == 0)
        {
            disableimg.SetActive(true);
        }
        else if (mainSlider.value > 0)
        {
            disableimg.SetActive(false);
        }
    }
}
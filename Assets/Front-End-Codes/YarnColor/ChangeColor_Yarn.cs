using UnityEngine;
using UnityEngine.UI;

public class ChangeColor_Yarn : MonoBehaviour
{
    public Image image;

    public static ChangeColor_Yarn Instance;

    private void Awake()
    {
        GameObject screen = GameObject.Find("Canvas");
        Instance = screen.transform.Find("Button_Yarn_Color").gameObject.GetComponent<ChangeColor_Yarn>();
    }

    public void ChangeToRed()
    {
        Color newColor = new Color(255, 0, 0);
        image.color = newColor;
    }
    public void ChangeToBlue()
    {
        Color newColor = new Color(0, 0, 255);
        image.color = newColor;
    }
    public void ChangeToGreen()
    {
        Color newColor = new Color(0, 255, 0);
        image.color = newColor;
    }
    public void ChangeToYellow()
    {
        Color newColor = new Color(245, 255, 0);
        image.color = newColor;
    }
}

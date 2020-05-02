using UnityEngine;
using UnityEngine.UI;

public class Button_Green : MonoBehaviour
{
    public Button button;

    public void Start()
    {
        button.onClick.AddListener(ChangeSpriteColor);
    }

    public void ChangeSpriteColor()
    {
        ChangeColor_Item.Instance.ChangeToGreen();
        ChangeColor_Yarn.Instance.ChangeToGreen();
    }

}

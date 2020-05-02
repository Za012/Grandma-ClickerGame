using UnityEngine;
using UnityEngine.UI;

public class Button_Blue : MonoBehaviour
{
    public Button button;

    public void Start()
    {
        button.onClick.AddListener(ChangeSpriteColor);
    }

    public void ChangeSpriteColor()
    {
        ChangeColor_Item.Instance.ChangeToBlue();
        ChangeColor_Yarn.Instance.ChangeToBlue();
    }

}

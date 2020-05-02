using UnityEngine;
using UnityEngine.UI;

public class Button_Red : MonoBehaviour
{
    public Button button;

    public void Start()
    {
        button.onClick.AddListener(ChangeSpriteColor);
    }

    public void ChangeSpriteColor()
    {
        ChangeColor_Item.Instance.ChangeToRed();
        ChangeColor_Yarn.Instance.ChangeToRed();
    }

}

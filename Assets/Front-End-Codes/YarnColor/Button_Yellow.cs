using UnityEngine;
using UnityEngine.UI;

public class Button_Yellow : MonoBehaviour
{
    public Button button;

    public void Start()
    {
        button.onClick.AddListener(ChangeSpriteColor);
    }

    public void ChangeSpriteColor()
    {
        ChangeColor_Item.Instance.ChangeToYellow();
        ChangeColor_Yarn.Instance.ChangeToYellow();
    }

}

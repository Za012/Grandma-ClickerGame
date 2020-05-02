using UnityEngine;
using UnityEngine.UI;

public class Button_On_Off : MonoBehaviour
{
    public Sprite OffSprite;
    public Sprite OnSprite;
    public Button but;

    private SoundScript m_soundScript = null;

    private void Awake()
    {
        m_soundScript = GameObject.Find("Sound").GetComponent<SoundScript>();
    }

    public void ChangeImage()
    {
        if (but.image.sprite == OnSprite) { 
            but.image.sprite = OffSprite;
            m_soundScript.PlaySound("button_off"); 
        }
        else
        {
            but.image.sprite = OnSprite;
            m_soundScript.PlaySound("button_on");
        }
    }
}


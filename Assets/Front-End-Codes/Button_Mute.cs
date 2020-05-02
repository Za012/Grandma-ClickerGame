using UnityEngine;
using UnityEngine.UI;

public class Button_Mute : MonoBehaviour
{
    public Sprite OffSprite;
    public Sprite OnSprite;
    public Button but;
    public AudioListener a;

    private SoundScript m_soundScript = null;

    private void Awake()
    {
        m_soundScript = GameObject.Find("Sound").GetComponent<SoundScript>();
    }

    public void ChangeImage()
    {
        if (but.image.sprite == OnSprite) {
            AudioListener.volume = 0; 
            but.image.sprite = OffSprite;
            m_soundScript.PlaySound("button_off"); 
        }
        else
        {
            AudioListener.volume = 1;
            but.image.sprite = OnSprite;
            m_soundScript.PlaySound("button_on");
        }
    }
}


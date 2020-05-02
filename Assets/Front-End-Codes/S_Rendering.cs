using UnityEngine;

public class S_Rendering : MonoBehaviour
{
    private S_Rendering()
    {

    }
    public static S_Rendering Instance;

    private SpriteRenderer rend;

    private void Awake()
    {
        Instance = GameObject.Find("Sprite_Item").GetComponent<S_Rendering>();
        rend = GameObject.Find("Sprite_Item").GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite(int percentage)
    {
        string[] spritePath = SaveFile.GetInstance().CoreConfig.currentItem.GetSprites();

        switch (percentage)
        {
            case int n when (n < 15):
                rend.sprite = Resources.Load<Sprite>(spritePath[0]);
                break;
            case int n when (n < 30):
                rend.sprite = Resources.Load<Sprite>(spritePath[1]);
                break;
            case int n when (n < 50):
                rend.sprite = Resources.Load<Sprite>(spritePath[2]);
                break;
            case int n when (n < 75):
                rend.sprite = Resources.Load<Sprite>(spritePath[3]);
                break;
            case int n when (n < 90):
                rend.sprite = Resources.Load<Sprite>(spritePath[4]);
                break;
            case int n when (n < 99):
                rend.sprite = Resources.Load<Sprite>(spritePath[5]);
                break;
            default:
                rend.sprite = Resources.Load<Sprite>(spritePath[0]);
                break;
        }
    }
}

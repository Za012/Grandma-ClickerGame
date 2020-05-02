using UnityEngine;

public class ChangeColor_Item : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public static ChangeColor_Item Instance;

    private void Awake()
    {
        GameObject screen = GameObject.Find("Screen");
        Instance = screen.transform.Find("Sprite_Item").gameObject.GetComponent<ChangeColor_Item>();
    }

    public void ChangeToRed()
    {
        Color newColor = new Color(255, 0, 0);
        spriteRenderer.color = newColor;
    }
    public void ChangeToBlue()
    {
        Color newColor = new Color(0, 0, 255);
        spriteRenderer.color = newColor;
    }
    public void ChangeToGreen()
    {
        Color newColor = new Color(0, 255, 0);
        spriteRenderer.color = newColor;
    }
    public void ChangeToYellow()
    {
        Color newColor = new Color(245, 255, 0);
        spriteRenderer.color = newColor;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Menu_Tog_Dis_G : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Grandma;
    public Button ButtonToDeactivate;
    public Button ButtonToDeactivate2;

    public static Menu_Tog_Dis_G Instance;
    private void Awake()
    {
        Instance = GameObject.Find("Button_Letter").GetComponent<Menu_Tog_Dis_G>();
    }

    private void Start()
    {
        GameObject itemObject = GameObject.Find("Button_Item");
        Image image = itemObject.GetComponent<Image>();
        image.sprite = Resources.Load<Sprite>(SaveFile.GetInstance().CoreConfig.currentItem.GetUniversalSprite());
    }
    public void OpenMenu()
    {
        if (Menu != null)
        {
            Menu.SetActive(!Menu.activeSelf);
            Grandma.SetActive(!Grandma.activeSelf);
            ButtonToDeactivate.interactable = !ButtonToDeactivate.interactable;
            ButtonToDeactivate2.interactable = !ButtonToDeactivate2.interactable;
        }
    }
}

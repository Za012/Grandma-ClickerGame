using UnityEngine;

public class Menu_Toggler : MonoBehaviour
{
    public GameObject Menu;

    public void OpenMenu()
    {
        if (Menu != null)
        {
            Menu.SetActive(!Menu.activeSelf);
        }
    }

}

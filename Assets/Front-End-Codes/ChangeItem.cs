using UnityEngine;
using UnityEngine.UI;

public class ChangeItem : MonoBehaviour
{
    public Button button;
    public Image image;

    public void Itemchanger(string itemToSwitch)
    {
        foreach (IItemObservable item in SaveFile.GetInstance().CoreConfig.items)
        {
            if (item.GetName() == itemToSwitch)
            {
                SaveFile.GetInstance().CoreConfig.currentItem = item;
                SaveFile.GetInstance().CoreConfig.itemInventory.UpdateItemProgressNumber(item);
                image.sprite = Resources.Load<Sprite>(SaveFile.GetInstance().CoreConfig.currentItem.GetUniversalSprite());
                return;
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class PowerItemRow : MonoBehaviour
{
    public int itemId;
    public Button buyButton;
    public Text title;
    public Text price;
    public int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        buyButton.onClick.AddListener(OnBuyButtonClick);
    }

    public void OnBuyButtonClick()
    {
        ItemController.Instance.PurchaseItem(itemId, currentLevel, this);
    }

    public void ChangeTitle(string title,int level)
    {
        currentLevel = level;
        this.title.text = $"{title} \n Level {level}";
    }

    internal void ChangeIcon(Sprite sprite)
    {
       buyButton.image.sprite = sprite;
    }

    public void ChangePrice(string price)
    {
        this.price.text = price;
    }
}

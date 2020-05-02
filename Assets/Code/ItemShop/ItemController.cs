using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    private List<Power> storeItem = new List<Power>();
    public static ItemController Instance;

    public PowerItemRow prefab;
    
    // Start is called before the first frame update
    public void Awake()
    {
        Instance = GameObject.Find("ItemController").GetComponent<ItemController>();
        storeItem = new List<Power>();

        string json = Resources.Load<TextAsset>($"PowerItems/{storeItem.Count}").ToString();
        while (!string.IsNullOrEmpty(json))
        {
            Power mission = JsonConvert.DeserializeObject<Power>(json);
            storeItem.Add(mission);
            TextAsset asset = Resources.Load<TextAsset>($"PowerItems/{storeItem.Count}");
            if (asset != null)
            {
                json = asset.ToString();
            }
            else
            {
                json = "";
            }
        }
    }

    private void Start()
    {
        int initY = 40;
        foreach (Power row in storeItem)
        {
            PowerItemRow ui_row = Instantiate(prefab, transform);

            ui_row.gameObject.transform.position += new Vector3(0, initY, 0);
            ui_row.gameObject.SetActive(true);
            ui_row.itemId = row.itemId;

            UpdateItemPrefab(ui_row, row);

            initY -= 105;
        }
    }
    public void UpdateItemPrefab(PowerItemRow ui_row, Power row)
    {
        int currentLevel;
        PowerItem playerItem = SaveFile.GetInstance().CoreConfig.player.powerItems.Find(x => x.powerId == row.itemId);
        if (playerItem == null || row.maxLevel == 0)
        {
            currentLevel = 1;
        }
        else
        {
            currentLevel = playerItem.powerLevel;
        }
        ui_row.ChangeTitle(row.itemName, currentLevel);
        ui_row.ChangeIcon(row.GetItemIcon());
        ui_row.ChangePrice(row.cost.ToString());
    }
    public Power ReadPowerItem(int id)
    {
        return storeItem[id];
    }

    public void PurchaseItem(int id, int level, PowerItemRow ui_row)
    {
        Power item = ReadPowerItem(id);
        if (level >= item.maxLevel)
            return;
        if (SaveFile.GetInstance().CoreConfig.player.ChargeGold(item.cost))
        {
            SaveFile.GetInstance().CoreConfig.player.AddPowerItem(id, level);
            UpdateItemPrefab(ui_row,item);
        }
    }
}

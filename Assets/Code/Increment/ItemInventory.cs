using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemInventory : IMissionObservable
{
    private Dictionary<IItemObservable, int> inventory;

    public Dictionary<IItemObservable, int> GetInventory()
    {
        return inventory;
    }
    public ItemInventory()
    {
        inventory = new Dictionary<IItemObservable, int>();
    }
    public int GetItemAmount(IItemObservable key)
    {
        return inventory[key];
    }

    public void Increment(IItemObservable item)
    {
        inventory[item]++;
        Text itemProgressNumber = GameObject.Find("ItemAmountText").GetComponent<Text>();
        itemProgressNumber.text = inventory[item].ToString();
        MissionObserver.GetInstance().IsComplete(item);
    }

    public void Decrement(string itemName, int amount)
    {
        foreach (KeyValuePair<IItemObservable, int> pair in inventory)
        {
            if (pair.Key.GetName() == itemName)
            {
                inventory[pair.Key] -= amount;

                // Can't get current item yet...
                /*                Text itemProgressNumber = GameObject.Find("ItemAmountText").GetComponent<Text>();
                                itemProgressNumber.text = inventory[item].ToString();*/
                return;
            }
        }
    }

    public IItemObservable GetItemByName(string itemName)
    {
        foreach (KeyValuePair<IItemObservable, int> pair in inventory)
        {
            if (pair.Key.GetName() == itemName)
            {
                return pair.Key;
            }
        }
        return null;
    }

    public void ResetInventory()
    {
        inventory = new Dictionary<IItemObservable, int>();
    }

    public void UpdateItemProgressNumber(IItemObservable item)
    {
        Text itemProgressNumber = GameObject.Find("ItemAmountText").GetComponent<Text>();
        itemProgressNumber.text = inventory[item].ToString();
    }
}

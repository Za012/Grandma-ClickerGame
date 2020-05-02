using System;
using System.Collections.Generic;

[Serializable]
public class Player
{
    private int gold;
    private double baseMultiplier;
    public List<PowerItem> powerItems;

    public Player()
    {
        baseMultiplier = 0.2;
        gold = 0;
        powerItems = new List<PowerItem>();
    }

    public double GetIdleMultiplier()
    {
        double idleMultiplier = baseMultiplier;
        foreach (PowerItem item in powerItems)
        {
            Power power = ItemController.Instance.ReadPowerItem(item.powerId);
            idleMultiplier += power.idleStrength[item.powerLevel-1];
        }
        return idleMultiplier;
    }

    public double GetTapMultiplier()
    {
        double tapMultiplier = baseMultiplier;
        foreach (PowerItem item in powerItems)
        {
            Power power = ItemController.Instance.ReadPowerItem(item.powerId);
            tapMultiplier += power.tapStrength[item.powerLevel-1];
        }
        return tapMultiplier;
    }
    public void RewardPlayer(int reward)
    {
        gold += reward;
        Menu_Tog_Letter.Instance.ChangeGoldText(gold.ToString());
    }

    public bool ChargeGold(int amount)
    {
        if (amount <= gold)
        {
            gold -= amount;
            Menu_Tog_Letter.Instance.ChangeGoldText(gold.ToString());
            return true;
        }
        return false;
    }

    public int GetGold()
    {
        return gold;
    }
    public void AddPowerItem(int itemId, int level)
    {
        int nextLevel = level+ 1;
        PowerItem item = powerItems.Find(x => x.powerId == itemId);
        if (item != null)
        {
            item.powerLevel = nextLevel;
        }
        else
        {
            powerItems.Add(new PowerItem(itemId, nextLevel));
        }
    }
}

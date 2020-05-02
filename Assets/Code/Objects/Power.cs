
using UnityEngine;

public class Power 
{
    public int itemId;
    public string itemName;
    public string itemDesc;
    public int maxLevel;
    public int cost;

    public double[] tapStrength;
    public double[] idleStrength;

    public Sprite GetItemIcon()
    {
        return Resources.Load<Sprite>("PowerItems/Icons/"+itemId);
    }
}

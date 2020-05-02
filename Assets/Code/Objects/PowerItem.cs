using System;

[Serializable]
public class PowerItem
{
    public int powerId;
    public int powerLevel;

    public PowerItem(int id, int level)
    {
        powerId = id;
        powerLevel = level;
    }
}

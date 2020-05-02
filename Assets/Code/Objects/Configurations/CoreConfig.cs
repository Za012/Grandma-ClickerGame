using System;
using System.Collections.Generic;

[Serializable]
public class CoreConfig
{
    public Player player;
    public List<IItemObservable> items;
    public IItemObservable currentItem;
    public ItemInventory itemInventory;
    public Dictionary<int, MissionStatusEnum> missions;
    public DateTime TimeWhenQuit { get; internal set; }
}

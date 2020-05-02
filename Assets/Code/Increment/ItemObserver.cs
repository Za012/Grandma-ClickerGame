using System;
using System.Collections.Generic;

[Serializable]
public class ItemObserver
{
    private List<IItemObservable> observables;

    private static ItemObserver Instance;

    public static ItemObserver GetInstance()
    {
        if (Instance == null)
        {
            Instance = new ItemObserver();
        }
        return Instance;
    }
    private ItemObserver()
    {
        List<IItemObservable> savedObservables = SaveFile.GetInstance().CoreConfig.items;
        if (savedObservables == null)
        {
            observables = new List<IItemObservable>();
        }
        else
        {
            observables = savedObservables;
        }
    }

    public void AddObservable(IItemObservable observable)
    {
        observables.Add(observable);
    }

    // Observe all working items and add them to ItemInventory when complete
    internal void IsComplete(IItemObservable item)
    {  
        if (item.GetPointsToComplete() <= item.GetCurrentPoints())
        {
            SaveFile.GetInstance().CoreConfig.itemInventory.Increment(item);
            item.Reset();
        }
    }
}

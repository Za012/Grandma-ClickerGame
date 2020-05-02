using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class MissionObserver
{
    private static MissionObserver Instance;

    public static MissionObserver GetInstance()
    {
        if (Instance == null)
        {
            Instance = new MissionObserver();
        }
        return Instance;
    }
    private MissionObserver()
    {
    }


    // Observe all working items and add them to ItemInventory when complete
    internal void IsComplete(IItemObservable item)
    {
        if(MissionController.Instance == null)
        {
            return;
        }
        Mission activeMission = MissionController.Instance.GetActiveMission();
        if (activeMission == null)
        {
            if (!MissionController.Instance.waitingForNextMission)
            {
                MissionController.Instance.BeginCountdownForNextMission();
            }
            return;
        }
        for (int i = 0; i < activeMission.itemRequests.Count; i++)
        {
            if (activeMission.itemRequests[i].itemName == item.GetName())
            {
                if (SaveFile.GetInstance().CoreConfig.itemInventory.GetItemAmount(item) >= activeMission.itemRequests[i].amount)
                {
                    if (SaveFile.GetInstance().CoreConfig.missions.ContainsKey(activeMission.id)) {
                        activeMission.itemRequests[i].isComplete = true;
                    }
                }
                else
                {
                    activeMission.itemRequests[i].isComplete = false;
                }
            }
        }
        foreach (ItemRequest request in activeMission.itemRequests)
        {
            if (!request.isComplete)
            {
                return;
            }
        }

        // Mission Completed
        SaveFile.GetInstance().CoreConfig.missions[activeMission.id] = MissionStatusEnum.Completed;
        foreach (ItemRequest itemRequest in activeMission.itemRequests)
        {
            SaveFile.GetInstance().CoreConfig.itemInventory.Decrement(itemRequest.itemName, itemRequest.amount);
        }
        SaveFile.GetInstance().CoreConfig.player.RewardPlayer(activeMission.reward);
        Debug.Log("User rewarded: " + activeMission.reward + " gold");
        Debug.Log($"Mission ID: {activeMission.id} has been completed");
        activeMission = null;
        GameObject.Find("ItemAmountText").GetComponent<Text>().text = SaveFile.GetInstance().CoreConfig.itemInventory.GetItemAmount(SaveFile.GetInstance().CoreConfig.currentItem).ToString();
        MissionController.Instance.WriteTheLetter("Thanks grandma! \n I knew I could count on you! \n I'll be back soon with more <3");
        MissionController.Instance.BeginCountdownForNextMission();
    }
}

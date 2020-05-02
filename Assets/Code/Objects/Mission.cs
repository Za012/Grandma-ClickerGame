using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission
{
    public int id;
    public List<ItemRequest> itemRequests;
    public string story;
    public int reward;
    public int characterId;

    public Sprite GetCharacter()
    {
        return Resources.Load<Sprite>("Characters/kids/kid" + characterId); ;
    }
}

public class ItemRequest{
    public string itemName;
    public int amount;
    public bool isComplete;
}

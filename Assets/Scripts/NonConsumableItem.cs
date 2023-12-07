using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NonConsumableItem
{
    public int itemId;
    public string itemName;
    public float itemCost;

    public bool isLocked = true;
}

[System.Serializable]
public class NonConsumableItemList
{
    public List<NonConsumableItem> nonConsumableItemLists;
}

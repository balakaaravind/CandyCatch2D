using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ConsumableItem
{
    public int itemId;
    public int coins;
    public int itemCost;


}

[System.Serializable]
public class ConsumableItemList
{
    public List<ConsumableItem> consumableItems;
    
}

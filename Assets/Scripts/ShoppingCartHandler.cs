using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DataConst;

public class ShoppingCartHandler : MonoBehaviour
{
    public GameObject defaultCoinItem;
    public GameObject defaultHatItem;

    private string consumableDataString;
    private string nonConsumableDataString;

    public GameObject playPanel;
    ConsumableData consumableData;
    NonConsumableData nonConsumableData;

 

    void Start()
    {
        

        if (!PlayerPrefs.HasKey(DataConst.PlayerPrefsConst.consumableSavedData)) ///data not available in PlayerPrefs 
        {


            try
            {

                consumableData = Resources.Load<ConsumableData>("Data/ConsumableData"); // setting path for scriptable object tp fetch or load data

            }
            catch (Exception e)
            {
                Debug.Log("Loading Data Error   " + e.Message);
            }

            LoadConsumableItems(consumableData.consumableItemList);

            //JSON storing default data

            consumableDataString = JsonUtility.ToJson(consumableData.consumableItemList);
            Debug.Log(" Loading Consumable Data strings  " + consumableDataString);
            PlayerPrefs.SetString(PlayerPrefsConst.consumableSavedData, consumableDataString); //
            

        }
        else
        {
            consumableDataString = PlayerPrefs.GetString(PlayerPrefsConst.consumableSavedData);
            consumableData = new ConsumableData();
            ConsumableItemList consumableItemList = new ConsumableItemList();

                consumableItemList = JsonUtility.FromJson<ConsumableItemList>(consumableDataString);

            

            LoadConsumableItems(consumableItemList);

            Debug.Log("Loading data from saved object from consumable data");
        }

 
        if (!PlayerPrefs.HasKey(PlayerPrefsConst.nonConsumableSavedData))
        {

            try
            {

               
                nonConsumableData = Resources.Load<NonConsumableData>("Data/NonConsumableData");
            }
            catch (Exception e)
            {
                Debug.Log("Loading Data Error   " + e.Message);
            }

            LoadNonConsumableItems(nonConsumableData.nonConsumableItemList);

            //JSON storing default data

            nonConsumableDataString = JsonUtility.ToJson(nonConsumableData.nonConsumableItemList);
            PlayerPrefs.SetString(PlayerPrefsConst.nonConsumableSavedData, nonConsumableDataString);

            Debug.Log(" non consumable Data Strings " + nonConsumableDataString);
            Debug.Log("Loading non Consumable Data From Scriptable Object");



        }
        else
        {
            nonConsumableDataString = PlayerPrefs.GetString(PlayerPrefsConst.nonConsumableSavedData);
            nonConsumableData = new NonConsumableData();
            nonConsumableData.nonConsumableItemList =JsonUtility.FromJson<NonConsumableItemList>(nonConsumableDataString); 
            Debug.Log("Loading data from saved object non consumable");
            LoadNonConsumableItems(nonConsumableData.nonConsumableItemList);
            Debug.Log(" non consumable Data Strings " + nonConsumableDataString);
        }


    }


    private void LoadConsumableItems(ConsumableItemList consumableItemList)
    {

        foreach (ConsumableItem consumableItem in consumableItemList.consumableItems)
        {

            GameObject coinItem = Instantiate(defaultCoinItem, defaultCoinItem.transform.parent);
            //Debug.Log(defaultCoinItem.transform.parent+ consumableItem.coins.ToString());////
            coinItem.SetActive(true);
            coinItem.name = consumableItem.itemCost.ToString();
            coinItem.GetComponentInChildren<Image>().gameObject.GetComponentsInChildren<TMPro.TMP_Text>()[1].text = consumableItem.itemCost.ToString();
            coinItem.GetComponentInChildren<Image>().gameObject.GetComponentsInChildren<TMPro.TMP_Text>()[0].text = consumableItem.coins.ToString();
            coinItem.GetComponent<Button>().onClick.AddListener(() => OnClickConsumable(consumableItem.itemId));

        }
    }

    private void OnClickConsumable(int itemId)
    {

        Debug.Log("Item ID of Consumable " + itemId);
    }

    private void LoadNonConsumableItems(NonConsumableItemList nonConsumableItemList)
    {
        foreach (NonConsumableItem nonConsumableItem in nonConsumableItemList.nonConsumableItemLists)
        {
            GameObject hatItem = Instantiate(defaultHatItem, defaultHatItem.transform.parent);
            hatItem.SetActive(true);
            hatItem.name = nonConsumableItem.itemCost.ToString();
            hatItem.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<TMPro.TMP_Text>().text = nonConsumableItem.itemCost.ToString();
            hatItem.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Image>().gameObject.SetActive(nonConsumableItem.isLocked);
            hatItem.GetComponent<Button>().onClick.AddListener(() => OnClickNonConsumable(nonConsumableItem.itemId));
        }
    }

    private void OnClickNonConsumable(int itemId)
    {
        Debug.Log("Item ID of NonConsumable " + itemId);
    }

    public void ShopPanelCLose()
    {
        gameObject.SetActive(false);
        playPanel.SetActive(true);
    }
    void Update()
    {
        
    }
}

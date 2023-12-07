using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UserProfileHandler : MonoBehaviour
{
    
    public TMPro.TMP_Text Text_Name;

    public TMPro.TMP_Text Text_Score;

    public TMPro.TMP_Text Text_Coin;

    UserData userData;
    ConsumableData aaconsu;

    public GameObject playPanel;

    void Start()
    {
        try
        {
            
            userData = Resources.Load<UserData>("Data/UserData");
        }
        catch(Exception e  )
        {
            Debug.Log("Loading Data Error   "+ e.Message);
        }
        //Loading default data
        Text_Name.text = userData.userProfile.name.ToString();
        Text_Score.text = userData.userProfile.score.ToString();
        Text_Coin.text = userData.userProfile.coin.ToString();

    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
        playPanel.SetActive(true);
    }

    void Update()
    {
        
    }
}

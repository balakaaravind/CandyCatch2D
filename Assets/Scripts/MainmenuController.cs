using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuController : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject playPanel;
    public GameObject userProfPanel;


    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ShopPanel()
    {
        shopPanel.SetActive(true);
        playPanel.SetActive(false);
    }

    public void UserProfPanel()
    {
        userProfPanel.SetActive(true);
        playPanel.SetActive(false);
    }


}

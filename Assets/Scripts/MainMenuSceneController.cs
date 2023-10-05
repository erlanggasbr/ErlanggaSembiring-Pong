using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneController : MonoBehaviour
{
    public GameObject creditPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("Created by Erlangga Sembiring");
    }

    public void OpenCredit()
    {
        creditPanel.SetActive(true);
    }

    public void CloseCredit()
    {
        creditPanel.SetActive(false);
    }
}

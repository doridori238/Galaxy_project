using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject startImage;
    public GameObject ExitImage;


    public void Exit()
    {
        ExitImage.gameObject.SetActive(false);
    }

    public void StartImage()
    {
        startImage.gameObject.SetActive(false);
    }


    public void SceneChange()
    {
        SceneManager.LoadScene("GameScene");
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
   
}

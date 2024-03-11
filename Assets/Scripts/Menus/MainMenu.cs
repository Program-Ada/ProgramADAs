using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("GameSelection");
    }

    public void GameOptions(){
        SceneManager.LoadScene("GameOptions");
    }

    public void QuitGame(){
        Application.Quit();
    }
}

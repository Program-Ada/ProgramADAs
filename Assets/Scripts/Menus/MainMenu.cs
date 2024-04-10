using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private Button playGameButton;
    [SerializeField] private Button gameOptionsButton;
    [SerializeField] private Button quitGameButton;

    public void PlayGame(){
        SceneManager.LoadSceneAsync("GameSelection");
    }

    public void GameOptions(){
        SceneManager.LoadSceneAsync("GameOptions");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void DisableMenuButtons(){
        playGameButton.interactable = false;
        gameOptionsButton.interactable = false;
        quitGameButton.interactable = false;
    }
}

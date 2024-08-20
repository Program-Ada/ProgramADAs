using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsMenu : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button quitGameButton;

    public void PlayAgain(){
        SceneManager.LoadSceneAsync("Menu");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void DisableMenuButtons(){
        playAgainButton.interactable = false;
        quitGameButton.interactable = false;
    }
}

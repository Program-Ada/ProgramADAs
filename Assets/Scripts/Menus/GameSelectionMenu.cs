using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSelectionMenu : MonoBehaviour
{
    [Header("Botões do Menu")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;

    private void Start(){
        if(!DataPersistenceManager.Instance.HasGameData()){
            continueGameButton.interactable = false;
        }
    }

    public void OnNewGameClicked(){
        DisableMenuButtons();
        // Cria um novo jogo - o qual vai iniciar os dados do jogo
        DataPersistenceManager.Instance.NewGame();
        // Carrega a Cena de Gameplay - a qual vai salvar o jogo devido ao OnSCeneUnloaded()
        SceneManager.LoadSceneAsync("Game");
    }

    public void OnContinueGameClicked(){
        DisableMenuButtons();
        // Carrewga a próxima scena - a qual vai carregar os dados do jogo devido ao OnSceneLoaded()
        SceneManager.LoadSceneAsync("Game");
    }

    private void DisableMenuButtons(){
        // Essa função evita que o usuário dê double click nos botões
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }
}

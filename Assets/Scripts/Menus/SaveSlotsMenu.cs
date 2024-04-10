using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotsMenu : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private Button backButton;
    private SaveSlot[] saveSlots;

    private void Awake(){
        saveSlots = this.GetComponentsInChildren<SaveSlot>();
    }

    public void OnSaveSlotClicked(SaveSlot saveSlot){
        // Desabilita os outros botões
        DisableSaveSlotsButtons();

        // Atualiza o perfil a ser usado no data persistence
        DataPersistenceManager.Instance.ChangeSelectedProfileId(saveSlot.GetProfileId());

        Debug.Log("saveSlot.GetProfileId() == " + saveSlot.GetProfileId());
        if(!saveSlot.hasData){
            // Cria um novo jogo - fazendo com que nossos dados sejam inicializados em um estado limpo
            DataPersistenceManager.Instance.NewGame();
            // Carrega a cena - por consequência vai salvar o jogo devido ao OnSceneUnloaded() no DataPersistenceManager
            SceneManager.LoadSceneAsync("Game");
        }else{
            SceneManager.LoadSceneAsync(saveSlot.lastScene);
        }

    }

    private void Start(){
        ActivateMenu();
    }

    public void ActivateMenu(){
        // Carrega todos os perfis que existem 
        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.Instance.GetAllProfilesGameData();
    
        // Faz um loop passando por cada save slot no UI e carrega o conteúdo apropriado
        foreach (SaveSlot saveSlot in saveSlots)
        {
                   GameData profileData = null;
                   profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);  
                   saveSlot.SetData(profileData);
        }
    }

    public void BackButton(){
        DisableSaveSlotsButtons();
        SceneManager.LoadSceneAsync("Menu");
    }

    private void DisableSaveSlotsButtons(){
        foreach(SaveSlot saveSlot in saveSlots){
            saveSlot.SetInteractable(false);
        }
        backButton.interactable = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotsMenu : MonoBehaviour, IDataPersistence
{
    [Header("Menu Buttons")]
    [SerializeField] private Button backButton;
    private SaveSlot[] saveSlots;
    [SerializeField] private GameObject saveSlotNameMenu;
    public TextMeshProUGUI saveSlotNameInput;
    public bool createdNow = false;

    private void Awake(){
        saveSlots = this.GetComponentsInChildren<SaveSlot>();
    }

    public /*async*/ void OnSaveSlotClicked(SaveSlot saveSlot){
        // Desabilita os outros botões
        DisableSaveSlotsButtons();

        // Atualiza o perfil a ser usado no data persistence
        DataPersistenceManager.Instance.ChangeSelectedProfileId(saveSlot.GetProfileId());

        if(!saveSlot.hasData){
            // Pede para inserir o nome do saveslot
            this.gameObject.SetActive(false);
            saveSlotNameMenu.SetActive(true);

        }else{
            SceneManager.LoadSceneAsync(saveSlot.lastScene);
        }

    }

    public void createNewSave(){
        createdNow = true;
        saveSlotNameMenu.SetActive(false);
        // Cria um novo jogo - fazendo com que nossos dados sejam inicializados em um estado limpo
        DataPersistenceManager.Instance.NewGame();
        // Salva o nome do saveslot
        DataPersistenceManager.Instance.SaveGame();
        // Carrega a cena - por consequência vai salvar o jogo devido ao OnSceneUnloaded() no DataPersistenceManager
        SceneManager.LoadSceneAsync("InicialCutscene");
    }

    public void CancelNewSaveCreation(){
        saveSlotNameMenu.SetActive(false);
        this.gameObject.SetActive(true);
        EnableSaveSlotsButtons();
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

    private void EnableSaveSlotsButtons(){
        foreach(SaveSlot saveSlot in saveSlots){
            saveSlot.SetInteractable(true);
        }
        backButton.interactable = true;
    }

    public void SaveData(ref GameData data){
        if(createdNow){
            data.saveSlotName = saveSlotNameInput.text;
        }

    }

    public void LoadData(GameData data){
        // empty
    }
}

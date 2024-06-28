using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] private bool initializeDataIfNull = false;

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;

    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    private string selectedProfileId = "";

    public static DataPersistenceManager Instance {get; private set;}

    public string lastScene;

    private void Awake()
    {
        if(Instance != null){
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this.gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
    }

    private void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded;
        //SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
        //SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();

        if(scene.name != "Menu" && scene.name != "GameSelection"){
            LoadGame();
            SaveGame();
        }

        if(lastScene == "GameSelection"){
            Tutorial.Instance.OpenTutorial();
        }

        lastScene = scene.name; 
    }

    public void ChangeSelectedProfileId(string newProfileId){
        // Função responsável por mudar o perfil de jogador utilizado para o novo selecionado e carregar o jogo
        this.selectedProfileId = newProfileId;
        if(this.gameData != null){
            LoadGame();
        }

    }

    public void NewGame(){
        this.gameData = new GameData();
    }

    public void LoadGame(){
        // Dá load no arquivo de save usando o data handler
        this.gameData = dataHandler.Load(selectedProfileId);

        // Começa um novo jogo caso os dados estão como null e nós selecionamos a parte de debbug para desenvolvimento
        if(this.gameData == null && initializeDataIfNull){
            NewGame();
        }

        // se não tiver nenhum arquivo a ser carregado, não permita
        if(this.gameData == null){
            Debug.Log("Nenhum dado foi encontrado. Um novo jogo precisa ser iniciado antes que os dados possam ser lidos");
            return;
        }

        // envia os dados carregados aos arquivos que precisam dessa atualização de informações
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects){
            dataPersistenceObj.LoadData(gameData);
            Debug.Log("DataPersistenceOBJ: " + dataPersistenceObj);
        }

        Debug.Log("Game Loaded");
    }

    public void SaveGame(){
        // Se não tivermos dados a serem salvos, log um aviso aqui
        if(this.gameData == null){
            Debug.LogWarning("Nenhum dado foi encontrado. Um novo jogo deve ser inicializado antes que os dados possam ser salvos.");
            return;
        }

        // passa os dados para os scripts, para que as informações sejam atualizadas
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects){
            dataPersistenceObj.SaveData(ref gameData);
        }

        Debug.Log("Game Saved");

        // Salva esses dados em um arquivo usando o data handler
        dataHandler.Save(gameData, selectedProfileId);
    }

    private void OnApplicationQuit(){
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects(){
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool HasGameData(){
        return gameData != null;
    }

    public Dictionary<string, GameData> GetAllProfilesGameData(){
        return dataHandler.loadAllProfiles();
    }

}

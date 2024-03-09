using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;

    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    public static DataPersistenceManager Instance {get; private set;}

    private void Awake()
    {
        if(Instance != null){
            Debug.LogError("Existe mais de um Data Persistence Manager na scena");
        }
        Instance = this;
    }

    private void Start(){
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame(){
        this.gameData = new GameData();
    }

    public void LoadGame(){
        // Dá load no arquivo de save usando o data handler
        this.gameData = dataHandler.Load();

        // se não tiver nenhum arquivo a ser carregado, então, inicializar um jogo novo

        if(this.gameData == null){
            Debug.Log("Nenhum dado foi encontrado. Inicializando dados padrão.");
            NewGame();
        }

        // envia os dados carregados aos arquivos que precisam dessa atualização de informações
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects){
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.Log("Loaded position = " + gameData.playerPosition);
    }

    public void SaveGame(){

        // TO DO - passar os dados para os scripts, para que as informações sejam atualizadas
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects){
            dataPersistenceObj.SaveData(ref gameData);
        }

        Debug.Log("Saved position = " + gameData.playerPosition);

        // Salva esses dados em um arquivo usando o data handler
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit(){
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects(){
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }

}

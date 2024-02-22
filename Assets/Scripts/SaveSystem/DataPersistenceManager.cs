using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager Instance {get; private set;}

    private GameData gameData;
    private void Awake()
    {
        if(Instance != null){
            Debug.LogError("Existe mais de um Data Persistence Manager na scena");
        }
        Instance = this;
    }

    public void NewGame(){

    }

    public void LoadGame(){

    }

    public void SaveGame(){

    }



}

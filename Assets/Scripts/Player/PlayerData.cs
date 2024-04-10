using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour, IDataPersistence
{
    public void LoadData(GameData data){
        this.transform.position = data.playerPosition;
    }
    public void SaveData(ref GameData data){
        data.playerPosition = this.transform.position;
        data.scene = SceneManager.GetActiveScene().name;
    }
}

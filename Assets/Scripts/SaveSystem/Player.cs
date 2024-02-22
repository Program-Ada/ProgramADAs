using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void Start(){
        LoadPLayerPosition();
    }
    public void SavePlayer(){
        SaveSystem.SaveGameData(this);
    }

    public void LoadPLayerPosition(){
        GameData data = SaveSystem.LoadGameData();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}

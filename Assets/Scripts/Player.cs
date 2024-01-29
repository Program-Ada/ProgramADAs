using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void Start(){
        LoadPLayer();
    }
    public void SavePlayer(){
        SaveSystem.SavePlayer(this);
    }

    public void LoadPLayer(){
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}

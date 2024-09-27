using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour, IDataPersistence
{
    public void LoadData(GameData data){
        if(DataPersistenceManager.Instance.lastScene == "GameSelection" || DataPersistenceManager.Instance.lastScene == "InicialCutscene"){
            this.transform.position = data.playerPosition;
        }else{
            Debug.Log("Seta Posição SpawnManager");
            this.transform.position = SpawnManager.Instance.playerSpawnPosition;
        }
    }
    public void SaveData(ref GameData data){
        // Salva a posição do personagem
        data.playerPosition = this.transform.position;
        // Salva a ultima cena em que o personagem estava
        data.scene = SceneManager.GetActiveScene().name;
        // Calcula a porcentagem de jogo completo do usuário de acordo com a pontuação obtida em cada uma
        // das fases do jogo (caso tenha nota suficiente para "passar" então soma 25% ao jogo completo)
        data.totalCompleted = 0;
        foreach (int fasePoint in data.pointFases){
            if(fasePoint >= 75){
                data.totalCompleted += 25;
            }
        }
    }
}

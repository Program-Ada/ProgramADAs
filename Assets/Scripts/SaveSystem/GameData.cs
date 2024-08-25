using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
   // public Vector2 playerPosition;

   public Vector2 playerPosition;
    public string scene;
    public int totalCompleted;
    public string saveSlotName;
    public int[] pointFases;
    public bool[] unlockedFases;
    public bool[] isNotificationOn;
    public int questProgressIndex;

    // os valores nesse constructor serão os valores iniciais que o jogo irá iniciar
    // toda vez que não tiver um arquivo de save criado ou começar um jogo novo

    public GameData ()
    { 
        playerPosition.x = -5.53f;
        playerPosition.y = 4.1f;
        totalCompleted = 0;
        saveSlotName = "Insira um Nome";
        scene = "InicialCutscene";
        pointFases = new int[5];
        unlockedFases = new bool[5];
        isNotificationOn = new bool[5];
        questProgressIndex = 1;
    }
}

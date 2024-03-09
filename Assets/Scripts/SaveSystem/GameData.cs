using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
   // public Vector2 playerPosition;

   public Vector2 playerPosition;
    public string scene;
    public int[] pointFases;

    // os valores nesse constructor serão os valores iniciais que o jogo irá iniciar
    // toda vez que não tiver um arquivo de save criado ou começar um jogo novo

    public GameData (/*Player player*/)
    {
        
            playerPosition.x = -6.12f;
            playerPosition.y = 6.12f;
    }
}

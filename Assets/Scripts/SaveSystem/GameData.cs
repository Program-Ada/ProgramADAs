using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Experimental.Animations;

[System.Serializable]
public class GameData
{
    public Vector2 playerPosition;
    public string scene;
    public int[] pointFases;

    // os valores nesse constructor serão os valores iniciais que o jogo irá iniciar
    // toda vez que não tiver um arquivo de save criado ou começar um jogo novo

    public GameData (/*Player player*/)
    {
            playerPosition = new float[2];
            playerPosition[0] = -6.12;
            playerPosition[1] = 6.12;
    }
}

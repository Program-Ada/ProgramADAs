using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Animations;

[System.Serializable]
public class PlayerData
{
    public float[] position;
    public string scene;
    public int[] pointFases;

    public PlayerData (Player player)
    {
            position = new float[3];
            position[0] = player.transform.position.x;
            position[1] = player.transform.position.y;
            position[2] = player.transform.position.z;
    }
}

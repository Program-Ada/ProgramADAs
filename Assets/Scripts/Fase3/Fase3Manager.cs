using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase3Manager : MonoBehaviour, IDataPersistence
{
    public static Fase3Manager instance;
    public int maxJogadas;
    private bool isGameFinished = false;
    void Start()
    {
        instance = this;
        maxJogadas = 6;
    }

    public void Finish_Game(bool finish){
        isGameFinished = finish;
        if(finish){
            ScoreCafe.instance.Show_Score();
        }else{
            ScoreCafe.instance.Show_Loose();
        }
    }

    public void LoadData(GameData data){
        // empty
    }
    public void SaveData(ref GameData data){
        if(isGameFinished){
            data.pointFases[1] = ScoreCafe.instance.score;
            if(ScoreCafe.instance.score >=75){
                data.questProgressIndex = 6;
            }else{
                data.questProgressIndex = 5;
            }
        }

    }
}


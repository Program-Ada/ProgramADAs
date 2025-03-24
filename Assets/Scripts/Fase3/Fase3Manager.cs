using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase3Manager : MonoBehaviour, IDataPersistence
{
    public static Fase3Manager Instance;
    public int maxPartidas;
    private bool isGameFinished = false;
    void Start()
    {
        Instance = this;
        maxPartidas = 6;
    }

    public void Finish_Game(bool finish){
        isGameFinished = finish;
        if(finish){
            ScoreFase3.instance.Show_Score();
        }else{
            ScoreFase3.instance.Show_Loose();
        }
    }

    public void LoadData(GameData data){
        // empty
    }
    public void SaveData(ref GameData data){
        if(isGameFinished){
            data.pointFases[1] = ScoreFase3.instance.score;
            if(ScoreFase3.instance.score >=75){
                data.questProgressIndex = 6;
            }else{
                data.questProgressIndex = 5;
            }
        }

    }
}


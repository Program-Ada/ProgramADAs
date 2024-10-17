using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCafe : MonoBehaviour
{
    public static ScoreCafe instance;
    private int score;

    void Start(){
        instance = this;
        Reset_Score();
    }
    public void Update_Score(int typeError){
        if(typeError == 1){
            score -= 8;
        }
        else if(typeError == 2){
            score -= 16;
        }
    }

    public void Reset_Score(){
        score = 100;
    }

    public void Show_Score(){
        
    }
}

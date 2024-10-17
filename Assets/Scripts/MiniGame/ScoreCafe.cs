using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCafe : MonoBehaviour
{
    public static ScoreCafe instance;
    private int score;
    public TextMeshProUGUI scoreTxt;
    public GameObject scoreCanvas;
    public GameObject looseCanvas;

    void Start(){
        instance = this;
        scoreCanvas.SetActive(false);
        looseCanvas.SetActive(false);
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
        ButtonsMiniGame.instance.Disable_Buttons();
        scoreTxt.text = score.ToString() + "%";
        scoreCanvas.SetActive(true);
    }

    public void Show_Loose(){
        ButtonsMiniGame.instance.Disable_Buttons();
        looseCanvas.SetActive(true);
    }

    public void TryAgain_Btn(){
        scoreCanvas.SetActive(false);
        looseCanvas.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit_Btn(){
        SceneManager.LoadScene("Convivencia");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizAnswerScript : MonoBehaviour
{
    public Color startColor;
    public bool isCorrect = false;
    public QuizManager quizManager;

    private void Start(){
        startColor = GetComponent<Image>().color;
    }

    public void Answer(){
        quizManager.DisableAnswerButtons();
        if(isCorrect){
            SoundManager.sm.Correct();
            GetComponent<Image>().color = Color.green;
            Invoke("AnswerCorrect", 1);

        }else{
            SoundManager.sm.Wrong();
            GetComponent<Image>().color = Color.red;
            Invoke("AnswerWrong", 1);
        }
    }

    public void AnswerCorrect(){
        quizManager.Correct();
        GetComponent<Image>().color = startColor;
    }

    public void AnswerWrong(){
        quizManager.Wrong();
        GetComponent<Image>().color = startColor;
    }
}

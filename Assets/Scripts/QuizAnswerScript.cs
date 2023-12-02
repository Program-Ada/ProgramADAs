using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizAnswerScript : MonoBehaviour
{
    public Color startColor;
    public bool isCorrect = false;
    public QuizManager quizManager;
    public SoundManager soundManager;

    private void Start(){
        startColor = GetComponent<Image>().color;
    }

    public void Answer(){
        if(isCorrect){
            soundManager.Correct();
            GetComponent<Image>().color = Color.green;
            Invoke("AnswerCorrect", 1);

        }else{
            soundManager.Wrong();
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

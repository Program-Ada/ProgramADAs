using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.SocialPlatforms.Impl;

public class QuizManager : MonoBehaviour, IDataPersistence
{
    List<QuestionAndAnswers> QnA;
    public List<QuestionAndAnswers> Qn;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject ScorePanel;
    public GameObject InicialPanel;
    public GameObject Player;

    public TextMeshProUGUI QuestionTxt;
    public TextMeshProUGUI ScoreTxt;

    int totalQuestions = 0;
    public int score;
    public bool passed = false;
    public static QuizManager qm;
    public float media;
    public bool quizDone = false;

    private void Awake(){
        InicialPanel.SetActive(false);
        QuizPanel.SetActive(false);
        ScorePanel.SetActive(false);
        QnA = new List<QuestionAndAnswers>();
        qm = this;
    }

    private void Copia(){
        QnA.Clear();
        foreach(QuestionAndAnswers q in Qn){
            QnA.Add(q);
        }
    }

    public void InicialPage(){
        InicialPanel.SetActive(true);
    }

    public void StartQuiz(){
        Copia();
        totalQuestions = QnA.Count;
        InicialPanel.SetActive(false);
        QuizPanel.SetActive(true);
        Player.GetComponent<PlayerMovement>().enabled = false;
        GenerateQuestion();
    }

    public void Retry(){
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Sair();
        StartQuiz();
    }

    public void Sair(){
        InicialPanel.SetActive(false);
        ScorePanel.SetActive(false);
        Player.GetComponent<PlayerMovement>().enabled = true;
        if(totalQuestions != 0 && (float)score/totalQuestions >= 0.75f){
            passed = true;
        }else{
            passed = false;
        }
        score = 0;
    }

    public void GameOver(){
        media = MathF.Round((float)score/totalQuestions * 100);
        QuizPanel.SetActive(false);
        ScorePanel.SetActive(true);  
        ScoreTxt.text = media.ToString() + "%";
        quizDone = true;
        DataPersistenceManager.Instance.SaveGame();
    }

    public void Correct(){
        score += 1;
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }

    public void Wrong(){
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }

    void SetAnswers(){
        for(int i = 0; i < options.Length; i++){
            options[i].GetComponent<QuizAnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].correctAnswer == i+1){
                options[i].GetComponent<QuizAnswerScript>().isCorrect = true;
            }
        }
    }

    void GenerateQuestion(){
        if(QnA.Count > 0){
            currentQuestion = UnityEngine.Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
            EnableAnswerButtons();
        }else{
            GameOver();
        }
    }

    public void DisableAnswerButtons(){
        foreach(GameObject button in options){
            Button b = button.GetComponent<Button>();
            b.interactable = false;
        }
    }

    public void EnableAnswerButtons(){
        foreach(GameObject button in options){
            Button b = button.GetComponent<Button>();
            b.interactable = true;
        }
    }

    public void LoadData(GameData data){
        // empty
    }
    public void SaveData(ref GameData data){
        Debug.Log("quizDone: " + quizDone);
        if(quizDone){
            data.pointFases[0] = (int)media;
        }

    }

}

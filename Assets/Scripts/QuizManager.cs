using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject ScorePanel;
    public GameObject Player;

    public TextMeshProUGUI QuestionTxt;
    public TextMeshProUGUI ScoreTxt;

    int totalQuestions = 0;
    public int score;

    private void Start(){
        QuizPanel.SetActive(false);
        ScorePanel.SetActive(false);
    }

    public void StartQuiz(){
        totalQuestions = QnA.Count;
        QuizPanel.SetActive(true);
        Player.SetActive(false);
        GenerateQuestion();

    }

    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Sair(){
        ScorePanel.SetActive(false);
        Player.SetActive(true);
    }

    public void GameOver(){
        QuizPanel.SetActive(false);
        ScorePanel.SetActive(true);  
        ScoreTxt.text =   score + " / " + totalQuestions;
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
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }else{
            Debug.Log("Out of Questions");
            GameOver();
        }

    }
}

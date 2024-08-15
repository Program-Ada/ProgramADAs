using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizTrigger : MonoBehaviour
{
    public bool playerIsClose;
    public QuizManager Qm;
    public static QuizTrigger Instance;
    public GameObject toolTip;
    public GameObject exclamation;

    public bool isExclamationActive;

    void Start(){
        Qm = FindObjectOfType<QuizManager>();
        toolTip.SetActive(false);
        exclamation.SetActive(false);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose){
            TriggerQuiz();
        }
    }
    public void TriggerQuiz(){
        Qm.InicialPage();
        exclamation.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = true;
            toolTip.SetActive(true);

            if(exclamation.activeSelf){
                isExclamationActive = true;
                exclamation.SetActive(false);
            }
        }
    }

        private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = false;
            toolTip.SetActive(false);

            if(isExclamationActive){
                isExclamationActive = false;
                exclamation.SetActive(true);
            }
        }
    }

    public void ActivateQuizExclamation(){
        exclamation.SetActive(true);
    }
}

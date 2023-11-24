using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizTrigger : MonoBehaviour
{
    public bool playerIsClose;
    public QuizManager Qm;
    [SerializeField]GameObject toolTip;

    void Start(){
        Qm = FindObjectOfType<QuizManager>();
        toolTip.SetActive(false);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose){
            TriggerQuiz();
        }
    }
    public void TriggerQuiz(){
        Qm.InicialPage();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = true;
            toolTip.SetActive(true);
        }
    }

        private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = false;
            toolTip.SetActive(false);
        }
    }
}

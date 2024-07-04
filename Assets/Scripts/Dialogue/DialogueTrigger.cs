using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool playerIsClose;
    public bool playerIsChatting;
    //public bool isExclamationActive;
    //public GameObject barbaraExclamation;
    public DialogueManager dm;
    [SerializeField]GameObject toolTip;

    void Awake(){
        dm = FindObjectOfType<DialogueManager>();
        toolTip.SetActive(false);
        //barbaraExclamation = GameObject.Find("Barbara/Exclamation");
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose && playerIsChatting == false){
            SoundManager.sm.Click();
            TriggerDialogue();
        }else if(Input.GetKeyDown(KeyCode.E) && playerIsClose && playerIsChatting){
            dm.DisplayNextSentence();
        }
    }
    public void TriggerDialogue(){
        playerIsChatting = true;
        dm.StartDialogue(dialogue);
        toolTip.SetActive(false);
        
        if(dialogue.name == "Bárbara"){
            GameManager.Instance.UnlockChapterOne();
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = true;
            toolTip.SetActive(true);

            if(this.dialogue.name == "Bárbara" && GameManager.Instance.barbaraExclamation.activeSelf){
                GameManager.Instance.isBarbaraExclamationActive = true;
                GameManager.Instance.barbaraExclamation.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other){
    if(other.CompareTag("Player")){
        playerIsClose = false;
        playerIsChatting = false;
        toolTip.SetActive(false);
        dm.EndDialogue();

        if(GameManager.Instance.isBarbaraExclamationActive){
            GameManager.Instance.isBarbaraExclamationActive = false;
            GameManager.Instance.barbaraExclamation.SetActive(true);
        }else{
            GameManager.Instance.barbaraExclamation.SetActive(false);
        }
    }
}

/*
    public void UpdateBarbaraExclamation(bool isActive){
        barbaraExclamation.SetActive(isActive);
        isExclamationActive = isActive;
        Debug.Log("isActive: " + isActive);
    }
*/
}

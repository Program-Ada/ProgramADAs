using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool playerIsClose;
    public bool playerIsChatting;

    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose && playerIsChatting == false){
            TriggerDialogue();
        }else if(Input.GetKeyDown(KeyCode.E) && playerIsClose && playerIsChatting){
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }
    public void TriggerDialogue(){
        playerIsChatting = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = true;
        }
    }

        private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = false;
            playerIsChatting = false;
            FindObjectOfType<DialogueManager>().EndDialogue();
        }
    }
}

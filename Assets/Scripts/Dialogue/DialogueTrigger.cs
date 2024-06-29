using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool playerIsClose;
    public bool playerIsChatting;
    public DialogueManager dm;
    [SerializeField]GameObject toolTip;

    void Start(){
        dm = FindObjectOfType<DialogueManager>();
        toolTip.SetActive(false);
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
        }
    }

        private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = false;
            playerIsChatting = false;
            toolTip.SetActive(false);
            dm.EndDialogue();
        }
    }
}

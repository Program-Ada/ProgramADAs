using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool playerIsClose;
    public bool playerIsChatting;
    public bool isExclamationActive;
    public GameObject barbaraExclamation;
    public DialogueManager dm;
    public MiniGameManager miniGameManager;
    [SerializeField]GameObject toolTip;

    void Start(){
        dm = FindObjectOfType<DialogueManager>();
        miniGameManager = FindObjectOfType<MiniGameManager>();
        toolTip.SetActive(false);
        barbaraExclamation = GameObject.Find("Barbara/Exclamation");
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose && playerIsChatting == false){
            SoundManager.sm.Click();
            TriggerDialogue();
        }else if(Input.GetKeyDown(KeyCode.E) && playerIsClose && playerIsChatting){
            dm.DisplayNextSentence(dialogue);
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

            if(GameObject.Find("Barbara/Exclamation") != null){
                isExclamationActive = true;
                barbaraExclamation = GameObject.Find("Barbara/Exclamation").gameObject;
                barbaraExclamation.SetActive(false);
            }
        }
    }

        private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = false;
            playerIsChatting = false;
            toolTip.SetActive(false);
            dm.EndDialogue();
<<<<<<< HEAD:Assets/Scripts/Dialogue/DialogueTrigger.cs

            if(isExclamationActive){
                isExclamationActive = false;
                barbaraExclamation.SetActive(true);
            }
=======
            miniGameManager.CloseAskMiniGame();
>>>>>>> fase_CafeDasMinas:Assets/Scripts/DialogueTrigger.cs
        }
    }
}

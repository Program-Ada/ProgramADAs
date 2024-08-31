using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public Image npcImage;
    public TextMeshProUGUI dialogueTextFalse;
    public GameObject buttonFalse;
    public GameObject buttonTrue;
    private DialogueTrigger dialogueTrigger;
    private DialogueManager dialogueManager;
    public Animator animator;
    //public Animator animatorMiniGame;

    void Start()
    {
        dialogueTrigger = FindObjectOfType<DialogueTrigger>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        //SetUpMiniGame();
        //dialogueTextFalse.enabled = false;
    }

    public void SetUpMiniGame(){
        //nameText.text = dialogueTrigger.dialogue.name;
        //npcImage.sprite = dialogueTrigger.dialogue.image;
    }

    public void OpenAskMiniGame(){
        //SetUpMiniGame();
        //buttonFalse.SetActive(true);
        //buttonTrue.SetActive(true);
        //dialogueTextFalse.enabled = false;
        animator.SetBool("isOpen", true);
    }

    public void CloseAskMiniGame(){
        animator.SetBool("isOpen", false);
    }
    
    public void AnwserFalse() {
        //dialogueTextFalse.enabled = true;
        //buttonFalse.SetActive(false);
        //buttonTrue.SetActive(false);
        //animatorMiniGame.SetBool("IsOpen", false);
        CloseAskMiniGame();
    }

    public void AnwserTrue(){
         SceneManager.LoadScene("MiniGame_Cafe");    //adicionar proxima cena
    }

    public void funtionTesteDebug() {
        Debug.Log("funcinou");
    }
}

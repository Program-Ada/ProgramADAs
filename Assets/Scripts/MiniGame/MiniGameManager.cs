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

    void Start()
    {
        dialogueTrigger = FindObjectOfType<DialogueTrigger>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueTextFalse.enabled = false;
    }

    public void OpenAskMiniGame(){
        buttonFalse.SetActive(true);
        buttonTrue.SetActive(true);
        dialogueTextFalse.enabled = false;
        animator.SetBool("IsOpen", true);
    }

    public void CloseAskMiniGame(){
        animator.SetBool("IsOpen", false);
    }
    
    public void AnwserFalse() {
        dialogueTextFalse.enabled = true;
        buttonFalse.SetActive(false);
        buttonTrue.SetActive(false);
        // dialogueManager.animatorMiniGame.SetBool("IsOpen", false);
    }

    public void AnwserTrue(){
        // SceneManager.LoadScene("MiniGame_Cafe");    //adicionar proxima cena
    }

    public void funtionTesteDebug() {
        Debug.Log("funcinou");
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    //public TextMeshProUGUI nameText;
    //public Image npcImage;
    //public TextMeshProUGUI dialogueTextFalse;
    public Button buttonFalse;
    public Button buttonTrue;
    //private DialogueTrigger dialogueTrigger;
    //private DialogueManager dialogueManager;
    public Animator animator;

    /*
    void Start()
    {
        //dialogueTrigger = FindObjectOfType<DialogueTrigger>();
        //dialogueManager = FindObjectOfType<DialogueManager>();
        //SetUpMiniGame();
        //dialogueTextFalse.enabled = false;
    }

    
    public void SetUpMiniGame(){
        //nameText.text = dialogueTrigger.dialogue.name;
        //npcImage.sprite = dialogueTrigger.dialogue.image;
    }
    */

    /*
    public void OpenAskMiniGame(){
        //SetUpMiniGame();
        //buttonFalse.SetActive(true);
        //buttonTrue.SetActive(true);
        //dialogueTextFalse.enabled = false;
        EnableButtons();
        Debug.Log("Enabled");
        animator.SetBool("IsOpen", true);
    }
    */

    void OnEnable()
    {
      EnableButtons();
    }

    public void CloseAskMiniGame(){
        animator.SetBool("IsOpen", false);
    }
    
    public void AnwserFalse() {
        //dialogueTextFalse.enabled = true;
        //buttonFalse.SetActive(false);
        //buttonTrue.SetActive(false);
        DisableButtons();
        CloseAskMiniGame();
    }

    public void AnwserTrue(){
        DisableButtons();
        SceneManager.LoadScene("MiniGame_Cafe");
    }

    private void DisableButtons(){
        buttonFalse.interactable = false;
        buttonTrue.interactable = false;
    }

    private void EnableButtons(){
        buttonFalse.interactable = true;
        buttonTrue.interactable = true;    
    }

    /*
    public void funtionTesteDebug() {
        Debug.Log("funcinou");
    }
    */
}

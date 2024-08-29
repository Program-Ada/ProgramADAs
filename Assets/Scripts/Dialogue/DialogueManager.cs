using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour{

    public static DialogueManager Instance;

    [Header("DialogueBox Setup")]
        public Image npcImage;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI dialogueText;
    
    [Header("Animation")]
        public Animator animator;
        private bool pularTexto = false;

    //private Queue<string> sentences;
    private Queue<DialogueLine> lines;
    private DialogueLine currentLine;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
 
        lines = new Queue<DialogueLine>();
    }

    public void StartDialogue(Dialogue dialogue){
    
       if(dialogue.haveQuestion)
       {
        dialogue.ask.SetActive(true);
       }
       
        animator.SetBool("IsOpen", true);

        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines){
            lines.Enqueue(dialogueLine);
        }

        DisplayNextSentence(dialogue);
    }

    public void DisplayNextSentence(Dialogue dialogue){

        if(pularTexto){
            pularTexto = false;
            StopAllCoroutines();
            dialogueText.text = currentLine.sentence;
            return;
        }

        if(dialogue.haveQuestion)
        {
            dialogue.ask.SetActive(true);
        }

        if(lines.Count == 0){
            EndDialogue();
            return;
        }

        currentLine = lines.Dequeue();

        nameText.text = currentLine.character.name;
        npcImage.sprite = currentLine.character.image;

        pularTexto = true;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence (DialogueLine dialogueLine){
        dialogueText.text = "";
        foreach(char letter in dialogueLine.sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds((float)0.05);
        }
        pularTexto = false;
    }

    public void EndDialogue(){
        animator.SetBool("IsOpen", false);
    }
}

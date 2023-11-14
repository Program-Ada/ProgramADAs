using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image npcImage;

    public Animator animator;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start(){
        sentences = new Queue<string>();
        
    }

    public void StartDialogue(Dialogue dialogue){

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        npcImage.sprite = dialogue.image;

        sentences.Clear();

        foreach (string sentence in dialogue.setences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence){
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds((float)0.05);
        }
    }

    public void EndDialogue(){
        animator.SetBool("IsOpen", false);
    }
}

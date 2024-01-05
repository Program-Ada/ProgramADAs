using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image npcImage;
    public bool pularTexto = false;

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

    string sentence = "";

    public void DisplayNextSentence(){
        if(pularTexto){
            pularTexto = false;
            StopAllCoroutines();
            dialogueText.text = sentence;
            return;
        }
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        pularTexto = true;

        sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence){
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds((float)0.05);
        }
        pularTexto = false;
    }

    public void EndDialogue(){
        animator.SetBool("IsOpen", false);
    }
}

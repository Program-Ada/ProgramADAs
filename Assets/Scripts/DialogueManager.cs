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
    // public Animator animatorMiniGame;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start(){
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue){
        if (dialogue.haveQuestion) {
            dialogue.question.SetActive(false);
        }

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        npcImage.sprite = dialogue.image;

        sentences.Clear();

        foreach (string sentence in dialogue.setences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence(dialogue);
    }

    string sentence = "";

    public void DisplayNextSentence(Dialogue dialogue){
        if(pularTexto){
            pularTexto = false;
            StopAllCoroutines();
            dialogueText.text = sentence;
            return;
        }
        //gambiarra, se tiver mais uma sentenca (ideal q esteja vazia) e tiver a pergunta, ele vai ativar o gameObject linkado
        if (dialogue.haveQuestion && sentences.Count == 1) {
            dialogue.question.SetActive(true);
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

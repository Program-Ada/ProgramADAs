using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueFeedback : MonoBehaviour
{
    public Dialogue dialogue;
    public bool playerIsClose;
    public bool playerIsChatting;
    [SerializeField]GameObject toolTip;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image npcImage;
    public bool pularTexto = false;
    public Animator animator;
    private Queue<string> sentences;
    public GameObject NPCfeedback;
    public string errorName;

    void Start(){
        sentences = new Queue<string>();
        toolTip.SetActive(false);
        // NPCfeedback = FindObjectOfType<Feedbacks>().feedbackAtual;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose && playerIsChatting == false){
            SoundManager.sm.Click();
            TriggerDialogue();
        }else if(Input.GetKeyDown(KeyCode.E) && playerIsClose && playerIsChatting){
            DisplayNextSentence(dialogue);
        }
    }
    public void TriggerDialogue(){
        playerIsChatting = true;
        StartDialogue(dialogue);
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
        EndNPC();
    }

    public void EndNPC(){
        NPCfeedback = FindObjectOfType<Feedbacks>().feedbackAtual;
        NPCfeedback.SetActive(false);
    }
}

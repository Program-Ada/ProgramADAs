using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FeedbackManagerFase3 : MonoBehaviour
{
    [Header("Static Instance")]
        public static FeedbackManagerFase3 Instance;

    [Header("FeedBack Box Setup")]
        public TextMeshProUGUI npcName;
        public Image npcImage;
        public TextMeshProUGUI feedbackText;

    [Header("Animation")]
        public Animator animator;
        private bool pularTexto = false;
    
    [Header("Variables")]
        public string errorName;
        public int errorAtual = -1;
        private Queue<string> sentences;
        private FeedbackTriggerFase3[] feedbacks;
        private GameObject feedbackAtual;

    void Awake(){
        Instance = this;
        sentences = new Queue<string>();
        feedbacks = GetComponentsInChildren<FeedbackTriggerFase3>(true);
    }

    public void Feedback_Test(string errorName)
    {
        errorAtual = VerificaErrorName(errorName);
        if(errorAtual != -1) {
            //ButtonsMiniGame.instance.Disable_Buttons();
            Debug.Log("Error: " + errorName);
            feedbackAtual = feedbacks[errorAtual].gameObject;
            feedbackAtual.SetActive(true);
        }
    }

    public int VerificaErrorName(string errorName) {
        switch (errorName)
        {
            case "meioCerto":
                return 0;
            case "errado":
                return 1;
            default:
                return -1;
        }
    }

    public void ShowFeedback(Feedback feedback){

        npcName.text = feedback.name;
        npcImage.sprite = feedback.image;
        animator.SetBool("IsOpen", true);

        sentences.Clear();

        foreach (string sentence in feedback.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    string sentence = "";

    public void DisplayNextSentence(){
        if(pularTexto){
            pularTexto = false;
            StopAllCoroutines();
            feedbackText.text = sentence;
            return;
        }

        if(sentences.Count == 0){
            EndFeedback();
            return;
        }

        pularTexto = true;

        sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence){
        feedbackText.text = "";
        foreach(char letter in sentence.ToCharArray()){
            feedbackText.text += letter;
            yield return new WaitForSeconds((float)0.05);
        }
        pularTexto = false;
    }

    public void EndFeedback(){
        animator.SetBool("IsOpen", false);
        feedbackAtual.SetActive(false);
        //ButtonsMiniGame.instance.Enable_Buttons();
    }
}


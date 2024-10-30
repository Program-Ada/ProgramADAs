using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Feedbacks : MonoBehaviour
{
    public GameObject withoutContainer;
    public DialogueFeedback[] feedbacks;
    public GameObject feedbackAtual;
    public int errorAtual;
    void Start()
    {
        feedbacks = GetComponentsInChildren<DialogueFeedback>(true);
        errorAtual = -1;
    }

    public void Feedback_Test(string errorName)
    {
        errorAtual = verificaErrorName(errorName);
        if(errorAtual != -1) {
            feedbackAtual = feedbacks[errorAtual].gameObject;
            feedbackAtual.SetActive(true);
            // Debug.Log("entrou feedback");
            // withoutContainer.SetActive(true);
            Invoke(nameof(activeDialogue),(float)0.5);
        }
    }

    public void activeDialogue()
    {
        feedbackAtual.GetComponent<DialogueFeedback>().TriggerDialogue();
    }

    public int verificaErrorName(string errorName) {
        switch (errorName)
        {
            case "semCopo":
                return 0;
            case "erro2":
                return 1;
            default:
                return -1;
        }
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FeedbackCheck : MonoBehaviour
{
    public FeedbackTrigger[] feedbacks;
    public GameObject feedbackAtual;
    public int errorAtual;
    void Start()
    {
        feedbacks = GetComponentsInChildren<FeedbackTrigger>(true);
        errorAtual = -1;
    }

    public void Feedback_Test(string errorName)
    {
        errorAtual = VerificaErrorName(errorName);
        if(errorAtual != -1) {
            feedbackAtual = feedbacks[errorAtual].gameObject;
            feedbackAtual.SetActive(true);
            Invoke(nameof(ActiveDialogue),(float)0.5);
        }
    }

    public void ActiveDialogue()
    {
        FeedbackManager.Instance.ShowFeedback(feedbackAtual.GetComponent<Feedback>());
    }

    public int VerificaErrorName(string errorName) {
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
*/

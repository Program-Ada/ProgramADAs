using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackTriggerFase3 : MonoBehaviour
{
    public Feedback feedback;

    void OnEnable() {
        FeedbackManagerFase3.Instance.ShowFeedback(feedback);
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            SoundManager.sm.Click();
            FeedbackManagerFase3.Instance.DisplayNextSentence();
        }
    }

}

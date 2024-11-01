using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackTrigger : MonoBehaviour
{
    public Feedback feedback;

    void Start() {
        FeedbackManager.Instance.ShowFeedback(feedback);
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            SoundManager.sm.Click();
            FeedbackManager.Instance.DisplayNextSentence();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject TutorialCanvas;
    public GameObject Player;
    public static Tutorial Instance {get; private set;}

    public void OkButton(){
        Player.GetComponent<PlayerMovement>().enabled = true;
        TutorialCanvas.SetActive(false);
    }

    public void OpenTutorial(){
        Player.GetComponent<PlayerMovement>().enabled = false;
        TutorialCanvas.SetActive(true);       
    }

}

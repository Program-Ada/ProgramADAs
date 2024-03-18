using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject TutorialCanvas;
    public GameObject Player;

    void Start()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        TutorialCanvas.SetActive(true);
    }

    public void OkButton(){
        Player.GetComponent<PlayerMovement>().enabled = true;
        TutorialCanvas.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drinks : MonoBehaviour
{
    public GameObject[] options;
    public bool containerFull;
    public int chosenOption;
    public bool containerExists;
    public ButtonsMiniGame buttonsMiniGame;

    void Start()
    {
        // containerFull = false;
        // chosenOption = -1;
        // containerExists = false;
        Reset_teste();
        buttonsMiniGame = FindAnyObjectByType<ButtonsMiniGame>();
    }

    public void Show_Option(int i) {
        if(containerExists) {
            if (!containerFull) { 
                options[i].SetActive(true);
                containerFull = true;
                chosenOption = i;
                buttonsMiniGame.copo.SetActive(false);
            }
        }
        else {
            Debug.Log("Não tem Copo = Suco derramado");
            // buttonsMiniGame.Feedback_Test();
            // buttonsMiniGame.Feedback_Test();
        }
    }

    public void Reset_teste() {
        containerFull = false;
        chosenOption = -1;
        containerExists = false;
    }
}

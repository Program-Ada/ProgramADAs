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
    public Feedbacks feedbacks;

    public GameObject[] drinkOptions;

    void Start()
    {
        // containerFull = false;
        // chosenOption = -1;
        // containerExists = false;
        Reset_teste();
        buttonsMiniGame = FindAnyObjectByType<ButtonsMiniGame>();
        feedbacks = FindAnyObjectByType<Feedbacks>();
    }

    public void Show_Option(int i) {
        if(containerExists) {
            if (!containerFull) { 
                options[i].SetActive(true);
                containerFull = true;
                chosenOption = i;
                buttonsMiniGame.copo.SetActive(false);
                drinkOptions[i].SetActive(true);
            }
        }
        else {
            Debug.Log("Não tem Copo = Suco derramado");
            feedbacks.Feedback_Test("semCopo");
        }
    }

    public void Reset_teste() {
        containerFull = false;
        chosenOption = -1;
        containerExists = false;
    }

    public void reset_option() {
        for (int i = 0; i < drinkOptions.Length; i++) {
            if (drinkOptions[i].activeSelf) {
                drinkOptions[i].SetActive(false);
            }
        }
    }
}

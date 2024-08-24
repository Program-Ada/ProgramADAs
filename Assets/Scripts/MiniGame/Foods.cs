using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foods : MonoBehaviour
{
    public GameObject[] options;
    public bool containerFull = false;
    public int chosenOption = -1;
    public bool containerExists;
    public ButtonsMiniGame buttonsMiniGame;
    public Feedbacks feedbacks;

    public GameObject[] foodOptions;

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
                buttonsMiniGame.pratoLimpo.SetActive(false);
                foodOptions[i].SetActive(true);
            }
        }
        else {
            Debug.Log("Não tem Prato = Bolo na mesa");
            feedbacks.Feedback_Test("erro2");
        }
    }

    public void Reset_teste() {
        containerFull = false;
        chosenOption = -1;
        containerExists = false;
    }

    public void reset_option() {
        for (int i = 0; i < foodOptions.Length; i++) {
            if (foodOptions[i].activeSelf) {
                foodOptions[i].SetActive(false);
            }
        }
    }
}

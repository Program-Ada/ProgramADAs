using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drinks : MonoBehaviour
{
    [Header("Static Instance")]
        public static Drinks Instance;
    public GameObject[] options;
    public bool containerFull;
    public int chosenOption;
    public bool containerExists;
    public GameObject[] drinkOptions;

    [Header("Booleans")]
    public bool isFunctionActive;

    void Start()
    {
        // containerFull = false;
        // chosenOption = -1;
        // containerExists = false;
        Reset_teste();
    }

    public void Show_Option(int i) {
        if(containerExists) {
            if (!containerFull) { 
                options[i].SetActive(true);
                containerFull = true;
                chosenOption = i;
                ButtonsMiniGame.instance.copo.SetActive(false);
                drinkOptions[i].SetActive(true);
            }
        }
        else {
            Debug.Log("Não tem Copo = Suco derramado");
            FeedbackManager.Instance.Feedback_Test("semCopo");
        }
    }

    public void Reset_teste() {
        containerFull = false;
        chosenOption = -1;
        containerExists = false;
    }

    public void Reset_option() {
        for (int i = 0; i < drinkOptions.Length; i++) {
            if (drinkOptions[i].activeSelf) {
                drinkOptions[i].SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foods : MonoBehaviour
{
    [Header("Static Instance")]
        public static Foods Instance;
    public GameObject[] options;
    public bool containerFull = false;
    public int chosenOption = -1;
    public bool containerExists;
    public ButtonsMiniGame buttonsMiniGame;
    public GameObject[] foodOptions;
    public bool isFoodFunctionSelected = false;

    void Start()
    {
        // containerFull = false;
        // chosenOption = -1;
        // containerExists = false;
        Instance = this;
        Reset_teste();
        buttonsMiniGame = FindAnyObjectByType<ButtonsMiniGame>();
    }

    public void Show_Option(int i) {
        if(isFoodFunctionSelected) {
            if (containerExists) { 
                if(!containerFull){
                    options[i].SetActive(true);
                    containerFull = true;
                    chosenOption = i;
                    buttonsMiniGame.pratoLimpo.SetActive(false);
                    foodOptions[i].SetActive(true);
                }
            }else{
                Debug.Log("Não tem Prato = Bolo na mesa");
                FeedbackManager.Instance.Feedback_Test("semPrato");  
            }
        }
        else {
            FeedbackManager.Instance.Feedback_Test("semParametro");
        }
    }

    public void Reset_teste() {
        containerFull = false;
        chosenOption = -1;
        containerExists = false;
    }


    public void Reset_option() {
        for (int i = 0; i < foodOptions.Length; i++) {
            if (foodOptions[i].activeSelf) {
                foodOptions[i].SetActive(false);
            }
        }
    }
}

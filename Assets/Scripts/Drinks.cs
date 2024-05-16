using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drinks : MonoBehaviour
{
    public GameObject[] drinks;
    public bool containerFull;
    public int drinkEcolhido;
    public bool existeCopo;
    public ButtonsMiniGame buttonsMiniGame;

    void Start()
    {
        // containerFull = false;
        // drinkEcolhido = -1;
        // existeCopo = false;
        Reset_teste();
        buttonsMiniGame = FindAnyObjectByType<ButtonsMiniGame>();
    }

    public void Show_Drink(int i) {
        if(existeCopo) {
            if (!containerFull) { 
                drinks[i].SetActive(true);
                containerFull = true;
                drinkEcolhido = i;
            }
        }
        else {
            Debug.Log("Não tem Copo = Suco derramado");
            buttonsMiniGame.Feedback_Test();
            buttonsMiniGame.Feedback_Test();
        }
    }

    public void Reset_teste() {
        containerFull = false;
        drinkEcolhido = -1;
        existeCopo = false;
    }
}

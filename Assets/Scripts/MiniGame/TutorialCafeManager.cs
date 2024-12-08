using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialCafeManager : MonoBehaviour
{
    public static TutorialCafeManager Instance;
    public List<GameObject> steps;
    private int atualStep = -1;

    void Start()
    {
        Instance = this;
        foreach(Transform child in this.transform){
            steps.Add(child.gameObject);
            child.gameObject.SetActive(false); // garantindo que todos estão desabilitados
        }

        DisplayTutorial();
    }

    public void DisplayNextStep(){
        if(atualStep >= 0){
            steps[atualStep].SetActive(false);
        }
        if(atualStep < steps.Count-1){
            steps[++atualStep].SetActive(true);
        }else{
            atualStep = -1;
            ButtonsMiniGame.instance.Start_Btn();
        }
    }

    public void DisplayPreviousStep(){
        if(atualStep > 0){
            steps[atualStep--].SetActive(false);
        }
        steps[atualStep].SetActive(true);
    }

    public void DisplayTutorial(){
        DisplayNextStep();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foods : MonoBehaviour
{
    public GameObject[] options;
    public bool containerFull = false;
    public int chosenOption = -1;
    public bool containerExists;

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
            }
        }
        else {
            Debug.Log("Não tem Prato = Bolo na mesa");
        }
    }

    public void Reset_teste() {
        containerFull = false;
        chosenOption = -1;
        containerExists = false;
    }
}

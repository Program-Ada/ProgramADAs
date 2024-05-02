using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drinks : MonoBehaviour
{
    public GameObject[] drinks;
    public bool containerFull;
    public int drinkEcolhido;
    public bool existeCopo;

    void Start()
    {
        containerFull = false;
        drinkEcolhido = -1;
        existeCopo = false;
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
        }
    }
}

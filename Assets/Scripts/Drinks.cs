using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drinks : MonoBehaviour
{
    public GameObject[] drinks;
    private bool containerFull = false;

    void Start()
    {
    }

    public void Show_Drink(int i) {
        if (!containerFull) { 
            drinks[i].SetActive(true);
            containerFull = true;
        }
    }

    public void JogarFora() {
        for (int i = 0; i < drinks.Length; i++) {
            if (drinks[i].activeSelf) {
                drinks[i].SetActive(false);
                containerFull = false;
            }
        }
    }
}

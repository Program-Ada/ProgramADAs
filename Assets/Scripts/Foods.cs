using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foods : MonoBehaviour
{
    public GameObject[] foods;
    private bool containerFull = false;
    public int foodEcolhido = -1;

    void Start()
    {
    }

    public void Show_Food(int i) {
        if (!containerFull) { 
            foods[i].SetActive(true);
            containerFull = true;
            foodEcolhido = i;
        }
    }

    public void JogarFora() {
        for (int i = 0; i < foods.Length; i++) {
            if (foods[i].activeSelf) {
                foods[i].SetActive(false);
                containerFull = false;
                foodEcolhido = -1;
            }
        }
    }
}

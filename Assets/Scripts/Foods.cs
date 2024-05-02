using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foods : MonoBehaviour
{
    public GameObject[] foods;
    public bool containerFull = false;
    public int foodEcolhido = -1;
    public bool existePrato;

    void Start()
    {
        containerFull = false;
        foodEcolhido = -1;
        existePrato = false;
    }

    public void Show_Food(int i) {
        if(existePrato) {
            if (!containerFull) { 
                foods[i].SetActive(true);
                containerFull = true;
                foodEcolhido = i;
            }
        }
        else {
            Debug.Log("Não tem Prato = Bolo na mesa");
        }
    }
}

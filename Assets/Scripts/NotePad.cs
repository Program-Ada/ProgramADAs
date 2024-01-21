using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotePad : MonoBehaviour
{
    public Chapter chapter;
    public GameObject NotePadCanvas;
    public GameObject Player;

    public GameObject Menu;
    public GameObject Chapter1;
    public GameObject Chapter2;

    void Start()
    {
        NotePadCanvas.SetActive(false); 
        Menu.SetActive(true);
        Chapter1.SetActive(false);
        Chapter2.SetActive(false);
    }

    public void OpenNotePad() {
        Player.GetComponent<PlayerMovement>().enabled = false;
        NotePadCanvas.SetActive(true);   
    }

    public void CloseNotePad() {
        Player.GetComponent<PlayerMovement>().enabled = true;
        NotePadCanvas.SetActive(false);   
    }

    public void Screen_Menu() {
        Menu.SetActive(true);
        Chapter1.SetActive(false);
        Chapter2.SetActive(false);   
    }

    public void Screen_Chapter1() {
        Menu.SetActive(false);
        Chapter1.SetActive(true);
        Chapter2.SetActive(false);  
    }

    public void Screen_Chapter2() {
        Menu.SetActive(false);
        Chapter1.SetActive(false);
        Chapter2.SetActive(true);  
    }
}
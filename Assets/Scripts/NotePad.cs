using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotePad : MonoBehaviour
{
    public GameObject NotePadCanvas;
    public GameObject Player;
    public GameObject Menu;
    public GameObject NotificationCanvas;
    public GameObject Chapter1;
    public GameObject Chapter2;

    public ChapterManager cm;

    void Start()
    {
        NotePadCanvas.SetActive(false); 
        Menu.SetActive(true);
        NotificationCanvas.SetActive(true);
        Chapter1.SetActive(false);
        Chapter2.SetActive(false);

        cm = FindObjectOfType<ChapterManager>();
    }

    public void OpenNotePad() {
        Player.GetComponent<PlayerMovement>().enabled = false;
        NotePadCanvas.SetActive(true);
        NotificationCanvas.SetActive(false); 
    }

    public void CloseNotePad() {
        Player.GetComponent<PlayerMovement>().enabled = true;
        NotePadCanvas.SetActive(false);   
    }

    public void Screen_Menu() {
        Menu.SetActive(true);
        Chapter1.SetActive(false);
        Chapter2.SetActive(false);

        cm.ResetPage();
    }

    public void Screen_Chapter(GameObject chapterObject) {
        Menu.SetActive(false);
        chapterObject.SetActive(true);
        
    }

    public void Screen_Notificacao() {
        NotificationCanvas.SetActive(true);
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameAsk : MonoBehaviour
{
    public GameObject buttonFalse;
    public GameObject buttonTrue;
    public GameObject dialogueTextFalse;

    void Start()
    {
    }

    void Update()
    {

    }
    public void AnwserFalse(){
        // buttonFalse.SetActive(false);
        // buttonTrue.SetActive(false);
        // dialogueTextFalse.SetActive(true);
    }

    public void AnwserTrue(){
        // SceneManager.LoadScene("MiniGame_Cafe");    //adicionar proxima cena
    }
}

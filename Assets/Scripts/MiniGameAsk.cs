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
    public DialogueTrigger dialogueTrigger;

    void Start()
    {
    }

    void Update()
    {
        if(gameObject.activeSelf) {
            buttonFalse.SetActive(true);
            buttonTrue.SetActive(true);
            dialogueTextFalse.SetActive(false);
        }
    }
    public void AnwserFalse(){
        gameObject.SetActive(false);

        dialogueTextFalse.SetActive(true); //preciso desativar quando finalizar o dialogo

        //fica a duvida se da pra adicionar mais uma frase nas sentencas do Dialogue, pois daria menos problemas. Já q o SetActive vai interferir quando for ativá-lo novamente
    }

    public void AnwserTrue(){
        // SceneManager.LoadScene("MiniGame_Cafe");    //adicionar proxima cena
    }
}

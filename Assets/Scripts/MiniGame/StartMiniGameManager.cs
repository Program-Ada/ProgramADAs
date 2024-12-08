using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMiniGameManager : MonoBehaviour
{
    public static StartMiniGameManager Instance;
    public GameObject buttonFalse;
    public GameObject buttonTrue;
    public Animator animator;

    void Start(){
        Instance = this;
    }

    public void OpenAskMiniGame(){
        Enable_Buttons();
        animator.SetBool("IsOpen", true);
    }

    public void CloseAskMiniGame(){
        Disable_Buttons();
        animator.SetBool("IsOpen", false);
    }
    
    public void AnwserFalse() {
        CloseAskMiniGame();
    }

    public void AnwserTrue(){
        CloseAskMiniGame();
        SceneManager.LoadScene("MiniGame_Cafe");
    }

    public void Disable_Buttons(){
        buttonFalse.SetActive(false);
        buttonTrue.SetActive(false);
    }

    public void Enable_Buttons(){
        buttonFalse.SetActive(true);
        buttonTrue.SetActive(true);
    }
}

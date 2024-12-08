using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMiniGame : MonoBehaviour
{
    public GameObject exitConfirmationCanvas;

    private void Start() {
        exitConfirmationCanvas.SetActive(false);    
    }
    public void Exit_Button() {
        ButtonsMiniGame.instance.Disable_Buttons(); // implementar
        exitConfirmationCanvas.SetActive(true);
    }

    public void Exit_Cancel(){
        exitConfirmationCanvas.SetActive(false);
        ButtonsMiniGame.instance.Enable_Buttons();
    }

    public void Exit_Confirm(){
        SceneManager.LoadScene("Convivencia");
    }
}

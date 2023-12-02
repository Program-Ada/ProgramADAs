using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    public bool playerIsClose;
    public GameObject ExitOptionCanvas;
    public GameObject ExitOptionCanvasFalse;
    public GameObject Player;
    [SerializeField]GameObject toolTip;

    void Start(){
        ExitOptionCanvas.SetActive(false);
        ExitOptionCanvasFalse.SetActive(false);
        toolTip.SetActive(false);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose){
            TriggerExitOption();
        }
    }
    public void TriggerExitOption(){
        toolTip.SetActive(false);
        Player.GetComponent<PlayerMovement>().enabled = false;

        if(QuizManager.qm.passed){
            ExitOptionCanvas.SetActive(true);
        }else{
           ExitOptionCanvasFalse.SetActive(true); 
        }
    }

    public void ExitFalse(){
        Player.GetComponent<PlayerMovement>().enabled = true;
        ExitOptionCanvas.SetActive(false);
        ExitOptionCanvasFalse.SetActive(false);
    }

    public void ExitTrue(){
        SceneManager.LoadScene("End");
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = true;
            toolTip.SetActive(true);
        }
    }

        private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = false;
            toolTip.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    private bool playerIsClose;
    //public GameObject ExitOptionCanvas;
    //public GameObject ExitOptionCanvasFalse;
    //private GameObject Player;
    public string nextSceneName;
    public Vector2 SpawnNextScene;
    public TransitionManager tm;
    public SpawnManager sm;
    //public GameObject ExitConfirmationMenu;
    //public bool isFaseCompleted;
    [SerializeField]GameObject toolTip;

    void Start(){
        //ExitOptionCanvas.SetActive(false);
        //ExitOptionCanvasFalse.SetActive(false);
        toolTip.SetActive(false);
        sm = SpawnManager.Instance;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose){

            /*
            if(!isFaseCompleted){
                ExitConfirmationMenu.SetActive(true);
                Player.GetComponent<PlayerMovement>().enabled = false;

            }else{
                LoadNextScene();
            }
            */
            sm.playerSpawnPosition.x = SpawnNextScene.x;
            sm.playerSpawnPosition.y = SpawnNextScene.y;
            tm.PlayExitSceneAnimation(nextSceneName);
            //LoadNextScene();
        }
    }

    public void LoadNextScene(){
        SceneManager.LoadScene(nextSceneName);
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

    /*
    public void OkButton(){
        ExitConfirmationMenu.SetActive(false);
        Player.GetComponent<PlayerMovement>().enabled = true;

    }

    public void TriggerExitOption(){
        toolTip.SetActive(false);
        Player.GetComponent<PlayerMovement>().enabled = false;

        if(QuizManager.qm.passed){
            ExitOptionCanvas.SetActive(true);
        }else{
           ExitOptionCanvasFalse.SetActive(true); 
        }
    }*/

    /*public void ExitFalse(){
        Player.GetComponent<PlayerMovement>().enabled = true;
        ExitOptionCanvas.SetActive(false);
        ExitOptionCanvasFalse.SetActive(false);
    }*/

    /*public void ExitTrue(){
        SceneManager.LoadScene("End");
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    public GameObject escMenuCanvas;
    public GameObject Player;

    void Start()
    {
        escMenuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            TriggerEscMenu();
        }     
    }

    public void TriggerEscMenu(){
        escMenuCanvas.SetActive(true);
        Player.GetComponent<PlayerMovement>().enabled = false;
    }

    public void MenuButton(){
        SceneManager.LoadScene("Menu");
    }

    public void ContinueButton(){
        escMenuCanvas.SetActive(false);
        Player.GetComponent<PlayerMovement>().enabled = true;        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanel : MonoBehaviour
{
    //public Player p;
    public void QuitGame(){
        //p.SavePlayer();
        Application.Quit();
    }

    public void ReturnToMenu(){
        //p.SavePlayer();
        SceneManager.LoadScene("Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartFase3 : MonoBehaviour, IDataPersistence
{
    public static StartFase3 Instance;
    public GameObject buttonFalse;
    public GameObject buttonTrue;
    public Animator animator;
    public GameObject nataliaUnlocked;
    public GameObject nataliaLocked;
    private bool isLevelUnlocked = false;
    private bool isTrueClicked = false;

    void Start(){
        Instance = this;

        nataliaUnlocked.SetActive(false);
        nataliaLocked.SetActive(false);    

        if(isLevelUnlocked){
            nataliaUnlocked.SetActive(true);
        }else{
            nataliaLocked.SetActive(true);
        }
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
        isTrueClicked = true;
        DataPersistenceManager.Instance.SaveGame();
        CloseAskMiniGame();
        SceneManager.LoadScene("Fase3");
    }

    public void Disable_Buttons(){
        buttonFalse.SetActive(false);
        buttonTrue.SetActive(false);
    }

    public void Enable_Buttons(){
        buttonFalse.SetActive(true);
        buttonTrue.SetActive(true);
    }

    public void LoadData(GameData data){
        if(data.pointFases[1] >= 75){
            isLevelUnlocked = true;
        }
    }
    public void SaveData(ref GameData data){
        if(isTrueClicked){
            isTrueClicked = false;
            //coloquei 7 porque o ult ta 6 mas n sei se eh certo
            data.questProgressIndex = 7;
        }
    }
}

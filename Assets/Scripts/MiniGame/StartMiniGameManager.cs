using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMiniGameManager : MonoBehaviour, IDataPersistence
{
    public static StartMiniGameManager Instance;
    public GameObject buttonFalse;
    public GameObject buttonTrue;
    public Animator animator;
    public GameObject alessandreiaUnlocked;
    public GameObject alessandreiaLocked;
    private bool isLevelUnlocked = false;
    private bool isTrueClicked = false;

    void Start(){
        Instance = this;

        alessandreiaUnlocked.SetActive(false);
        alessandreiaLocked.SetActive(false);    

        if(isLevelUnlocked){
            alessandreiaUnlocked.SetActive(true);
        }else{
            alessandreiaLocked.SetActive(true);
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

    public void LoadData(GameData data){
        if(data.unlockedFases[1]){
            isLevelUnlocked = true;
        }
    }
    public void SaveData(ref GameData data){
        if(isTrueClicked && data.questProgressIndex == 4){
            isTrueClicked = false;
            data.questProgressIndex = 5;
        }
    }
}

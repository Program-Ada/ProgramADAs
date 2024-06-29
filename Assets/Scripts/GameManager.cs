using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IDataPersistence
{
    
    public static GameManager Instance;
    private int level;
    private bool[] isChapterUnlocked;
    public bool talkedToBarbara = false;

    void Awake () {
        if(Instance != null){
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void UpdateExclamation(){
        if(SceneManager.GetActiveScene().name == "Game"){
            GameObject.Find("Barbara/Exclamation").gameObject.SetActive(!isChapterUnlocked[0]);
            if(isChapterUnlocked[0]){
               FindObjectOfType<QuizTrigger>().ActivateQuizExclamation(); 
            }
        }
    }

    public void UnlockChapterOne(){
        if(!talkedToBarbara && !isChapterUnlocked[0] && SceneManager.GetActiveScene().name == "Game"){
            talkedToBarbara = true;
            GameObject.Find("Barbara/Exclamation").gameObject.SetActive(false);
            FindObjectOfType<QuizTrigger>().ActivateQuizExclamation();
            FindObjectOfType<NotePadManager>().UpdateNotePadNotification(true);
            FindObjectOfType<NotePadManager>().UpdateChapterBtn(0,true, true);
            FindObjectOfType<NotePadManager>().UpdateChapterNotification(0,true, true);
            FindObjectOfType<QuestManager>().UpdateQuestText(2);
        }
    }

    public void LoadData(GameData data){

        isChapterUnlocked = new bool[5];

        for(int i = 0; i < data.unlockedFases.Length; i++){
            isChapterUnlocked[i] = data.unlockedFases[i];
        }

        UpdateExclamation();
    }

    public void SaveData(ref GameData data){

    }
    
}

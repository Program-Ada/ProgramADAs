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

    private int QuizScore;
    public bool talkedToBarbara = false;
    public GameObject doorArrow;

    [Header("Scripts")]
    private DialogueTrigger dialogueTrigger;
    private QuizTrigger quizTrigger;
    private NotePadManager notepadManager;
    private QuestManager questManager;


    void Awake () {
        if(Instance != null){
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void FindScripts(){
        dialogueTrigger = FindObjectOfType<DialogueTrigger>();
        quizTrigger = FindObjectOfType<QuizTrigger>();
        notepadManager = FindObjectOfType<NotePadManager>();
        questManager = FindObjectOfType<QuestManager>();
    }

    public void UpdateExclamation(){
        if(SceneManager.GetActiveScene().name == "Game"){

            GameObject.Find("Barbara/Exclamation").SetActive(!isChapterUnlocked[0]);
            doorArrow = GameObject.Find("Door/Arrow").gameObject;
            doorArrow.SetActive(isChapterUnlocked[0] && (QuizScore > 75));

            if(isChapterUnlocked[0] && QuizScore < 75){
                quizTrigger.ActivateQuizExclamation(); 
            }
        }
    }

    public void UnlockChapterOne(){
        if(!talkedToBarbara && !isChapterUnlocked[0] && SceneManager.GetActiveScene().name == "Game"){
            talkedToBarbara = true;
            dialogueTrigger.barbaraExclamation.SetActive(false);
            quizTrigger.ActivateQuizExclamation();
            notepadManager.UpdateNotePadNotification(true);
            notepadManager.UpdateChapterBtn(0,true, true);
            notepadManager.UpdateChapterNotification(0,true, true);
            questManager.UpdateQuestText(2);
        }
    }

    public void LoadData(GameData data){

        isChapterUnlocked = new bool[5];

        for(int i = 0; i < data.unlockedFases.Length; i++){
            isChapterUnlocked[i] = data.unlockedFases[i];
        }

        QuizScore = data.pointFases[0];

        FindScripts();
        UpdateExclamation();
    }

    public void SaveData(ref GameData data){

    }
    
}

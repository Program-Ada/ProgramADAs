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

    public float QuizScore;
    public bool talkedToBarbara = false;
    public GameObject barbaraExclamation;
    public bool isBarbaraExclamationActive;
    public GameObject doorExclamation;


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

    public void FindScriptsAndObjects(){
        dialogueTrigger = FindObjectOfType<DialogueTrigger>();
        notepadManager = FindObjectOfType<NotePadManager>();
        questManager = FindObjectOfType<QuestManager>();

        if(SceneManager.GetActiveScene().name == "Game"){
            quizTrigger = FindObjectOfType<QuizTrigger>();
            doorExclamation = GameObject.Find("Door/Exclamation").gameObject;
            barbaraExclamation = GameObject.Find("Barbara/Exclamation").gameObject;
        }
    }

    public void UpdateExclamation(){ // chama toda vez que muda de cena
        if(SceneManager.GetActiveScene().name == "Game"){

            barbaraExclamation.SetActive(!talkedToBarbara);
            isBarbaraExclamationActive = !talkedToBarbara;
            quizTrigger.UpdateQuizExclamation(QuizScore < 75 && talkedToBarbara); 
            doorExclamation.SetActive(QuizScore > 75);
            UnlockChapterOne();

            /*
            if(doorExclamation.activeSelf){
                FindObjectOfType<ExitDoor>().isFaseCompleted = true;
            }
            */
        }
    }

    public void UnlockChapterOne(){
        if(!isChapterUnlocked[0] && SceneManager.GetActiveScene().name == "Game"){
            isChapterUnlocked[0] = true;
            notepadManager.UpdateNotePadNotification(true);
            notepadManager.UpdateChapterBtn(0,true, true);
            notepadManager.UpdateChapterNotification(0,true, true);
        }
    }

    public void UnlockQuiz(){
        talkedToBarbara = true;
        barbaraExclamation.SetActive(false);
        isBarbaraExclamationActive = false;
        //dialogueTrigger.isExclamationActive = false;
        //dialogueTrigger.UpdateBarbaraExclamation(false);
        quizTrigger.UpdateQuizExclamation(true);
        questManager.UpdateQuestText(2);
    }

    public void LoadData(GameData data){

        isChapterUnlocked = new bool[5];

        if(data.questProgressIndex > 1){
            talkedToBarbara = true;
        }

        for(int i = 0; i < data.unlockedFases.Length; i++){
            isChapterUnlocked[i] = data.unlockedFases[i];
        }

        QuizScore = data.pointFases[0];

        FindScriptsAndObjects();
        UpdateExclamation();
    }

    public void SaveData(ref GameData data){

    }
    
}

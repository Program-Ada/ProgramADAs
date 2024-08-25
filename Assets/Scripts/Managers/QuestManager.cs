using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour, IDataPersistence
{
    [Header("Canva Text")]
        public TextMeshProUGUI questText;
        public Animator animator;

        //public static QuestManager Instance;

        private bool[] isChapterUnlocked;
        private int[] pointFases;
        private int progressIndex;

    // Start is called before the first frame update
    void Start()
    {
        if(!FindObjectOfType<Tutorial>().TutorialCanvas.activeSelf){ 
            animator.SetBool("isOpen", true);
        }
    }

    public void DisplayNextSentence(string sentence){
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence){
        questText.text = "";
        foreach(char letter in sentence.ToCharArray()){
            questText.text += letter;
            yield return new WaitForSeconds((float)0.05);
        }
    }

    public void UpdateQuestText(int index){
        Debug.Log("Atualiza");
        Debug.Log("ProgressIndex: "+progressIndex);
        if(progressIndex == 1 || index == 1){
            DisplayNextSentence("Fale com a Professora Bárbara");
            progressIndex = 1;
        }
        if(progressIndex > 1 || index > 1){
            if(pointFases[0] == 0 || index == 2){
                DisplayNextSentence("Realize o Quiz Introdutório");
                progressIndex = 2;
            }
            if(pointFases[0] != 0 || index > 2){
                if(pointFases[0] < 75 || index == 3){
                    DisplayNextSentence("Consiga uma nota maior que 75% no Quiz para avançar");
                    progressIndex = 3;
                }
                if(pointFases[0] >= 75 || index == 4){
                    DisplayNextSentence("Vá ao Centro de Convivência");
                    progressIndex = 4;
                }
            }
        }
    }

    public void LoadData(GameData data){

        isChapterUnlocked = new bool[data.unlockedFases.Length];
        pointFases = new int[data.pointFases.Length];
        progressIndex = data.questProgressIndex;

        for(int i = 0; i < data.unlockedFases.Length; i++){
            isChapterUnlocked[i] = data.unlockedFases[i];
            pointFases[i] = data.pointFases[i];
        }

        UpdateQuestText(progressIndex);
    }
    public void SaveData(ref GameData data){
        if(progressIndex != 0){
            data.questProgressIndex = progressIndex;
        }
    }
}

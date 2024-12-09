using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Diagnostics;

public class NotePadManager : MonoBehaviour, IDataPersistence
{
    [Header("Canvas Items")]
        public GameObject NotePadCanvas;
        public GameObject ChapterSelectionMenu;
        public GameObject ChapterCanvas;
        public GameObject NotePadNotification; // Notificação do icone no canto da tela

    [Header("Chapters")]
        public GameObject[] Chapter_Buttons;

    [Header("Managers")]
        private ChapterManager cm;
    
    [Header("Outros")]
        private GameObject Player;
        public bool[] isChapterUnlocked;
        private bool[] isChapterNotificationOn;
        private bool isUpdated;

    public static NotePadManager Instance {get; private set;}

    void Awake()
    {
        Instance = this;
        Player = GameObject.FindGameObjectWithTag("Player");

        //cm = FindObjectOfType<ChapterManager>();
        isChapterUnlocked = new bool[5];
        isChapterNotificationOn = new bool[5];
        isUpdated = false;

        NotePadCanvas.SetActive(false);
        NotePadNotification.SetActive(false);

        ChapterSelectionMenu.SetActive(true);
        ChapterCanvas.SetActive(false);
    }

    public void OpenNotePad()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        NotePadCanvas.SetActive(true);
        NotePadNotification.SetActive(false);

        FindObjectOfType<QuestManager>().animator.SetBool("isOpen", false);
    }

    public void CloseNotePad()
    {
        Player.GetComponent<PlayerMovement>().enabled = true;
        NotePadCanvas.SetActive(false);

        FindObjectOfType<QuestManager>().animator.SetBool("isOpen", true);
    }

    public void Screen_ChapterSelectionMenu()
    {

        ChapterCanvas.SetActive(false);
        ChapterSelectionMenu.SetActive(true);
        
        ChapterManager.instance.ResetPage();
    }

    public void Screen_Chapter(GameObject chapterObject)
    {
        GameObject notification = EventSystem.current.currentSelectedGameObject.transform.Find("Notification").gameObject;
        notification.SetActive(false);

        ChapterSelectionMenu.SetActive(false);
        ChapterCanvas.SetActive(true);

        Chapter chapterContent = chapterObject.GetComponent<ChapterContent>().chapter;
        ChapterManager.instance.ShowChapter(chapterContent);
    }

    public void SaveNewData(){
        isUpdated = true;
        DataPersistenceManager.Instance.SaveGame();
        isUpdated = false;
    }

    public void UpdateChapterBtn(int chapterNumber, bool isUnlocked, bool isNew){
        isChapterUnlocked[chapterNumber] = isUnlocked;
        Chapter_Buttons[chapterNumber].transform.Find("Locked").gameObject.SetActive(!isUnlocked);
        Chapter_Buttons[chapterNumber].transform.Find("Unlocked").gameObject.SetActive(isUnlocked);
        Chapter_Buttons[chapterNumber].GetComponent<Button>().interactable = isUnlocked;

        if(isNew == true){
            SaveNewData();
        }
    }

    public void UpdateChapterNotification(int chapterNumber, bool isNotificationOn, bool isNew){
        isChapterNotificationOn[chapterNumber] = isNotificationOn;
        Chapter_Buttons[chapterNumber].transform.Find("Notification").gameObject.SetActive(isNotificationOn);

        if(isNew == true){
            SaveNewData();
        }
    }

    public void UpdateNotePadNotification(bool isOn){
        NotePadNotification.SetActive(isOn);
    }

    // Lembrar de colocar a tag nos novos Chapter_Btn criados
    public void LoadData(GameData data){

        for(int i = 0; i < Chapter_Buttons.Length; i++){

            UnityEngine.Debug.Log("Chapter: " + i);
            UnityEngine.Debug.Log("unlocked fases: " + data.unlockedFases[i]);

            UpdateChapterBtn(i, data.unlockedFases[i], false); // bloqueia ou desbloqueia o capítulo
            UpdateChapterNotification(i, data.isNotificationOn[i], false); // ativa ou desativa a notificação

            if(data.isNotificationOn[i]){
                UpdateNotePadNotification(true);
            }
        }
    }

    public void SaveData(ref GameData data){

        if(isUpdated){ // como não é um sigleton os dados sempre resetam, então só deixa salvar se estiver atualizado
            for(int i = 0; i < Chapter_Buttons.Length; i++){

                data.isNotificationOn[i] = isChapterNotificationOn[i];
                data.unlockedFases[i] = isChapterUnlocked[i];

            }
        }
    }

}

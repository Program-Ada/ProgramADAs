using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NotePadManager : MonoBehaviour, IDataPersistence
{
    [Header("Canvas Items")]
        public GameObject NotePadCanvas;
        public GameObject ChapterSelectionMenu;
        public GameObject ChapterCanvas;
        public GameObject NotePadNotification; // Notificação do icone no canto da tela

    [Header("Chapters")]
        //public GameObject Chapter1;
        //public GameObject Chapter2;
        public GameObject[] Chapter_Buttons;

    [Header("Managers")]
        //private GameManager gameManager;
        private ChapterManager cm;
    
    [Header("Outros")]
        //public int fase;
        private GameObject Player;
        public bool[] isChapterUnlocked;
        private bool[] isChapterNotificationOn;
        private bool isUpdated;

    public static NotePadManager Instance {get; private set;}

    //void Awake(){

        /*
        if(Instance != null){
            Debug.Log("Existe mais de um Note Pad Manager na scena. Destruindo o arquivo novo");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this.gameObject);
        */

        //Debug.Log("Awake NotePadManager");
    //}

    void Awake()
    {
        //SceneManager.sceneLoaded += OnSceneLoaded;
        Player = GameObject.FindGameObjectWithTag("Player");
        //gameManager = FindObjectOfType<GameManager>();
        cm = FindObjectOfType<ChapterManager>();
        isChapterUnlocked = new bool[5];
        isChapterNotificationOn = new bool[5];
        isUpdated = false;

        //fase = gameManager.level;
 
        //NotePadCanvas = GameObject.FindGameObjectWithTag("NotePadCanvas");
        //NotePadNotification = GameObject.FindGameObjectWithTag("NotePadNotification");

        NotePadCanvas.SetActive(false);
        NotePadNotification.SetActive(false);

        ChapterSelectionMenu.SetActive(true);
        ChapterCanvas.SetActive(false);

        // Conteúdo dos Capítulos
        //Chapter1.SetActive(false); 
        //Chapter2.SetActive(false);

        //DataPersistenceManager.Instance.LoadGame();
 
    }

    /*
    void Update() {
        //fase = gameManager.level; 
    }
    */

    public void OpenNotePad()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        NotePadCanvas.SetActive(true);
        NotePadNotification.SetActive(false);

        FindObjectOfType<QuestManager>().animator.SetBool("isOpen", false);

        /*
        if(Chapter_Buttons.Length == 0) {
            Chapter_Buttons = GameObject.FindGameObjectsWithTag("Chapter_Btn");
            for (int i = Chapter_Buttons.Length; i > 0; i--) {
                Chapter_Buttons[i-1].SetActive(false);
            }
        }
        */
        //Screen_Menu();
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

        /*
        if (!Chapter_Buttons[fase-1].activeSelf) {   
            Chapter_Buttons[fase-1].SetActive(true);
        }
        */
        
        //Chapter1.SetActive(false);
        //Chapter2.SetActive(false);
        
        cm.ResetPage();
    }

    public void Screen_Chapter(GameObject chapterObject)
    {
        GameObject notification = EventSystem.current.currentSelectedGameObject.transform.Find("Notification").gameObject;
        notification.SetActive(false);

        ChapterSelectionMenu.SetActive(false);
        ChapterCanvas.SetActive(true);

        Chapter chapterContent = chapterObject.GetComponent<ChapterContent>().chapter;
        cm.ShowChapter(chapterContent);
    }

    /*
    private void OnSceneLoaded(Scene cena, LoadSceneMode loadSceneMode)
    {
        if (cena.name == "End") {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            GameObject.Destroy(this.gameObject);
        }
        else {
            //acho q aqui vai dar problema quando mudar de cena mas não mudar a fase, dai acho q da pra criar uma variavel "faseInicial" e verificar se mudou de fase ou so de cena
            NotePadNotification.SetActive(true);
            Player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    */ 

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

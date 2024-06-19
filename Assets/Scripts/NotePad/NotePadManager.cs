using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class NotePadManager : MonoBehaviour
{
    [Header("Canvas Items")]
        public GameObject NotePadCanvas;
        public GameObject ChapterSelectionMenu;
        public GameObject ChapterCanvas;
        public GameObject NotePadNotification;

    [Header("Chapters Contents")]
        public GameObject Chapter1;
        public GameObject Chapter2;
        //public GameObject[] Chapter_Buttons;

    [Header("Managers")]
        private GameManager gameManager;
        private ChapterManager cm;
    
    [Header("Outros")]
        public int fase;
        private GameObject Player;

    public static NotePadManager Instance {get; private set;}

    void Awake(){

        if(Instance != null){
            Debug.Log("Existe mais de um Note Pad Manager na scena. Destruindo o arquivo novo");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        //SceneManager.sceneLoaded += OnSceneLoaded;

        Player = GameObject.FindGameObjectWithTag("Player");
        gameManager = FindObjectOfType<GameManager>();
        cm = FindObjectOfType<ChapterManager>();
        fase = gameManager.level;
 
        //NotePadCanvas = GameObject.FindGameObjectWithTag("NotePadCanvas");
        //NotePadNotification = GameObject.FindGameObjectWithTag("NotePadNotification");

        NotePadCanvas.SetActive(false);
        NotePadNotification.SetActive(true);

        ChapterSelectionMenu.SetActive(true);
        ChapterCanvas.SetActive(false);

        // Conteúdo dos Capítulos
        //Chapter1.SetActive(false); 
        //Chapter2.SetActive(false);
 
    }

    void Update() {
        fase = gameManager.level; 
    }

    public void OpenNotePad()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        NotePadCanvas.SetActive(true);
        NotePadNotification.SetActive(false);

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

        Chapter chapterContent = chapterObject.GetComponent<NotePadTrigger>().chapter;
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

}

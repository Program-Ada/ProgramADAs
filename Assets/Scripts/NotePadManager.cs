using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NotePadManager : MonoBehaviour
{
    public int fase;
    private GameManager gameManager;
    private GameObject Player;
    private GameObject NotePadCanvas;
    private GameObject NotePadNotification;
    public GameObject Menu;
    public GameObject Chapter1;
    public GameObject Chapter2;
    private ChapterManager cm;
    public GameObject[] Chapter_Buttons;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

        // fase = 1;
        gameManager = FindObjectOfType<GameManager>();
        fase = gameManager.level;

        Player = GameObject.FindGameObjectWithTag("Player");
        NotePadCanvas = GameObject.FindGameObjectWithTag("NotePadCanvas");
        NotePadCanvas.SetActive(false);
        NotePadNotification = GameObject.FindGameObjectWithTag("NotePadNotification");
        NotePadNotification.SetActive(true);

        Menu.SetActive(true);
        Chapter1.SetActive(false);
        Chapter2.SetActive(false);

        cm = FindObjectOfType<ChapterManager>();
    }

    void Update() {
        fase = gameManager.level;
    }

    public void OpenNotePad()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        NotePadCanvas.SetActive(true);
        NotePadNotification.SetActive(false);

        if(Chapter_Buttons.Length == 0) {
            Chapter_Buttons = GameObject.FindGameObjectsWithTag("Chapter_Btn");
            for (int i = Chapter_Buttons.Length; i > 0; i--) {
                Chapter_Buttons[i-1].SetActive(false);
            }
        }
        Screen_Menu();
    }

    public void CloseNotePad()
    {
        Player.GetComponent<PlayerMovement>().enabled = true;
        NotePadCanvas.SetActive(false);
    }

    public void Screen_Menu()
    {
        Menu.SetActive(true);
        if (!Chapter_Buttons[fase-1].activeSelf) {   
            Chapter_Buttons[fase-1].SetActive(true);
        }
        Chapter1.SetActive(false);
        Chapter2.SetActive(false);

        cm.ResetPage();
    }

    public void Screen_Chapter(GameObject chapterObject)
    {
        Menu.SetActive(false);
        chapterObject.SetActive(true);
    }

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
}

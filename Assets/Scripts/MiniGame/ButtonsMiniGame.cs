using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;
using TMPro;

public class ButtonsMiniGame : MonoBehaviour
{
    // public GameObject pedidos;
    // public GameObject drink_btn;
    // public GameObject food_btn;
    // public GameObject pratoSujo;
    // public GameObject[] vidas;
    private Orders pedidos;
    private Drinks drinks;
    private Foods foods;
    private Button[] buttons;
    public GameObject copo;
    public GameObject pratoLimpo;
    public GameObject aleErroSemCopo;
    public GameObject[] emojis;
    public List<GameObject> vidas;
    private int orderCount = 0;
    public TextMeshProUGUI orderCountText;
    public static ButtonsMiniGame instance;

    void Start()
    {
        instance = this;
        pedidos = FindObjectOfType<Orders>();
        drinks = FindAnyObjectByType<Drinks>();
        foods = FindAnyObjectByType<Foods>();
        buttons = GetComponentsInChildren<Button>();
        Disable_Buttons();
    }

    public void Start_Btn() {
        if (!pedidos.pedidoEmAndamento) {  
            Enable_Buttons();
            Update_Counter();
            Clients.instance.CallClient();
            Orders.instance.Invoke("Show_Order", 1); // espera a animação da personagem entrando terminar (por algum motivo 1s só é o suficiente ao invés de 3s)
        }
        else {
            Debug.Log("Já tem um pedido em andamento, não pode iniciar outro");
        }
    }

    public void Verifica_Btn() {
        if((pedidos.pedidoAtual.GetComponent<Pedido>().drink == drinks.chosenOption) && (pedidos.pedidoAtual.GetComponent<Pedido>().food == foods.chosenOption)) {
            Debug.Log("Drink e food corretos");
            emojis[0].SetActive(true);
        }
        else if((pedidos.pedidoAtual.GetComponent<Pedido>().drink == drinks.chosenOption) || (pedidos.pedidoAtual.GetComponent<Pedido>().food == foods.chosenOption)) {
            Debug.Log("Drink ou food incorreto");
            emojis[1].SetActive(true);
            PerdeVida();
            ScoreCafe.instance.Update_Score(1);
        }
        else {
            Debug.Log("Drink e food incorretos");
            emojis[2].SetActive(true);
            PerdeVida();
            ScoreCafe.instance.Update_Score(2);
        }

        Invoke(nameof(ResetOrder), 2);
        Invoke(nameof(IsGameFinished), 3);

    }
    public void IsGameFinished(){ // verifica se o jogo acabou ou não
        if(vidas.Count > 0){
            if(orderCount < CafeManager.instance.maxOrders){
                Clients.instance.ExitClient();
                Invoke(nameof(Start_Btn), 4); // tempo da animação de saída (3) + 1 para evitar bugs
            }else{
                CafeManager.instance.Finish_Game(true);
            }
        }else{
            CafeManager.instance.Finish_Game(false);
        }
    }

    public void Pegar_Suco() {
        //drink_btn.SetActive(true);
        //buttons[2].interactable = false;
    }

    public void Pegar_Bolo() {
        //food_btn.SetActive(true);
        //buttons[3].interactable = false;
    }

    public void Pegar_Copo() {
        drinks.containerExists = true;
        copo.SetActive(true);
    }

    public void Pegar_Prato() {
        foods.containerExists = true;
        pratoLimpo.SetActive(true);
    }

    public void JogarFora_Drink() {
        for (int i = 0; i < drinks.options.Length; i++) {
            if (drinks.options[i].activeSelf) {
                drinks.options[i].SetActive(false);
            }
        }
        drinks.Reset_teste();
        //drink_btn.SetActive(false);
        //buttons[2].interactable = true;
    }

    public void JogarFora_Food() {
        for (int i = 0; i < foods.options.Length; i++) {
            if (foods.options[i].activeSelf) {
                foods.options[i].SetActive(false);
            }
        }
        foods.Reset_teste();
        //food_btn.SetActive(false);
        //buttons[3].interactable = true;
    }

    public void Trash() {
        JogarFora_Drink();
        JogarFora_Food();
        drinks.Reset_option();
        foods.Reset_option();
    }

    public void ResetOrder() {
        // pedidos.Stop_Order();
        //drink_btn.SetActive(false);
        //food_btn.SetActive(false);

        JogarFora_Drink();
        JogarFora_Food();

        drinks.Reset_option();
        foods.Reset_option();

        pedidos.Stop_Order();
        Reset_emoji();
    }

    public void Reset_emoji() {
        for (int i = 0; i < emojis.Length; i++) {
            if (emojis[i].activeSelf) {
                emojis[i].SetActive(false);
            }
        }
    }

    public void PerdeVida() {
        vidas[vidas.Count - 1].SetActive(false);
        vidas.RemoveAt(vidas.Count -1);

        if (vidas.Count == 0) {
            Debug.Log("morreu! vidas: " + vidas.Count);
            CafeManager.instance.Finish_Game(false);
        }
    }

    public void Reset_Counter(){
        orderCount = 0;
        orderCountText.text = orderCount.ToString() + "/6";
    }

    public void Update_Counter(){
        orderCount++;
        orderCountText.text = orderCount.ToString() + "/6";
    }

    public void Disable_Buttons(){
        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].interactable = false;
        }
    }

    public void Enable_Buttons(){
        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].interactable = true;
        }
    }
}

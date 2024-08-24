using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;
using UnityEditor.SearchService;

public class ButtonsMiniGame : MonoBehaviour
{
    // public GameObject pedidos;
    private Orders pedidos;
    private Drinks drinks;
    private Foods foods;
    private Button[] buttons;
    public GameObject drink_btn;
    public GameObject food_btn;
    public GameObject copo;
    public GameObject pratoLimpo;
    public GameObject pratoSujo;
    public GameObject aleErroSemCopo;
    public GameObject[] emojis;
    // public GameObject[] vidas;
    public List<GameObject> vidas;

    void Start()
    {
        pedidos = FindObjectOfType<Orders>();
        drinks = FindAnyObjectByType<Drinks>();
        foods = FindAnyObjectByType<Foods>();
        buttons = GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].interactable = false;
        }
    }

    public void Start_Btn() {
        if (!pedidos.pedidoEmAndamento) {  
            pedidos.Show_Order();
            for (int i = 0; i < buttons.Length; i++) {
                buttons[i].interactable = true;
            }
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
            perdeVida();
        }
        else {
            Debug.Log("Drink e food incorretos");
            emojis[2].SetActive(true);
            perdeVida();
        }

        Invoke(nameof(ResetOrder), 4);
    }

    public void Pegar_Suco() {
        drink_btn.SetActive(true);
        buttons[2].interactable = false;
    }

    public void Pegar_Bolo() {
        food_btn.SetActive(true);
        buttons[3].interactable = false;
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
        drink_btn.SetActive(false);
        buttons[2].interactable = true;
    }

    public void JogarFora_Food() {
        for (int i = 0; i < foods.options.Length; i++) {
            if (foods.options[i].activeSelf) {
                foods.options[i].SetActive(false);
            }
        }
        foods.Reset_teste();
        food_btn.SetActive(false);
        buttons[3].interactable = true;
    }

    public void Trash() {
        JogarFora_Drink();
        JogarFora_Food();
        drinks.reset_option();
        foods.reset_option();
    }

    public void ResetOrder() {
        // pedidos.Stop_Order();
        JogarFora_Drink();
        drink_btn.SetActive(false);
        JogarFora_Food();
        food_btn.SetActive(false);

        drinks.reset_option();
        foods.reset_option();

        pedidos.Stop_Order();
        reset_emoji();
    }

    public void reset_emoji() {
        for (int i = 0; i < emojis.Length; i++) {
            if (emojis[i].activeSelf) {
                emojis[i].SetActive(false);
            }
        }
    }

    public void perdeVida() {
        vidas[vidas.Count - 1].SetActive(false);
        vidas.RemoveAt(vidas.Count -1);

        if (vidas.Count == 0) {
            Debug.Log("morreu! vidas: " + vidas.Count);
            //implementar recomecar jogo
        }
    }

    public void buttonSair() {
        //implementar pergunta de confirmacao
        SceneManager.LoadScene("Fase_cafe");
    }
}

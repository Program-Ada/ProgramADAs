using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;

public class ButtonsMiniGame : MonoBehaviour
{
    // public GameObject pedidos;
    public Orders pedidos;
    public Drinks drinks;
    public Foods foods;
    public GameObject drink_btn;
    public GameObject food_btn;
    public Button[] buttons;

    public GameObject copo;
    public GameObject prato;

    // public DialogueTrigger dialogueTrigger;
    public GameObject aleErroSemCopo;
    public GameObject[] emojis;

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
        }
        else {
            Debug.Log("Drink e food incorretos");
            emojis[2].SetActive(true);
        }

        ResetOrder();
    }

    public void ResetScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Feedback_Test() {
        aleErroSemCopo.SetActive(true);
        functionToWait(10); //dialogo não abre na primeira vez pq ainda nao existe, mas na segunda abre
        aleErroSemCopo.GetComponent<DialogueTrigger>().TriggerDialogue();
        // aleErroSemCopo.SetActive(true);
        // if(aleErroSemCopo.activeSelf) {
        //     aleErroSemCopo.GetComponent<DialogueTrigger>().TriggerDialogue();
        // }
    }

    IEnumerator functionToWait(int duration) {
        yield return new WaitForSeconds(duration);
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
        prato.SetActive(true);
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

    public void Verifica_Drink() {
        if(pedidos.pedidoAtual.GetComponent<Pedido>().drink == drinks.chosenOption) {
            Debug.Log("Drink correto");
        }
        // if(pedidos.GetComponent<Order>().chosenOptionDrink == drinks.chosenOption) {
        //     Debug.Log("Drink correto ORDER");
        // }
        else {
            Debug.Log("Drink Incorreto");
        }
    }

    public void Verifica_Food() {
        if(pedidos.pedidoAtual.GetComponent<Pedido>().food == foods.chosenOption) {
            Debug.Log("Food correto");
        }
        else {
            Debug.Log("Food Incorreto");
        }
    }

    public void ResetOrder() {
        // pedidos.Stop_Order();
        JogarFora_Drink();
        drink_btn.SetActive(false);
        JogarFora_Food();
        food_btn.SetActive(false);

        reset_drinkOption();
        reset_foodOption();

        functionToWait(10);
        pedidos.Stop_Order();
        reset_emoji();
    }

    public void reset_drinkOption() {
        for (int i = 0; i < drinks.drinkOptions.Length; i++) {
            if (drinks.drinkOptions[i].activeSelf) {
                drinks.drinkOptions[i].SetActive(false);
            }
        }
    }
    public void reset_foodOption() {
        for (int i = 0; i < foods.foodOptions.Length; i++) {
            if (foods.foodOptions[i].activeSelf) {
                foods.foodOptions[i].SetActive(false);
            }
        }
    }
    public void reset_emoji() {
        for (int i = 0; i < emojis.Length; i++) {
            if (emojis[i].activeSelf) {
                emojis[i].SetActive(false);
            }
        }
    }
}

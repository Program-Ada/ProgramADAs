using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsMiniGame : MonoBehaviour
{
    // public GameObject pedidos;
    public Orders pedidos;
    public Drinks drinks;
    public Foods foods;
    public GameObject drink_btn;
    public GameObject food_btn;
    public Button[] buttons;

    void Start()
    {
        pedidos = FindObjectOfType<Orders>();
        drinks = FindAnyObjectByType<Drinks>();
        foods = FindAnyObjectByType<Foods>();
        // drinks = GetComponent<Drinks>();
        buttons = GetComponentsInChildren<Button>();
        Debug.Log(buttons.Length);
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
        Verifica_Drink();
        Verifica_Food();
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
        drinks.existeCopo = true;
    }

    public void Pegar_Prato() {
        foods.existePrato = true;
    }

    public void JogarFora_Drink() {
        for (int i = 0; i < drinks.drinks.Length; i++) {
            if (drinks.drinks[i].activeSelf) {
                drinks.drinks[i].SetActive(false);
            }
        }
        drinks.Reset_teste();
        drink_btn.SetActive(false);
        buttons[2].interactable = true;
    }

    public void JogarFora_Food() {
        for (int i = 0; i < foods.foods.Length; i++) {
            if (foods.foods[i].activeSelf) {
                foods.foods[i].SetActive(false);
            }
        }
        foods.Reset_teste();
        food_btn.SetActive(false);
        buttons[3].interactable = true;
    }

    public void Verifica_Drink() {
        if(pedidos.pedidoAtual.GetComponent<Pedido>().drink == drinks.drinkEcolhido) {
            Debug.Log("Drink correto");
        }
        else {
            Debug.Log("Drink Incorreto");
        }
    }

    public void Verifica_Food() {
        if(pedidos.pedidoAtual.GetComponent<Pedido>().food == foods.foodEcolhido) {
            Debug.Log("Food correto");
        }
        else {
            Debug.Log("Food Incorreto");
        }
        pedidos.Stop_Order();
        JogarFora_Drink();
        drink_btn.SetActive(false);
        JogarFora_Food();
        food_btn.SetActive(false);
    }
}

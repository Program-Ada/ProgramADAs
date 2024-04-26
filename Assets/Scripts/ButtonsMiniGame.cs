using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsMiniGame : MonoBehaviour
{
    // public GameObject pedidos;
    public Orders pedidos;
    public Drinks drinks;
    public Foods foods;
    public GameObject drink_btn;
    public GameObject food_btn;
    public bool pedidoEmAndamento;
    void Start()
    {
        pedidos = FindObjectOfType<Orders>();
        drinks = FindAnyObjectByType<Drinks>();
        foods = FindAnyObjectByType<Foods>();
        // drinks = GetComponent<Drinks>();
        pedidoEmAndamento = false;
    }
    public void Start_Btn() {
        if (!pedidoEmAndamento) {  
            pedidos.Show_Order();
        }
    }

    public void Verifica_Btn() {
        Verifica_Drink();
        Verifica_Food();
    }

    public void Show_DrinkOptions() {
        drink_btn.SetActive(true);
        // int i = 0;
        // while(i == 0) {
        //     // i = drinks.Show_Drink();
        // }
        //i = retorno do Show_Drink
        // if(pedidos.pedidoAtual.GetComponent<Pedido>().drink == drinks.drinkEcolhido) {
        //     Debug.Log("Drink correto");
        // }
        // Debug.Log("Tente de novo");
    }

    public void Show_FoodOptions() {
        food_btn.SetActive(true);
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
        drinks.JogarFora();
        drink_btn.SetActive(false);
        foods.JogarFora();
        food_btn.SetActive(false);
    }
}

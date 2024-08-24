using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public Drinks drinks;
    public Foods foods;
    public List<GameObject> optionsDrinks;
    public List<GameObject> optionsFoods;
    public int chosenOptionDrink;
    public int chosenOptionFood;
    void Start()
    {
        drinks = FindAnyObjectByType<Drinks>();
        foods = FindAnyObjectByType<Foods>();

        optionsDrinks = new List<GameObject>(drinks.options);
        optionsFoods = new List<GameObject>(foods.options);

        VerificaCreate();
    }

    public void VerificaCreate() {
        //Não testado
        if (!Create_Drink() || !Create_Food())
        {
            Debug.Log("Nenhum pedido na lista");
        }
        else {
            Create_Drink();
            Create_Food();
        }
    }

    public bool Create_Drink() {
        if(optionsDrinks.Count > 0) {
            int randomNumber = Random.Range(0, optionsDrinks.Count);
            GameObject drink = optionsDrinks[randomNumber];
            drink.transform.position = new Vector3(5, 4.4f, 0);
            // drink.name = "Drink";
            drink.transform.SetParent(this.gameObject.transform);
            drink.SetActive(true);

            chosenOptionDrink = randomNumber;
            return true;
        }
        else {
            return false;
        }
    }

    public bool Create_Food() {
        if(optionsFoods.Count > 0) {
            int randomNumber = Random.Range(0, optionsFoods.Count);
            GameObject food = optionsFoods[randomNumber];
            food.transform.position = new Vector3(6.5f, 4.4f, 0);
            // food.name = "Food";
            food.transform.SetParent(this.gameObject.transform);
            food.SetActive(true);

            chosenOptionFood = randomNumber;
            return true;
        }
        else {
            return false;
        }
    }
}

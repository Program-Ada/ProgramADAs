using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsMiniGame : MonoBehaviour
{
    public GameObject drink_btn;
    public GameObject food_btn;
    void Start()
    {

    }
    public void Show_DrinkOptions() {
        drink_btn.SetActive(true);
    }

    public void Show_FoodOptions() {
        food_btn.SetActive(true);
    }
}

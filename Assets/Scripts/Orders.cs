using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Orders : MonoBehaviour
{
    public List<GameObject> orders;
    public List<GameObject> ordersClones;
    public GameObject pedidoAtual;

    void Start()
    {
        ordersClones = new List<GameObject>(orders);
    }
    public void Show_Order() {
        int randomNumber = Random.Range(0, ordersClones.Count);
        ordersClones[randomNumber].SetActive(true);
        pedidoAtual = ordersClones[randomNumber];
        ordersClones.RemoveAt(randomNumber);
    }

    public void Stop_Order() {
        pedidoAtual.SetActive(false);
    }
}

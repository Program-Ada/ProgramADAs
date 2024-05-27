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
    public bool pedidoEmAndamento;

    public GameObject order;

    void Start()
    {
        ordersClones = new List<GameObject>(orders);
        pedidoEmAndamento = false;

        // Create_Order();
    }

    public void Show_Order() {
        if(ordersClones.Count > 0) {
            pedidoEmAndamento = true;
            int randomNumber = Random.Range(0, ordersClones.Count);
            ordersClones[randomNumber].SetActive(true);
            pedidoAtual = ordersClones[randomNumber];
            ordersClones.RemoveAt(randomNumber);
        }
        else {
            Debug.Log("Nenhum pedido na lista");
        }
    }

    public void Stop_Order() {
        pedidoAtual.SetActive(false);
        pedidoEmAndamento = false;
    }

    // public void Create_Order() {
    //     order = new GameObject();
    //     order.name = "Order";
    //     order.transform.SetParent(this.gameObject.transform);
    //     order.AddComponent<Order>();
    //     order.AddComponent<RectTransform>();
    //     RectTransform rt = order.GetComponent<RectTransform>();
    //     rt.anchoredPosition = Vector3.zero;
    // }
}

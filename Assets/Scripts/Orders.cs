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

    void Start()
    {
        ordersClones = new List<GameObject>(orders);
        pedidoEmAndamento = false;
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
    }
}

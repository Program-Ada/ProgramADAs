using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Orders : MonoBehaviour
{
    public Pedido[] orders;
    public List<Pedido> ordersClones;
    public GameObject pedidoAtual;
    public bool pedidoEmAndamento;

    void Start()
    {
        //trocar para pegar automaticamente os fillhos ao inves de ter q ligar cada um deles
        orders = this.GetComponentsInChildren<Pedido>(true);
        ordersClones = new List<Pedido>(orders);
        pedidoEmAndamento = false;
    }

    public void Show_Order() {
        if(ordersClones.Count > 0) {
            pedidoEmAndamento = true;
            int randomNumber = Random.Range(0, ordersClones.Count);
            ordersClones[randomNumber].gameObject.SetActive(true);
            pedidoAtual = ordersClones[randomNumber].gameObject;
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
}

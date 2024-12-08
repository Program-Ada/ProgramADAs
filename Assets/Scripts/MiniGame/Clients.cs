using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Clients : MonoBehaviour
{
    public static Clients instance;
    public List<GameObject> clients;
    public GameObject currentClient;
    void Start()
    {
        instance = this;
        CreateList();
    }

    public void CreateList(){
        while(clients.Count < CafeManager.instance.maxOrders){ // quantidade de rodadas no minigame
            foreach(Transform child in this.transform){
                clients.Add(child.gameObject);
                child.gameObject.SetActive(false); // garantindo que todos estão desabilitados
            }
        }
        clients = ShuffleList(clients); 
    }

    public List<GameObject> ShuffleList(List<GameObject> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        return list;
    }

    public void CallClient(){
        if(clients.Count > 0){
            currentClient = clients[0];
            currentClient.SetActive(true);
        }
    }

    public void ExitClient(){
        if(clients.Count > 0){
            StartCoroutine(PlayLeavingAnimation());
        }
    }

    private IEnumerator PlayLeavingAnimation(){

        currentClient.GetComponent<Animator>().SetBool("isLeaving", true);
        yield return new WaitForSeconds(3); // tempo da animação

        currentClient.SetActive(false);
        clients.Remove(currentClient);
    }
}

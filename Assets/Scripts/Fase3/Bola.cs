using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public int numero;
    public string cor;
    public string parOuImpar;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Buraco"))
        {
            Debug.Log("Entrou no buraco!");
            StartCoroutine(desativarComAtraso(0.5f));
        }
    }
    IEnumerator desativarComAtraso(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        gameObject.SetActive(false);
    }
}

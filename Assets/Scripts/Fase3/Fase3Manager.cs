using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fase3Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool tipoFase;
    public Button[] numeros;
    public Button[] sinais;
    public Button[] cores;
    public Button[] parOuImpar;
    public GameObject posicaoIgualPar;
    public GameObject posicaoDiferentePar;
    public GameObject posicaoIgualNumero;
    public GameObject posicaoDiferenteNumero;
    void Start()
    {

    }
    void fasePar(){
        sinais[0].transform.position = posicaoIgualPar.transform.position;
        sinais[1].transform.position = posicaoDiferentePar.transform.position;
        foreach (Button numero in numeros)
        {
            numero.gameObject.SetActive(false);
        }
        for(int i=2; i<sinais.Length; i++){
            sinais[i].gameObject.SetActive(false);
        }
        foreach(Button cor in cores){
            cor.gameObject.SetActive(true);
        }
        foreach(Button botao in parOuImpar){
            botao.gameObject.SetActive(true);
        }
        for(int i=0; i<2; i++){
            sinais[i].gameObject.SetActive(true);
        }
    }
    void faseNumeros(){
        foreach(Button cor in cores){
            cor.gameObject.SetActive(false);
        }
        foreach(Button botao in parOuImpar){
            botao.gameObject.SetActive(false);
        }
        sinais[0].transform.position = posicaoIgualNumero.transform.position;
        sinais[1].transform.position = posicaoDiferenteNumero.transform.position;
        foreach (Button numero in numeros)
        {
            numero.gameObject.SetActive(true);
        }
        for(int i=0; i<sinais.Length; i++){
            sinais[i].gameObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(!tipoFase){
            fasePar();
        }else{
            faseNumeros();
        }
    }
}


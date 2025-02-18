using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonFase3 : MonoBehaviour
{   
    public bool tipoFase;
    public bool funcaoOperador = false;
    public bool funcaoCondicao = false;
    public bool operadorEscolhido = false;
    public GameObject[] spriteOperador;
    public Button[] operador;
    public Button[] numeros;
    public GameObject[] spriteNumero;
    public Button[] parOuImpar;
    public GameObject[] spriteParOuImpar;
    public Button[] cores;
    public GameObject[] spriteCores;
    public GameObject posicaoIgualPar;
    public GameObject posicaoDiferentePar;
    public GameObject posicaoIgualNumero;
    public GameObject posicaoDiferenteNumero;
    // Start is called before the first frame update
    void Start()
    {
        desativarSprites();
    }
    public void fasePar(){
        operador[0].transform.position = posicaoIgualPar.transform.position;
        operador[1].transform.position = posicaoDiferentePar.transform.position;
        foreach (Button numero in numeros)
        {
            numero.gameObject.SetActive(false);
        }
        for(int i=2; i<operador.Length; i++){
            operador[i].gameObject.SetActive(false);
        }
        foreach(Button cor in cores){
            cor.gameObject.SetActive(true);
        }
        foreach(Button botao in parOuImpar){
            botao.gameObject.SetActive(true);
        }
        for(int i=0; i<2; i++){
            operador[i].gameObject.SetActive(true);
        }
    }
    public void faseNumeros(){
        foreach(Button cor in cores){
            cor.gameObject.SetActive(false);
        }
        foreach(Button botao in parOuImpar){
            botao.gameObject.SetActive(false);
        }
        operador[0].transform.position = posicaoIgualNumero.transform.position;
        operador[1].transform.position = posicaoDiferenteNumero.transform.position;
        foreach (Button numero in numeros)
        {
            numero.gameObject.SetActive(true);
        }
        for(int i=0; i<operador.Length; i++){
            operador[i].gameObject.SetActive(true);
        }
    }
    public void desativarSprites(){
        for(int i = 0; i<spriteNumero.Length; i++){
            if(i<spriteCores.Length){
                spriteCores[i].SetActive(false);
            }
            if(i<spriteParOuImpar.Length){
                spriteParOuImpar[i].SetActive(false);
            }
            if(i<spriteOperador.Length){
                spriteOperador[i].SetActive(false);
            }
            spriteNumero[i].SetActive(false);
        }
    }
    public void Button_funcaoOperador(){
        funcaoOperador = true;
        funcaoCondicao = false;
    }
    public void Button_funcaoCondicao(){
        if(funcaoOperador && operadorEscolhido){
            funcaoCondicao = true;
        }else{
            if(funcaoOperador && !operadorEscolhido){
                Debug.Log("Primeiro precisa escolher o operador");
            }else{
                Debug.Log("Primeiro precisa ativar a funcao do Operador");
            }
        }
    }
    public void Button_EscolheOperador(int i){
        if(funcaoOperador){
            for(int j =0; j<spriteOperador.Length; j++){
                if(j != i){
                    operador[j].interactable = false;
                }
            }
            spriteOperador[i].SetActive(true);
            operadorEscolhido = true;
        }else{
            Debug.Log("Primeiro precisa ativar a funcao do Operador");
        }
    }
    public void Button_EscolheNumero(int i){
        if(funcaoCondicao && funcaoOperador){
            for(int j =0; j<numeros.Length; j++){
                if(j != i){
                    numeros[j].interactable = false;
                }
            }
            spriteNumero[i].SetActive(true);
        }else{
            if(!funcaoOperador && funcaoCondicao){
            Debug.Log("Primeiro precisa escolher o operador");
            }else{
                Debug.Log("Primeiro precisa ativar a funcao da condicao");
            }
        }
    }
    public void Button_EscolheParOuImpar(int i){
        if(funcaoCondicao && funcaoOperador){
            for(int j =0; j<cores.Length; j++){
                if(j != i && j<2){
                    parOuImpar[j].interactable = false;
                }
                cores[j].interactable = false;
            }
            spriteParOuImpar[i].SetActive(true);
        }else{
            if(!funcaoOperador && funcaoCondicao){
            Debug.Log("Primeiro precisa escolher o operador");
            }else{
                Debug.Log("Primeiro precisa ativar a funcao da condicao");
            }
        }
    }
    public void Button_EscolherCor(int i){
        if(funcaoCondicao && funcaoOperador){
            for(int j =0; j<cores.Length; j++){
                if(j != i){
                    cores[j].interactable = false;
                }
                if(j<2){
                    parOuImpar[j].interactable = false;
                }
            }
            spriteCores[i].SetActive(true);
        }else{
            if(!funcaoOperador && funcaoCondicao){
            Debug.Log("Primeiro precisa escolher o operador");
            }else{
                Debug.Log("Primeiro precisa ativar a funcao da condicao");
            }
        }
    }
    public void Button_X(){
        desativarSprites();
        funcaoOperador = false;
        funcaoCondicao = false;
        operadorEscolhido = false;
        for(int i=0; i<numeros.Length; i++){
            numeros[i].interactable = true;
            if(i<cores.Length){
                cores[i].interactable = true;
            }
            if(i<parOuImpar.Length){
                parOuImpar[i].interactable = true;
            }
            if(i<operador.Length){
                operador[i].interactable = true;
            }
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

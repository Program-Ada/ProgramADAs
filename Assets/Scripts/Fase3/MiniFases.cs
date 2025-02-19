using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class MiniFases : MonoBehaviour
{ //amanha tenho que mudar as partes <Button> por <ButtonQuadro2Fase3>
    public GameObject[] bolas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*public bool verificaCondicional(GameObject BolaEscolhida){
        GameObject[] todasBolas = GameObject.FindGameObjectsWithTag("Bola");
        GameObject[] bolasAtivas = todasBolas.Where(bola => bola.activeInHierarchy).ToArray();
        GameObject operadorInteractable = GameObject.FindGameObjectsWithTag("Operador").Where(op => op.GetComponent<Button>()?.interactable == true).FirstOrDefault();
        GameObject condicaoEscolhida = GameObject.FindGameObjectsWithTag("Numero").Where(cond => cond.GetComponent<Button>()?.interactable == true).FirstOrDefault();
        if(condicaoEscolhida == null){
            condicaoEscolhida = GameObject.FindGameObjectsWithTag("Cor").Where(cond => cond.GetComponent<Button>()?.interactable == true).FirstOrDefault();
            if(condicaoEscolhida == null){
                condicaoEscolhida = GameObject.FindGameObjectsWithTag("ParOuImpar").Where(cond => cond.GetComponent<Button>()?.interactable == true).FirstOrDefault();
            }
        }
        if(condicaoEscolhida.CompareTag("Numero")){
            int condicaoNumero = condicaoEscolhida.GetComponent<Button>().numero;
            switch(operadorInteractable.operador){
                case "==":
                    if(!(BolaEscolhida.numero == condicaoNumero)){
                        return false;
                    }
                    break;
                case "!=":
                    if(!(BolaEscolhida.numero != condicaoNumero)){
                        return false;
                    }
                    break;
                case ">":  
                    if(!(BolaEscolhida.numero > condicaoNumero)){
                        return false;
                    }
                    break;
                case "<":
                    if(!(BolaEscolhida.numero < condicaoNumero)){
                        return false;
                    }
                    break;
                case ">=":
                    if(!(BolaEscolhida.numero >= condicaoNumero)){
                        return false;
                    }
                    break;
                case "<=":
                    if(!(BolaEscolhida.numero <= condicaoNumero)){
                        return false;
                    }
                    break;
            }
            for(int i=0; i<bolasAtivas.Length; i++){
                if(bolasAtivas[i] != BolaEscolhida){
                    switch(operadorInteractable.operador){
                        case "==":
                            if(bolasAtivas[i].GetComponent<Bola>().numero == condicaoNumero){
                                return false;
                            }
                            break;
                        case "!=":
                            if(bolasAtivas[i].GetComponent<Bola>().numero != condicaoNumero){
                                return false;
                            }
                            break;
                        case ">":
                            if(bolasAtivas[i].GetComponent<Bola>().numero > condicaoNumero){
                                return false;
                            }
                            break;
                        case "<":
                            if(bolasAtivas[i].GetComponent<Bola>().numero < condicaoNumero){
                                return false;
                            }
                            break;
                        case ">=":
                            if(bolasAtivas[i].GetComponent<Bola>().numero >= condicaoNumero){
                                return false;
                            }
                            break;
                        case "<=":
                            if(bolasAtivas[i].GetComponent<Bola>().numero <= condicaoNumero){
                                return false;
                            }
                            break;
                    }
                }
            }
        }
        if(condicaoEscolhida.CompareTag("Cor")){
            string condicaoCor = condicaoEscolhida.GetComponent<Button>().cor;
            switch(operadorInteractable.operador){
                case "==":
                    if(!(BolaEscolhida.cor == condicaoCor)){
                        return false;
                    }
                    break;
                case "!=":
                    if(!(BolaEscolhida.cor != condicaoCor)){
                        return false;
                    }
                    break;
            }
            for(int i=0; i<bolasAtivas.Length; i++){
                if(bolasAtivas[i] != BolaEscolhida){
                    switch(operadorInteractable.operador){
                        case "==":
                            if(bolasAtivas[i].GetComponent<Bola>().cor == condicaoCor){
                                return false;
                            }
                            break;
                        case "!=":
                            if(bolasAtivas[i].GetComponent<Bola>().cor != condicaoCor){
                                return false;
                            }
                            break;
                    }
                }
            }
        }
        if(condicaoEscolhida.CompareTag("ParOuImpar")){
            string condicaoParOuImpar = condicaoEscolhida.GetComponent<Button>().parOuImpar;
            switch(operadorInteractable.operador){
                case "==":
                    if(!(BolaEscolhida.parOuImpar == condicaoParOuImpar)){
                        return false;
                    }
                    break;
                case "!=":
                    if(!(BolaEscolhida.parOuImpar != condicaoParOuImpar)){
                        return false;
                    }
                    break;
            }
            for(int i=0; i<bolasAtivas.Length; i++){
                if(bolasAtivas[i] != BolaEscolhida){
                    switch(operadorInteractable.operador){
                        case "==":
                            if(bolasAtivas[i].GetComponent<Bola>().parOuImpar == condicaoParOuImpar){
                                return false;
                            }
                            break;
                        case "!=":
                            if(bolasAtivas[i].GetComponent<Bola>().parOuImpar != condicaoParOuImpar){
                                return false;
                            }
                            break;
                    }
                }   
            }
        }
        return true;
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
}

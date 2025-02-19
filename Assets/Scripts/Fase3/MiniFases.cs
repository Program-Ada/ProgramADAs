using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MiniFases : MonoBehaviour
{
    public GameObject[] bolas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void verificaCondicional(/*operador do escolhido, condicao escolhida(escolhe para que seja numero ou string, vetor de bolas ativas*/){
        GameObject[] todasBolas = GameObject.FindGameObjectsWithTag("Bola");
        GameObject[] bolasAtivas = todasBolas.Where(bola => bola.activeInHierarchy).ToArray();
        GameObject operadorInteractable = GameObject.FindGameObjectsWithTag("Operador").Where(op => op.GetComponent<OperadorController>()?.interactable == true).FirstOrDefault();
        GameObject condicaoEscolhida = GameObject.FindGameObjectsWithTag("Numero").Where(cond => cond.GetComponent<CondicaoController>()?.interactable == true).FirstOrDefault();
        if(condicaoEscolhida == null){
            condicaoEscolhida = GameObject.FindGameObjectsWithTag("Cor").Where(cond => cond.GetComponent<CondicaoController>()?.interactable == true).FirstOrDefault();
            if(condicaoEscolhida == null){
                condicaoEscolhida = GameObject.FindGameObjectsWithTag("ParouImpar").Where(cond => cond.GetComponent<CondicaoController>()?.interactable == true).FirstOrDefault();
            }
        }
        if(condicaoEscolhida.CompareTag("Numero")){
            int condicaoNumero = condicaoEscolhida.GetComponent<CondicaoController>().numero;
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
                default:
                    Debug.Log("Não escolheu nenhum operador ou condição");
            }
            for(int i=0; i<bolasAtivas.Length; i++){
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
                    default:
                        Debug.Log("Não escolheu nenhum operador ou condição");
                }
            }
        }
        if(condicaoEscolhida.CompareTag("Cor")){
            string condicaoCor = condicaoEscolhida.GetComponent<CondicaoController>().cor;
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
                default:
                    Debug.Log("Não escolheu nenhum operador ou condição");
            }
            for(int i=0; i<bolasAtivas.Length; i++){
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
                    default:
                        Debug.Log("Não escolheu nenhum operador ou condição");
                }
            }
        }
        if(condicaoEscolhida.CompareTag("ParOuImpar")){
            string condicaoParOuImpar = condicaoEscolhida.GetComponent<CondicaoController>().parOuImpar;
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
                default:
                    Debug.Log("Não escolheu nenhum operador ou condição");
            }
            for(int i=0; i<bolasAtivas.Length; i++){
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
                    default:
                        Debug.Log("Não escolheu nenhum operador ou condição");
                }
            }
        }
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

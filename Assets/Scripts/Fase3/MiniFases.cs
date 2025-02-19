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

    public bool verificaCondicional(GameObject BolaEscolhida){
        GameObject[] todasBolas = GameObject.FindGameObjectsWithTag("Bola");
        GameObject[] bolasAtivas = todasBolas.Where(bola => bola.activeInHierarchy).ToArray();
        GameObject[] operadoresObjetos = GameObject.FindGameObjectsWithTag("Operador");
        Button operadorInteractable = operadoresObjetos.Select(op => op.GetComponent<Button>()).Where(btn => btn.interactable).FirstOrDefault();
        GameObject[] condicaoObjetos = GameObject.FindGameObjectsWithTag("Numero").Concat(GameObject.FindGameObjectsWithTag("Cor")).Concat(GameObject.FindGameObjectsWithTag("ParOuImpar")).ToArray();
        Button condicaoEscolhida = condicaoObjetos.Select(cond => cond.GetComponent<Button>()).Where(btn => btn.interactable).FirstOrDefault();
        Bola bolaEscolhida = BolaEscolhida.GetComponent<Bola>(); 
        ButtonQuadro2Fase3 condicaoEscolhidaButton = condicaoEscolhida.GetComponent<ButtonQuadro2Fase3>();
        ButtonQuadro2Fase3 operadorInteractableButton = operadorInteractable.GetComponent<ButtonQuadro2Fase3>();
        if(condicaoEscolhida.CompareTag("Numero")){
            switch(operadorInteractableButton.operador){
                case "==":
                    if(!(bolaEscolhida.numero == condicaoEscolhidaButton.numero)){
                        return false;
                    }
                    break;
                case "!=":
                    if(!(bolaEscolhida.numero != condicaoEscolhidaButton.numero)){
                        return false;
                    }
                    break;
                case ">":  
                    if(!(bolaEscolhida.numero > condicaoEscolhidaButton.numero)){
                        return false;
                    }
                    break;
                case "<":
                    if(!(bolaEscolhida.numero < condicaoEscolhidaButton.numero)){
                        return false;
                    }
                    break;
                case ">=":
                    if(!(bolaEscolhida.numero >= condicaoEscolhidaButton.numero)){
                        return false;
                    }
                    break;
                case "<=":
                    if(!(bolaEscolhida.numero <= condicaoEscolhidaButton.numero)){
                        return false;
                    }
                    break;
            }
            for(int i=0; i<bolasAtivas.Length; i++){
                if(bolasAtivas[i] != bolaEscolhida){
                    switch(operadorInteractableButton.operador){
                        case "==":
                            if(bolasAtivas[i].GetComponent<Bola>().numero == condicaoEscolhidaButton.numero){
                                return false;
                            }
                            break;
                        case "!=":
                            if(bolasAtivas[i].GetComponent<Bola>().numero != condicaoEscolhidaButton.numero){
                                return false;
                            }
                            break;
                        case ">":
                            if(bolasAtivas[i].GetComponent<Bola>().numero > condicaoEscolhidaButton.numero){
                                return false;
                            }
                            break;
                        case "<":
                            if(bolasAtivas[i].GetComponent<Bola>().numero < condicaoEscolhidaButton.numero){
                                return false;
                            }
                            break;
                        case ">=":
                            if(bolasAtivas[i].GetComponent<Bola>().numero >= condicaoEscolhidaButton.numero){
                                return false;
                            }
                            break;
                        case "<=":
                            if(bolasAtivas[i].GetComponent<Bola>().numero <= condicaoEscolhidaButton.numero){
                                return false;
                            }
                            break;
                    }
                }
            }
        }
        if(condicaoEscolhida.CompareTag("Cor")){
            switch(operadorInteractableButton.operador){
                case "==":
                    if(!(bolaEscolhida.cor == condicaoEscolhidaButton.cor)){
                        return false;
                    }
                    break;
                case "!=":
                    if(!(bolaEscolhida.cor != condicaoEscolhidaButton.cor)){
                        return false;
                    }
                    break;
            }
            for(int i=0; i<bolasAtivas.Length; i++){
                if(bolasAtivas[i] != bolaEscolhida){
                    switch(operadorInteractableButton.operador){
                        case "==":
                            if(bolasAtivas[i].GetComponent<Bola>().cor == condicaoEscolhidaButton.cor){
                                return false;
                            }
                            break;
                        case "!=":
                            if(bolasAtivas[i].GetComponent<Bola>().cor != condicaoEscolhidaButton.cor){
                                return false;
                            }
                            break;
                    }
                }
            }
        }
        if(condicaoEscolhida.CompareTag("ParOuImpar")){
            switch(operadorInteractableButton.operador){
                case "==":
                    if(!(bolaEscolhida.parOuImpar == condicaoEscolhidaButton.parOuImpar)){
                        return false;
                    }
                    break;
                case "!=":
                    if(!(bolaEscolhida.parOuImpar != condicaoEscolhidaButton.parOuImpar)){
                        return false;
                    }
                    break;
            }
            for(int i=0; i<bolasAtivas.Length; i++){
                if(bolasAtivas[i] != bolaEscolhida){
                    switch(operadorInteractableButton.operador){
                        case "==":
                            if(bolasAtivas[i].GetComponent<Bola>().parOuImpar == condicaoEscolhidaButton.parOuImpar){
                                return false;
                            }
                            break;
                        case "!=":
                            if(bolasAtivas[i].GetComponent<Bola>().parOuImpar != condicaoEscolhidaButton.parOuImpar){
                                return false;
                            }
                            break;
                    }
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

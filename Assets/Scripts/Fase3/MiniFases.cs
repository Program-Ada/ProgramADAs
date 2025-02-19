using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class MiniFases : MonoBehaviour
{ //amanha tenho que mudar as partes <Button> por <ButtonQuadro2Fase3>
    public GameObject[] bolas;
    public static MiniFases Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }
    public int fase1a(){
        ButtonFase3.Instance.tipoFase = false;
        //bola 3, 5 , 11 e tem que encasapar a 5
        bolas[2].SetActive(true);
        bolas[4].SetActive(true);
        bolas[10].SetActive(true);

        return 4;
    }
    public int fase1b(){
        ButtonFase3.Instance.tipoFase = true;
        //15,13,4 e tem que encasapar a 4; (por menor que)
        bolas[14].SetActive(true);
        bolas[12].SetActive(true);
        bolas[3].SetActive(true);

        return 3;
    }
    public int fase1c(){
        ButtonFase3.Instance.tipoFase = false;
        //bola 1, 6, 13, 15 e tem que encasapar a 2; (por par)
        bolas[0].SetActive(true);
        bolas[5].SetActive(true);
        bolas[12].SetActive(true);
        bolas[14].SetActive(true);

        return 1;
    }

    public int fase1d(){
        ButtonFase3.Instance.tipoFase = true;
        //bola 2, 5, 7, 9 e tem que encasapar a 2; (por maior que)
        bolas[1].SetActive(true);
        bolas[4].SetActive(true);
        bolas[6].SetActive(true);
        bolas[8].SetActive(true);

        return 1;
    }
    public int fase1e(){
        ButtonFase3.Instance.tipoFase = true;
        //bola 8, 10, 11, 12, 14 e tem que encasapar 8
        bolas[7].SetActive(true);
        bolas[9].SetActive(true);
        bolas[10].SetActive(true);
        bolas[11].SetActive(true);
        bolas[13].SetActive(true);

        return 7;
    }
    public int fase1f(){
        ButtonFase3.Instance.tipoFase = false;
        //bola 1 , 9, 4,12, 6 e tem que encasapar a 6
        bolas[0].SetActive(true);
        bolas[8].SetActive(true);
        bolas[3].SetActive(true);
        bolas[11].SetActive(true);
        bolas[5].SetActive(true);

        return 5;
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

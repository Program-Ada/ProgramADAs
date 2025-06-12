using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class MiniFases : MonoBehaviour
{ //amanha tenho que mudar as partes <Button> por <ButtonQuadro2Fase3>
    public GameObject[] bolas;
    public static MiniFases Instance;
    public GameObject bolaBranca;
    public GameObject[] buracos;
    //public Animator animator;
    public GameObject[] bolasFase1;
    public GameObject[] bolasFase2;
    public GameObject[] bolasFase3;
    public GameObject[] bolasFase4;
    public GameObject[] bolasFase5;
    public GameObject[] bolasFase6;
    public GameObject[] bolasFase7;
    public GameObject[] bolasFase8;
    public GameObject[] bolasFase9;
    public GameObject[] bolasFase10;
    public GameObject[] bolasFase11;
    public GameObject[] bolasFase12;
    public GameObject[] bolasFase13;
    public GameObject[] bolasFase14;
    public GameObject[] bolasFase15;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    public int fase1(){
        ButtonFase3.Instance.ButtonFase(false);
        bolas[2].transform.position = bolasFase1[0].transform.position;
        bolas[4].transform.position = bolasFase1[1].transform.position;
        bolas[10].transform.position = bolasFase1[2].transform.position;
        bolaBranca.transform.position = bolasFase1[3].transform.position;
        //bola 3, 5 , 11 e tem que encasapar a 5
        bolas[2].SetActive(true);
        bolas[4].SetActive(true);
        bolas[10].SetActive(true);
        Debug.Log("Fase 1 escolhida");
        return 4;
    }
    public int fase2(){
        ButtonFase3.Instance.ButtonFase(true);
        bolas[3].transform.position = bolasFase2[0].transform.position;
        bolas[12].transform.position = bolasFase2[1].transform.position;
        bolas[14].transform.position = bolasFase2[2].transform.position;
        bolaBranca.transform.position = bolasFase2[3].transform.position;
        ButtonFase3.Instance.interactableBotaoOperador(0);
        ButtonFase3.Instance.interactableBotaoNumero(3);
        //15,13,4 e tem que encasapar a 4; (por menor que)
        bolas[14].SetActive(true);
        bolas[12].SetActive(true);
        bolas[3].SetActive(true);
        Debug.Log("Fase 2 escolhida");
        return 3;
    }
    public int fase3(){
        ButtonFase3.Instance.ButtonFase(false);
        bolas[0].transform.position = bolasFase3[0].transform.position;
        bolas[5].transform.position = bolasFase3[1].transform.position;
        bolas[12].transform.position = bolasFase3[2].transform.position;
        bolas[14].transform.position = bolasFase3[3].transform.position;
        bolaBranca.transform.position = bolasFase3[4].transform.position;
        //bola 1, 6, 13, 15 e tem que encasapar a 2; (por par)
        bolas[0].SetActive(true);
        bolas[5].SetActive(true);
        bolas[12].SetActive(true);
        bolas[14].SetActive(true);
        Debug.Log("Fase 3 escolhida");
        return 0;
    }

    public int fase4(){
        ButtonFase3.Instance.ButtonFase(true);
        bolas[1].transform.position = bolasFase4[0].transform.position;
        bolas[4].transform.position = bolasFase4[1].transform.position;
        bolas[6].transform.position = bolasFase4[2].transform.position;
        bolas[8].transform.position = bolasFase4[3].transform.position;
        bolaBranca.transform.position = bolasFase4[4].transform.position;
        ButtonFase3.Instance.interactableBotaoOperador(0);
        ButtonFase3.Instance.interactableBotaoNumero(1);
        //bola 2, 5, 7, 9 e tem que encasapar a 2; (por maior que)
        bolas[1].SetActive(true);
        bolas[4].SetActive(true);
        bolas[6].SetActive(true);
        bolas[8].SetActive(true);
        Debug.Log("Fase 4 escolhida");
        return 1;
    }
    public int fase5(){
        ButtonFase3.Instance.ButtonFase(true);
        bolas[7].transform.position = bolasFase5[0].transform.position;
        bolas[9].transform.position = bolasFase5[1].transform.position;
        bolas[10].transform.position = bolasFase5[2].transform.position;
        bolas[11].transform.position = bolasFase5[3].transform.position;
        bolas[13].transform.position = bolasFase5[4].transform.position;
        bolaBranca.transform.position = bolasFase5[5].transform.position;
        ButtonFase3.Instance.interactableBotaoOperador(0);
        ButtonFase3.Instance.interactableBotaoNumero(7);
        //bola 8, 10, 11, 12, 14 e tem que encasapar 8
        bolas[7].SetActive(true);
        bolas[9].SetActive(true);
        bolas[10].SetActive(true);
        bolas[11].SetActive(true);
        bolas[13].SetActive(true);
        Debug.Log("Fase 5 escolhida");
        return 7;
    }
    public int fase6(){
        ButtonFase3.Instance.ButtonFase(false);
        bolas[0].transform.position = bolasFase6[0].transform.position;
        bolas[3].transform.position = bolasFase6[1].transform.position;
        bolas[5].transform.position = bolasFase6[2].transform.position;
        bolas[8].transform.position = bolasFase6[3].transform.position;
        bolas[11].transform.position = bolasFase6[4].transform.position;
        bolaBranca.transform.position = bolasFase6[5].transform.position;

        //bola 1 , 9, 4,12, 6 e tem que encasapar a 6
        bolas[0].SetActive(true);
        bolas[8].SetActive(true);
        bolas[3].SetActive(true);
        bolas[11].SetActive(true);
        bolas[5].SetActive(true);
        Debug.Log("Fase 6 escolhida");
        return 5;
    }
    public int fase7(){
        ButtonFase3.Instance.ButtonFase(true);
        bolas[1].transform.position = bolasFase7[0].transform.position;
        bolas[2].transform.position = bolasFase7[1].transform.position;
        bolas[3].transform.position = bolasFase7[2].transform.position;
        bolas[14].transform.position = bolasFase7[3].transform.position;
        bolaBranca.transform.position = bolasFase7[4].transform.position;
        ButtonFase3.Instance.interactableBotaoOperador(0);
        ButtonFase3.Instance.interactableBotaoNumero(14);

        bolas[1].SetActive(true);
        bolas[2].SetActive(true);
        bolas[3].SetActive(true);
        bolas[14].SetActive(true);
        Debug.Log("Fase 7 escolhida");
        return 14;
    }
    public int fase8(){
        ButtonFase3.Instance.ButtonFase(false);
        bolas[0].transform.position = bolasFase8[0].transform.position;
        bolas[6].transform.position = bolasFase8[1].transform.position;
        bolas[8].transform.position = bolasFase8[2].transform.position;
        bolas[11].transform.position = bolasFase8[3].transform.position;
        bolas[14].transform.position = bolasFase8[4].transform.position;
        bolaBranca.transform.position = bolasFase8[5].transform.position;

        bolas[0].SetActive(true);
        bolas[6].SetActive(true);
        bolas[8].SetActive(true);
        bolas[11].SetActive(true);
        bolas[14].SetActive(true);
        Debug.Log("Fase 8 escolhida");
        return 11;
    }
    public int fase9(){
        ButtonFase3.Instance.ButtonFase(true);
        bolas[7].transform.position = bolasFase9[0].transform.position;
        bolas[9].transform.position = bolasFase9[1].transform.position;
        bolas[13].transform.position = bolasFase9[2].transform.position;
        bolaBranca.transform.position = bolasFase9[3].transform.position;
        //ButtonFase3.Instance.interactableBotaoOperador(0);
        //ButtonFase3.Instance.interactableBotaoNumero(9);

        bolas[7].SetActive(true);
        bolas[9].SetActive(true);
        bolas[13].SetActive(true);
        Debug.Log("Fase 9 escolhida");
        return 9;
    }
    public int fase10(){
        ButtonFase3.Instance.ButtonFase(false);
        bolas[1].transform.position = bolasFase10[0].transform.position;
        bolas[2].transform.position = bolasFase10[1].transform.position;
        bolas[9].transform.position = bolasFase10[2].transform.position;
        bolas[12].transform.position = bolasFase10[3].transform.position;
        bolas[13].transform.position = bolasFase10[4].transform.position;
        bolaBranca.transform.position = bolasFase10[5].transform.position;

        bolas[1].SetActive(true);
        bolas[2].SetActive(true);
        bolas[9].SetActive(true);
        bolas[12].SetActive(true);
        bolas[13].SetActive(true);
        Debug.Log("Fase 10 escolhida");
        return 2;
    }
    public int fase11(){
        ButtonFase3.Instance.ButtonFase(true);
        bolas[6].transform.position = bolasFase11[0].transform.position;
        bolas[10].transform.position = bolasFase11[1].transform.position;
        bolaBranca.transform.position = bolasFase11[2].transform.position;
        ButtonFase3.Instance.interactableBotaoOperador(0);
        ButtonFase3.Instance.interactableBotaoNumero(6);

        bolas[6].SetActive(true);
        bolas[10].SetActive(true);
        Debug.Log("Fase 11 escolhida");
        return 6;
    }
    public int fase12(){
        ButtonFase3.Instance.ButtonFase(true);
        bolas[4].transform.position = bolasFase12[0].transform.position;
        bolas[5].transform.position = bolasFase12[1].transform.position;
        bolas[7].transform.position = bolasFase12[2].transform.position;
        bolas[12].transform.position = bolasFase12[3].transform.position;
        bolaBranca.transform.position = bolasFase12[4].transform.position;
        ButtonFase3.Instance.interactableBotaoOperador(0);
        ButtonFase3.Instance.interactableBotaoNumero(12);

        bolas[4].SetActive(true);
        bolas[5].SetActive(true);
        bolas[7].SetActive(true);
        bolas[12].SetActive(true);
        Debug.Log("Fase 12 escolhida");
        return 12;
    }
    public int fase13(){
        ButtonFase3.Instance.ButtonFase(false);
        bolas[2].transform.position = bolasFase13[0].transform.position;
        bolas[6].transform.position = bolasFase13[1].transform.position;
        bolas[8].transform.position = bolasFase13[2].transform.position;
        bolas[10].transform.position = bolasFase13[3].transform.position;
        bolas[13].transform.position = bolasFase13[4].transform.position;
        bolaBranca.transform.position = bolasFase13[5].transform.position;

        //bola 3, 7, 9, 11, 14 e tem que encasapar a 3; (por maior que)
        bolas[2].SetActive(true);
        bolas[6].SetActive(true);
        bolas[8].SetActive(true);
        bolas[10].SetActive(true);
        bolas[13].SetActive(true);
        Debug.Log("Fase 13 escolhida");
        return 13;
    }
    public int fase14(){
        ButtonFase3.Instance.ButtonFase(false);
        bolas[3].transform.position = bolasFase14[0].transform.position;
        bolas[5].transform.position = bolasFase14[1].transform.position;
        bolas[8].transform.position = bolasFase14[2].transform.position;
        bolas[11].transform.position = bolasFase14[3].transform.position;
        bolas[13].transform.position = bolasFase14[4].transform.position;
        bolaBranca.transform.position = bolasFase14[5].transform.position;

        //bola 4, 6, 9, 12, 14 e tem que encasapar a 4; (por menor que)
        bolas[3].SetActive(true);
        bolas[5].SetActive(true);
        bolas[8].SetActive(true);   
        bolas[11].SetActive(true);
        bolas[13].SetActive(true);
        Debug.Log("Fase 14 escolhida");
        return 8;
    }
    public int fase15(){
        ButtonFase3.Instance.ButtonFase(true);
        bolas[1].transform.position = bolasFase15[0].transform.position;
        bolas[10].transform.position = bolasFase15[1].transform.position;
        bolaBranca.transform.position = bolasFase15[4].transform.position;
        ButtonFase3.Instance.interactableBotaoOperador(0);
        ButtonFase3.Instance.interactableBotaoNumero(10);

        //bola 1, 2, 5, 8 e tem que encasapar a 1; (por par)
        bolas[1].SetActive(true);
        bolas[10].SetActive(true);
        Debug.Log("Fase 15 escolhida");
        return 10;
    }
    public float velocidade = 5f;
    public Vector3 eixoDeRotacao = Vector3.forward;
    public int buracoMaisPerto(){
        float menorDistancia = 1000f;
        int buracoEscolhido = 0;
        for(int i = 0; i < buracos.Length; i++){
            float distancia = Vector3.Distance(bolaBranca.transform.position, buracos[i].transform.position);
            if(distancia < menorDistancia){
                menorDistancia = distancia;
                buracoEscolhido = i;
            }
        }
        return buracoEscolhido;
    }
    public string stringAnimacao(string bolaEscolhida){
        return "Bola" + bolaEscolhida;
    }
    public float grauRotacao(int buracoEscolhido){
        switch(buracoEscolhido){
            case 0:
                return 0f;
            case 1:
                return 270f;
            case 2:
                return 225f;
            case 3:
                return 180f;
            case 4:
                return 90f;
            case 5:
                return 45f;
            default:
                return 0f;
        }
    }
    public IEnumerator AnimarFase(GameObject bolaEscolhida)
    {
        while (Vector3.Distance(bolaBranca.transform.position, bolaEscolhida.transform.position) > 0.1f)
        {
            Vector3 direcao = (bolaEscolhida.transform.position - bolaBranca.transform.position).normalized;
            bolaBranca.transform.position += direcao * velocidade * Time.deltaTime;
            yield return null;
        }
        string animacao = stringAnimacao(bolaEscolhida.GetComponent<Bola>().cor);
        Animator animator = bolaEscolhida.GetComponent<Animator>();
        int i = buracoMaisPerto();
        float grau = grauRotacao(i);
        bolaEscolhida.transform.rotation = Quaternion.Euler(0f, 0f, grau);
        animator.SetBool(animacao, true);
        while (Vector3.Distance(bolaEscolhida.transform.position, buracos[i].transform.position) > 0.01f)
        {
            Vector3 direcaoBuraco = (buracos[i].transform.position - bolaEscolhida.transform.position).normalized;
            bolaEscolhida.transform.position += direcaoBuraco * velocidade * Time.deltaTime;
            yield return null;
        }
        desativarComAtraso(0.2f, animator, animacao);
        //bolaEscolhida.gameObject.SetActive(false);
    }
    IEnumerator desativarComAtraso(float tempo, Animator animator, string animacao)
    {
        yield return new WaitForSeconds(tempo);
        animator.SetBool(animacao, false);
    }
}

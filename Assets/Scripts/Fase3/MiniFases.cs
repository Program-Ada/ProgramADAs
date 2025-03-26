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
    public GameObject[] bolasFase1a;
    public GameObject[] bolaFase1b;
    public GameObject[] bolasFase1c;
    public GameObject[] bolasFase1d;
    public GameObject[] bolasFase1e;
    public GameObject[] bolasFase1f;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    public int fase1a(){
        ButtonFase3.Instance.tipoFase = false;
        bolas[2].transform.position = bolasFase1a[0].transform.position;
        bolas[4].transform.position = bolasFase1a[1].transform.position;
        bolas[10].transform.position = bolasFase1a[2].transform.position;
        bolaBranca.transform.position = bolasFase1a[3].transform.position;
        //bola 3, 5 , 11 e tem que encasapar a 5
        bolas[2].SetActive(true);
        bolas[4].SetActive(true);
        bolas[10].SetActive(true);
        Debug.Log("Fase 1a escolhida");
        return 4;
    }
    public int fase1b(){
        ButtonFase3.Instance.tipoFase = true;
        bolas[3].transform.position = bolaFase1b[0].transform.position;
        bolas[12].transform.position = bolaFase1b[1].transform.position;
        bolas[14].transform.position = bolaFase1b[2].transform.position;
        bolaBranca.transform.position = bolaFase1b[3].transform.position;
        //15,13,4 e tem que encasapar a 4; (por menor que)
        bolas[14].SetActive(true);
        bolas[12].SetActive(true);
        bolas[3].SetActive(true);
        Debug.Log("Fase 1b escolhida");
        return 3;
    }
    public int fase1c(){
        ButtonFase3.Instance.tipoFase = false;
        bolas[0].transform.position = bolasFase1c[0].transform.position;
        bolas[5].transform.position = bolasFase1c[1].transform.position;
        bolas[12].transform.position = bolasFase1c[2].transform.position;
        bolas[14].transform.position = bolasFase1c[3].transform.position;
        bolaBranca.transform.position = bolasFase1c[4].transform.position;
        //bola 1, 6, 13, 15 e tem que encasapar a 2; (por par)
        bolas[0].SetActive(true);
        bolas[5].SetActive(true);
        bolas[12].SetActive(true);
        bolas[14].SetActive(true);
        Debug.Log("Fase 1c escolhida");
        return 0;
    }

    public int fase1d(){
        ButtonFase3.Instance.tipoFase = true;
        bolas[1].transform.position = bolasFase1d[0].transform.position;
        bolas[4].transform.position = bolasFase1d[1].transform.position;
        bolas[6].transform.position = bolasFase1d[2].transform.position;
        bolas[8].transform.position = bolasFase1d[3].transform.position;
        bolaBranca.transform.position = bolasFase1d[4].transform.position;
        //bola 2, 5, 7, 9 e tem que encasapar a 2; (por maior que)
        bolas[1].SetActive(true);
        bolas[4].SetActive(true);
        bolas[6].SetActive(true);
        bolas[8].SetActive(true);
        Debug.Log("Fase 1d escolhida");
        return 1;
    }
    public int fase1e(){
        ButtonFase3.Instance.tipoFase = true;
        bolas[7].transform.position = bolasFase1e[0].transform.position;
        bolas[9].transform.position = bolasFase1e[1].transform.position;
        bolas[10].transform.position = bolasFase1e[2].transform.position;
        bolas[11].transform.position = bolasFase1e[3].transform.position;
        bolas[13].transform.position = bolasFase1e[4].transform.position;
        bolaBranca.transform.position = bolasFase1e[5].transform.position;
        //bola 8, 10, 11, 12, 14 e tem que encasapar 8
        bolas[7].SetActive(true);
        bolas[9].SetActive(true);
        bolas[10].SetActive(true);
        bolas[11].SetActive(true);
        bolas[13].SetActive(true);
        Debug.Log("Fase 1e escolhida");
        return 7;
    }
    public int fase1f(){
        ButtonFase3.Instance.tipoFase = false;
        bolas[0].transform.position = bolasFase1f[0].transform.position;
        bolas[3].transform.position = bolasFase1f[1].transform.position;
        bolas[5].transform.position = bolasFase1f[2].transform.position;
        bolas[8].transform.position = bolasFase1f[3].transform.position;
        bolas[11].transform.position = bolasFase1f[4].transform.position;
        bolaBranca.transform.position = bolasFase1f[5].transform.position;

        //bola 1 , 9, 4,12, 6 e tem que encasapar a 6
        bolas[0].SetActive(true);
        bolas[8].SetActive(true);
        bolas[3].SetActive(true);
        bolas[11].SetActive(true);
        bolas[5].SetActive(true);
        Debug.Log("Fase 1f escolhida");
        return 5;
    }

    public float velocidade = 5f;
    public Vector3 eixoDeRotacao = Vector3.forward;
    /*public void animarFase1a(){
        StartCoroutine(AnimarFase(bolas[4]));
    }*/
    /*IEnumerator AnimarFase1a()
    {
        // 1. Move a bola branca até a bola[4]
        while (Vector3.Distance(bolaBranca.transform.position, bolas[4].transform.position) > 0.1f)
        {
            Vector3 direcao = (bolas[4].transform.position - bolaBranca.transform.position).normalized;
            bolaBranca.transform.position += direcao * velocidade * Time.deltaTime;
            yield return null; // Espera o próximo frame
        }

        // 2. Ativa a animação da bola 4
        animator.SetBool("Bola5", true);

        // 3. Move e gira a bola[4] até o buraco
        while (Vector3.Distance(bolas[4].transform.position, buracos[3].transform.position) > 0.01f)
        {
            Vector3 direcaoBuraco = (buracos[3].transform.position - bolas[4].transform.position).normalized;
            bolas[4].transform.position += direcaoBuraco * velocidade * Time.deltaTime;

            // Rotaciona proporcional ao tempo
            //bolas[4].transform.Rotate(eixoDeRotacao, 90f * Time.deltaTime, Space.Self);
            bolas[4].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            //aqui apenas para as que precisam girar

            yield return null;
        }

        // 4. Finaliza a animação e desativa a bola
        animator.SetBool("Bola5", false);
        bolas[4].gameObject.SetActive(false);
    }*/
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
        // 1. Move a bola branca até a bola[4]
        while (Vector3.Distance(bolaBranca.transform.position, bolaEscolhida.transform.position) > 0.1f)
        {
            Vector3 direcao = (bolaEscolhida.transform.position - bolaBranca.transform.position).normalized;
            bolaBranca.transform.position += direcao * velocidade * Time.deltaTime;
            yield return null; // Espera o próximo frame
        }
        string animacao = stringAnimacao(bolaEscolhida.GetComponent<Bola>().cor);
        Animator animator = bolaEscolhida.GetComponent<Animator>();
        int i = buracoMaisPerto();
        float grau = grauRotacao(i);
        bolaEscolhida.transform.rotation = Quaternion.Euler(0f, 0f, grau);
        // 2. Ativa a animação da bola 4
        animator.SetBool(animacao, true);

        // 3. Move e gira a bola[4] até o buraco
        while (Vector3.Distance(bolaEscolhida.transform.position, buracos[i].transform.position) > 0.01f)
        {
            Vector3 direcaoBuraco = (buracos[i].transform.position - bolaEscolhida.transform.position).normalized;
            bolaEscolhida.transform.position += direcaoBuraco * velocidade * Time.deltaTime;

            // Rotaciona proporcional ao tempo
            //bolaEscolhida.transform.Rotate(eixoDeRotacao, 90f * Time.deltaTime, Space.Self);
            //aqui apenas para as que precisam girar

            yield return null;
        }

        // 4. Finaliza a animação e desativa a bola
        animator.SetBool(animacao, false);
        bolaEscolhida.gameObject.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

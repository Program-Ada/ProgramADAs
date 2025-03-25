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
    public Animator animator;
    public GameObject[] localizacaoBolas;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    public int fase1a(){
        ButtonFase3.Instance.tipoFase = false;
        bolas[2].transform.position = localizacaoBolas[0].transform.position;
        bolas[4].transform.position = localizacaoBolas[1].transform.position;
        bolas[10].transform.position = localizacaoBolas[2].transform.position;
        bolaBranca.transform.position = localizacaoBolas[3].transform.position;
        //bola 3, 5 , 11 e tem que encasapar a 5
        bolas[2].SetActive(true);
        bolas[4].SetActive(true);
        bolas[10].SetActive(true);
        Debug.Log("Fase 1a escolhida");
        return 4;
    }
    public int fase1b(){
        ButtonFase3.Instance.tipoFase = true;
        //15,13,4 e tem que encasapar a 4; (por menor que)
        bolas[14].SetActive(true);
        bolas[12].SetActive(true);
        bolas[3].SetActive(true);
        Debug.Log("Fase 1b escolhida");
        return 3;
    }
    public int fase1c(){
        ButtonFase3.Instance.tipoFase = false;
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
    public void animarFase1a(){
        StartCoroutine(AnimarFase1a());
    }
    IEnumerator AnimarFase1a()
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
        while (Vector3.Distance(bolas[4].transform.position, buracos[0].transform.position) > 0.1f)
        {
            Vector3 direcaoBuraco = (buracos[0].transform.position - bolas[4].transform.position).normalized;
            bolas[4].transform.position += direcaoBuraco * velocidade * Time.deltaTime;

            // Rotaciona proporcional ao tempo
            bolas[4].transform.Rotate(eixoDeRotacao, 90f * Time.deltaTime, Space.Self);

            yield return null;
        }

        // 4. Finaliza a animação e desativa a bola
        animator.SetBool("Bola5", false);
        bolas[4].gameObject.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

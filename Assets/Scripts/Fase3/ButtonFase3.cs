using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class ButtonFase3 : MonoBehaviour
{   
    public GameObject[] bola;
    public GameObject bolaBranca;
    public static ButtonFase3 Instance;
    public bool tipoFase;
    public bool funcaoOperador = false;
    public bool funcaoCondicao = false;
    public bool operadorEscolhido = false;
    public bool condicaoEscolhida = false;
    public GameObject[] spriteOperador;
    public Button[] buttonQuadro1;
    public Button[] botoesCondicional;
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
    public TextMeshProUGUI objetivoDaFase;
    public GameObject[] emojis;
    private Func<int>[] miniFases;
    private bool[] miniFasesChamadas;
    public int bolaDoMomento;
    public TextMeshProUGUI partidas;
    public int partidaJogadas = 0;
    public GameObject[] vidas;
    public GameObject[] perdeuVida;
    public int error = -1;
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        //desativarBolas();
        desativarSprites();
        //desativarEmojis();
        desativarErros();
        if (MiniFases.Instance == null)
        {
            Debug.LogError("Erro: MiniFases.Instance não foi inicializado!");
            return;
        }
        miniFases = new Func<int>[]
        {
            MiniFases.Instance.fase1,
            MiniFases.Instance.fase2,
            MiniFases.Instance.fase3,
            MiniFases.Instance.fase4,
            MiniFases.Instance.fase5,
            MiniFases.Instance.fase6,
            MiniFases.Instance.fase7,
            MiniFases.Instance.fase8,
            MiniFases.Instance.fase9,
            MiniFases.Instance.fase10
            /*MiniFases.Instance.fase11,
            MiniFases.Instance.fase12,
            MiniFases.Instance.fase13,
            MiniFases.Instance.fase14,
            MiniFases.Instance.fase15*/
        };
        miniFasesChamadas = new bool[15];
        comecarNovaFase();
        //partidaJogadas++;
    }
    public void desativarErros(){
        for(int i=0; i<perdeuVida.Length; i++){
            perdeuVida[i].SetActive(false);
        }
    }
    public void desativarBolas(){
        foreach(GameObject b in bola){
            b.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            b.SetActive(false);
        }
    }
    public void desativarSprites(){
        for(int i = 0; i<spriteNumero.Length; i++){
            if(i<spriteCores.Length){
                if(spriteCores[i].activeSelf)
                    spriteCores[i].SetActive(false);
            }
            if(i<spriteParOuImpar.Length){
                if(spriteParOuImpar[i].activeSelf)
                    spriteParOuImpar[i].SetActive(false);
            }
            if(i<spriteOperador.Length){
                if(spriteOperador[i].activeSelf)
                    spriteOperador[i].SetActive(false);
            }
            if(spriteNumero[i].activeSelf)
                spriteNumero[i].SetActive(false);
        }
    }
    public void desativarEmojis(){
        for(int i=0; i<emojis.Length; i++){
            emojis[i].SetActive(false);
        }
    }
    public void interactableBotaoOperador(int i){
        operador[i].interactable = false;   
    }
    public void interactableBotaoNumero(int i){
        numeros[i].interactable = false;
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
    /*public void Button_funcaoOperador(){
        funcaoOperador = true;
        funcaoCondicao = false;
    }
    public void Button_funcaoCondicao(){
        if(funcaoOperador && operadorEscolhido){
            funcaoCondicao = true;
        }else{
            if(funcaoOperador && !operadorEscolhido){
                //FeedbackManagerFase3.Instance.Feedback_Test("escolherOperador");
                Debug.Log("Primeiro precisa escolher o operador");
            }else{
                //FeedbackManagerFase3.Instance.Feedback_Test("semFuncaoOperador");
                Debug.Log("Primeiro precisa ativar a funcao do Operador");
            }
        }
    }*/
    public void Button_EscolheOperador(int i){
        //if(funcaoOperador){
            for(int j =0; j<spriteOperador.Length; j++){
                if(j != i){
                    operador[j].interactable = false;
                }
            }
            spriteOperador[i].SetActive(true);
            botoesCondicional[0].gameObject.SetActive(false);
            operadorEscolhido = true;
        //}else{
            //FeedbackManagerFase3.Instance.Feedback_Test("operadorNaoEscolhido");
            Debug.Log("Primeiro precisa ativar a funcao do Operador");
        //}
    }
    public void Button_EscolheNumero(int i){
        if(operadorEscolhido){
            for(int j =0; j<numeros.Length; j++){
                if(j != i){
                    numeros[j].interactable = false;
                }
            }
            interactableNo(cores);
            interactableNo(parOuImpar);
            spriteNumero[i].SetActive(true);
            botoesCondicional[1].gameObject.SetActive(false);
            condicaoEscolhida = true;
        }else{
            FeedbackManagerFase3.Instance.Feedback_Test("condS/Operador");
            Debug.Log("Primeiro precisa escolher o operador");
        }
    }
    public void Button_EscolheParOuImpar(int i){
        if(operadorEscolhido){
            if(i ==0){
                parOuImpar[1].interactable = false;
            }else{
                parOuImpar[0].interactable = false;
            }
            interactableNo(numeros);
            interactableNo(cores);
            spriteParOuImpar[i].SetActive(true);
            botoesCondicional[1].gameObject.SetActive(false);
            condicaoEscolhida = true;
        }else{
            FeedbackManagerFase3.Instance.Feedback_Test("condS/Operador");
            Debug.Log("Primeiro precisa escolher o operador");
        }
    }
    public void Button_EscolherCor(int i){
        if(operadorEscolhido){
            for(int j =0; j<cores.Length; j++){
                if(j != i){
                    cores[j].interactable = false;
                }
            }
            interactableNo(parOuImpar);
            interactableNo(numeros);
            botoesCondicional[1].gameObject.SetActive(false);
            spriteCores[i].SetActive(true);
            condicaoEscolhida = true;
        }else{
            FeedbackManagerFase3.Instance.Feedback_Test("condS/Operador");
            Debug.Log("Primeiro precisa escolher o operador");
        }
    }
    public void interactableNo(Button[] button){
        for(int i=0; i<button.Length; i++){
            if(button[i].interactable)
                button[i].interactable = false;
        }
    }
    public void interactableAllYes(){
        for(int i=0; i<numeros.Length; i++){
            numeros[i].interactable = true;
            if(i<cores.Length){
                if(!cores[i].interactable)
                    cores[i].interactable = true;
            }
            if(i<parOuImpar.Length){
                if(!parOuImpar[i].interactable)
                    parOuImpar[i].interactable = true;
            }
            if(i<operador.Length){
                if(!operador[i].interactable)
                    operador[i].interactable = true;
            }
            if(i<buttonQuadro1.Length){
                if(!buttonQuadro1[i].interactable)
                    buttonQuadro1[i].interactable = true;
            }
        }
    }
    public void interactableAllNo(){
        for(int i=0; i<numeros.Length; i++){
            numeros[i].interactable = false;
            if(i<cores.Length){
                if(cores[i].interactable)
                    cores[i].interactable = false;
            }
            if(i<parOuImpar.Length){
                if(parOuImpar[i].interactable)
                    parOuImpar[i].interactable = false;
            }
            if(i<operador.Length){
                if(operador[i].interactable)
                    operador[i].interactable = false;
            }
        }
    }
    public void interactableNoButtonQuadro1(){
        for(int i=0; i<buttonQuadro1.Length; i++){
            if(buttonQuadro1[i].interactable)
                buttonQuadro1[i].interactable = false;
        }
    }
    public void Button_Ok(){
        if(condicaoEscolhida){
            interactableNoButtonQuadro1();
            int typeError = 2;
            //GameObject resultado = verificaCondicional(bola[bolaDoMomento]);
            (int resultadoInt , GameObject resultadoBola) = verificaCondicional(bola[bolaDoMomento]);
            emojis[resultadoInt].SetActive(true);
            if(resultadoInt == 2){
                MiniFases.Instance.StartCoroutine(MiniFases.Instance.AnimarFase(resultadoBola));
                Invoke("comecarNovaFase", 2f);
            }else{
                error++;
                menosVida(error);
                if(resultadoBola != bolaBranca){
                    MiniFases.Instance.StartCoroutine(MiniFases.Instance.AnimarFase(resultadoBola));
                }
                if(resultadoInt ==1){
                    FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");

                }else{
                    FeedbackManagerFase3.Instance.Feedback_Test("errado");
                }
                if(error >= 2){
                    Invoke("IsGameFinished", 3f);
                }else{
                    Invoke("comecarNovaFase", 4f);
                    ScoreFase3.instance.Update_Score(typeError);
                }
            }
            /*if(resultado == bola[bolaDoMomento]){
                emojis[2].SetActive(true);
                MiniFases.Instance.StartCoroutine(MiniFases.Instance.AnimarFase(bola[bolaDoMomento]));
                Invoke("comecarNovaFase", 2f);
            }else{
                if(resultado == bolaBranca){
                    emojis[0].SetActive(true);
                    typeError = 0;
                    error++;
                    menosVida(error);
                    FeedbackManagerFase3.Instance.Feedback_Test("errado");
                }else{
                    emojis[1].SetActive(true);
                    MiniFases.Instance.StartCoroutine(MiniFases.Instance.AnimarFase(resultado));
                    typeError = 1;
                    error++;
                    menosVida(error);
                    FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");
                }
                if(error >= 2){
                    Invoke("IsGameFinished", 2f);
                }else{
                    Invoke("comecarNovaFase", 5f);
                    ScoreFase3.instance.Update_Score(typeError);
                }
            }*/
        }else{
            if(operadorEscolhido && !condicaoEscolhida){
            FeedbackManagerFase3.Instance.Feedback_Test("okS/Condicao");
            }else{
                FeedbackManagerFase3.Instance.Feedback_Test("okS/Operador");
            }
            Debug.Log("partidas é maior que 6 ou nao escolheu a condicional totalmente");
        }
    }
    public void menosVida(int error){
        perdeuVida[error].SetActive(true);
        vidas[error].SetActive(false);
    }
    public void Button_X(){
        botoesCondicional[0].gameObject.SetActive(true);
        botoesCondicional[1].gameObject.SetActive(true);
        desativarSprites();
        funcaoOperador = false;
        funcaoCondicao = false;
        operadorEscolhido = false;
        condicaoEscolhida = false;
        interactableAllYes();
    }
    /*public GameObject verificaCondicional(GameObject bolaEscolhida){
        List<GameObject> bolasAtivas = new List<GameObject>();
        for(int i=0; i<bola.Length; i++){
            if(bola[i].activeSelf){
                bolasAtivas.Add(bola[i]);
            }
        }
        Button operadorEscolhido = null;
        for(int i = 0; i<operador.Length; i++){
            if(operador[i].interactable){
                operadorEscolhido = operador[i];
                break;
            }
        }
        Button condicaoEscolhida = null;
        if(tipoFase){
            for(int i =0; i<numeros.Length; i++){
                if(numeros[i].interactable){
                    condicaoEscolhida = numeros[i];
                    break;
                }
            }
        }else{
            for(int i = 0; i<parOuImpar.Length; i++){
                if(parOuImpar[i].interactable){
                    condicaoEscolhida = parOuImpar[i];
                    break;
                }
            }
            if(condicaoEscolhida == null){
                for(int i = 0; i<cores.Length; i++){
                    if(cores[i].interactable){
                        condicaoEscolhida = cores[i];
                        break;
                    }
                }
            }
        }
        Bola bolaEscolhidaScript = bolaEscolhida.GetComponent<Bola>();
        if(condicaoEscolhida == null){
            Debug.Log("Condicao Escolhida é null");
        }else{
            ButtonQuadro2Fase3 condicaoEscolhidaScript = condicaoEscolhida.GetComponent<ButtonQuadro2Fase3>();
        
        //ButtonQuadro2Fase3 condicaoEscolhidaScript = condicaoEscolhida.GetComponent<ButtonQuadro2Fase3>();
        ButtonQuadro2Fase3 operadorEscolhidoScript = operadorEscolhido.GetComponent<ButtonQuadro2Fase3>();
        if(condicaoEscolhida.CompareTag("Numero")){
            switch(operadorEscolhidoScript.operador){
                case "==":
                    if(!(bolaEscolhidaScript.numero == condicaoEscolhidaScript.numero)){
                        Debug.Log("Errado");
                        FeedbackManagerFase3.Instance.Feedback_Test("errado");
                        return bolaBranca;
                    }
                    break;
                case "!=":
                    if(!(bolaEscolhidaScript.numero != condicaoEscolhidaScript.numero)){
                        Debug.Log("Errado");
                        FeedbackManagerFase3.Instance.Feedback_Test("errado");
                        return bolaBranca;
                    }
                    break;
                case ">":  
                    if(!(bolaEscolhidaScript.numero > condicaoEscolhidaScript.numero)){
                        Debug.Log("Errado");
                        FeedbackManagerFase3.Instance.Feedback_Test("errado");
                        return bolaBranca;
                    }
                    break;
                case "<":
                    if(!(bolaEscolhidaScript.numero < condicaoEscolhidaScript.numero)){
                        Debug.Log("Errado");
                        FeedbackManagerFase3.Instance.Feedback_Test("errado");
                        return bolaBranca;
                    }
                    break;
                case ">=":
                    if(!(bolaEscolhidaScript.numero >= condicaoEscolhidaScript.numero)){
                        Debug.Log("Errado");
                        FeedbackManagerFase3.Instance.Feedback_Test("errado");
                        return bolaBranca;
                    }
                    break;
                case "<=":
                    if(!(bolaEscolhidaScript.numero <= condicaoEscolhidaScript.numero)){
                        Debug.Log("Errado");
                        FeedbackManagerFase3.Instance.Feedback_Test("errado");
                        return bolaBranca;
                    }
                    break;
            }
            for(int i=0; i<bolasAtivas.Count; i++){
                if(bolasAtivas[i] != bolaEscolhida){
                    switch(operadorEscolhidoScript.operador){
                        case "==":
                            if(bolasAtivas[i].GetComponent<Bola>().numero == condicaoEscolhidaScript.numero){
                                Debug.Log("Meio Errado");
                                FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");
                                return bolasAtivas[i];
                            }
                            break;
                        case "!=":
                            if(bolasAtivas[i].GetComponent<Bola>().numero != condicaoEscolhidaScript.numero){
                                Debug.Log("Meio Errado");
                                FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");
                                return bolasAtivas[i];
                            }
                            break;
                        case ">":
                            if(bolasAtivas[i].GetComponent<Bola>().numero > condicaoEscolhidaScript.numero){
                                Debug.Log("Meio Errado");
                                FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");
                                return bolasAtivas[i];
                            }
                            break;
                        case "<":
                            if(bolasAtivas[i].GetComponent<Bola>().numero < condicaoEscolhidaScript.numero){
                                Debug.Log("Meio Errado");
                                FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");
                                return bolasAtivas[i];
                            }
                            break;
                        case ">=":
                            if(bolasAtivas[i].GetComponent<Bola>().numero >= condicaoEscolhidaScript.numero){
                                Debug.Log("Meio Errado");
                                FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");
                                return bolasAtivas[i];
                            }
                            break;
                        case "<=":
                            if(bolasAtivas[i].GetComponent<Bola>().numero <= condicaoEscolhidaScript.numero){
                                Debug.Log("Meio Errado");
                                FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");
                                return bolasAtivas[i];
                            }
                            break;
                    }
                }
            }
        }
        if(condicaoEscolhida.CompareTag("Cor")){
            switch(operadorEscolhidoScript.operador){
                case "==":
                    if(!(bolaEscolhidaScript.cor == condicaoEscolhidaScript.cor)){
                        Debug.Log("Errado");
                        FeedbackManagerFase3.Instance.Feedback_Test("errado");
                        return bolaBranca;
                    }
                    break;
                case "!=":
                    if(!(bolaEscolhidaScript.cor != condicaoEscolhidaScript.cor)){
                        Debug.Log("Errado");
                        FeedbackManagerFase3.Instance.Feedback_Test("errado");
                        return bolaBranca;
                    }
                    break;
            }
            for(int i=0; i<bolasAtivas.Count; i++){
                if(bolasAtivas[i] != bolaEscolhida){
                    switch(operadorEscolhidoScript.operador){
                        case "==":
                            if(bolasAtivas[i].GetComponent<Bola>().cor == condicaoEscolhidaScript.cor){
                                Debug.Log("Meio Errado");
                                FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");
                                return bolasAtivas[i];
                            }
                            break;
                        case "!=":
                            if(bolasAtivas[i].GetComponent<Bola>().cor != condicaoEscolhidaScript.cor){
                                Debug.Log("Meio Errado");
                                FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");
                                return bolasAtivas[i];
                            }
                            break;
                    }
                }
            }
        }
        if(condicaoEscolhida.CompareTag("ParOuImpar")){
            switch(operadorEscolhidoScript.operador){
                case "==":
                    if(!(bolaEscolhidaScript.parOuImpar == condicaoEscolhidaScript.parOuImpar)){
                        Debug.Log("Errado");
                        FeedbackManagerFase3.Instance.Feedback_Test("errado");
                        return bolaBranca;
                    }
                    break;
                case "!=":
                    if(!(bolaEscolhidaScript.parOuImpar != condicaoEscolhidaScript.parOuImpar)){
                        Debug.Log("Errado");
                        FeedbackManagerFase3.Instance.Feedback_Test("errado");
                        return bolaBranca;
                    }
                    break;
            }
            for(int i=0; i<bolasAtivas.Count; i++){
                if(bolasAtivas[i] != bolaEscolhida){
                    switch(operadorEscolhidoScript.operador){
                        case "==":
                            if(bolasAtivas[i].GetComponent<Bola>().parOuImpar == condicaoEscolhidaScript.parOuImpar){
                                Debug.Log("Meio Errado");
                                FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");
                                return bolasAtivas[i];
                            }
                            break;
                        case "!=":
                            if(bolasAtivas[i].GetComponent<Bola>().parOuImpar != condicaoEscolhidaScript.parOuImpar){
                                Debug.Log("Meio Errado");
                                FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");
                                return bolasAtivas[i];
                            }
                            break;
                    }
                }   
            }
        }}

        Debug.Log("Certo");
        return bolaEscolhida;
    }*/
    public (int, GameObject) verificaCondicional(GameObject bolaEscolhida){
        List<GameObject> bolasAtivas = new List<GameObject>();
        int resultadoInt = 2;
        GameObject resultadoBola = bolaBranca;
        for(int i=0; i<bola.Length; i++){
            if(bola[i].activeSelf){
                bolasAtivas.Add(bola[i]);
            }
        }
        Button operadorEscolhido = null;
        for(int i = 0; i<operador.Length; i++){
            if(operador[i].interactable){
                operadorEscolhido = operador[i];
                break;
            }
        }
        Button condicaoEscolhida = null;
        if(tipoFase){
            for(int i =0; i<numeros.Length; i++){
                if(numeros[i].interactable){
                    condicaoEscolhida = numeros[i];
                    break;
                }
            }
        }else{
            for(int i = 0; i<parOuImpar.Length; i++){
                if(parOuImpar[i].interactable){
                    condicaoEscolhida = parOuImpar[i];
                    break;
                }
            }
            if(condicaoEscolhida == null){
                for(int i = 0; i<cores.Length; i++){
                    if(cores[i].interactable){
                        condicaoEscolhida = cores[i];
                        break;
                    }
                }
            }
        }
        Bola bolaEscolhidaScript = bolaEscolhida.GetComponent<Bola>();
        if(condicaoEscolhida == null){
            Debug.Log("Condicao Escolhida é null");
        }else{
            ButtonQuadro2Fase3 condicaoEscolhidaScript = condicaoEscolhida.GetComponent<ButtonQuadro2Fase3>();
        
        ButtonQuadro2Fase3 operadorEscolhidoScript = operadorEscolhido.GetComponent<ButtonQuadro2Fase3>();
        if(condicaoEscolhida.CompareTag("Numero")){
            switch(operadorEscolhidoScript.operador){
                case "==":
                    if(!(bolaEscolhidaScript.numero == condicaoEscolhidaScript.numero)){
                        Debug.Log("Errado");
                        resultadoInt = 0;
                    }
                    break;
                case "!=":
                    if(!(bolaEscolhidaScript.numero != condicaoEscolhidaScript.numero)){
                        Debug.Log("Errado");
                        
                        resultadoInt = 0;
                    }
                    break;
                case ">":  
                    if(!(bolaEscolhidaScript.numero > condicaoEscolhidaScript.numero)){
                        Debug.Log("Errado");
                        
                        resultadoInt = 0;
                    }
                    break;
                case "<":
                    if(!(bolaEscolhidaScript.numero < condicaoEscolhidaScript.numero)){
                        Debug.Log("Errado");
                        
                        resultadoInt = 0;
                    }
                    break;
                case ">=":
                    if(!(bolaEscolhidaScript.numero >= condicaoEscolhidaScript.numero)){
                        Debug.Log("Errado");
                        
                        resultadoInt = 0;
                    }
                    break;
                case "<=":
                    if(!(bolaEscolhidaScript.numero <= condicaoEscolhidaScript.numero)){
                        Debug.Log("Errado");
                        
                        resultadoInt = 0;
                    }
                    break;
            }
            for(int i=0; i<bolasAtivas.Count; i++){
                if(bolasAtivas[i] != bolaEscolhida){
                    switch(operadorEscolhidoScript.operador){
                        case "==":
                            if(bolasAtivas[i].GetComponent<Bola>().numero == condicaoEscolhidaScript.numero){
                                if(resultadoInt = 3){
                                    Debug.Log("Meio Errado");
                                    resultadoInt = 1;
                                    resultadoBola = bolasAtivas[i];
                                }else{
                                    resultadoBola = bolasAtivas[i];
                                }
                            }
                            break;
                        case "!=":
                            if(bolasAtivas[i].GetComponent<Bola>().numero != condicaoEscolhidaScript.numero){
                                Debug.Log("Meio Errado");
                                
                                resultadoInt = 1;
                                resultadoBola = bolasAtivas[i];
                            }
                            break;
                        case ">":
                            if(bolasAtivas[i].GetComponent<Bola>().numero > condicaoEscolhidaScript.numero){
                                Debug.Log("Meio Errado");
                                
                                resultadoInt = 1;
                                resultadoBola = bolasAtivas[i];
                            }
                            break;
                        case "<":
                            if(bolasAtivas[i].GetComponent<Bola>().numero < condicaoEscolhidaScript.numero){
                                Debug.Log("Meio Errado");
                                
                                resultadoInt = 1;
                                resultadoBola = bolasAtivas[i];
                            }
                            break;
                        case ">=":
                            if(bolasAtivas[i].GetComponent<Bola>().numero >= condicaoEscolhidaScript.numero){
                                Debug.Log("Meio Errado");
                                
                                resultadoInt = 1;
                                resultadoBola = bolasAtivas[i];
                            }
                            break;
                        case "<=":
                            if(bolasAtivas[i].GetComponent<Bola>().numero <= condicaoEscolhidaScript.numero){
                                Debug.Log("Meio Errado");
                                
                                resultadoInt = 1;
                                resultadoBola = bolasAtivas[i];
                            }
                            break;
                    }
                }
            }
        }
        if(condicaoEscolhida.CompareTag("Cor")){
            switch(operadorEscolhidoScript.operador){
                case "==":
                    if(!(bolaEscolhidaScript.cor == condicaoEscolhidaScript.cor)){
                        Debug.Log("Errado");
                        
                        resultadoInt = 0;
                        resultadoBola = bolaBranca;
                    }
                    break;
                case "!=":
                    if(!(bolaEscolhidaScript.cor != condicaoEscolhidaScript.cor)){
                        Debug.Log("Errado");
                        
                        resultadoInt = 0;
                        resultadoBola = bolaBranca;
                    }
                    break;
            }
            for(int i=0; i<bolasAtivas.Count; i++){
                if(bolasAtivas[i] != bolaEscolhida){
                    switch(operadorEscolhidoScript.operador){
                        case "==":
                            if(bolasAtivas[i].GetComponent<Bola>().cor == condicaoEscolhidaScript.cor){
                                Debug.Log("Meio Errado");
                                
                                resultadoInt = 1;
                                resultadoBola = bolasAtivas[i];
                            }
                            break;
                        case "!=":
                            if(bolasAtivas[i].GetComponent<Bola>().cor != condicaoEscolhidaScript.cor){
                                Debug.Log("Meio Errado");
                                
                                resultadoInt = 1;
                                resultadoBola = bolasAtivas[i];
                            }
                            break;
                    }
                }
            }
        }
        if(condicaoEscolhida.CompareTag("ParOuImpar")){
            switch(operadorEscolhidoScript.operador){
                case "==":
                    if(!(bolaEscolhidaScript.parOuImpar == condicaoEscolhidaScript.parOuImpar)){
                        Debug.Log("Errado");
                        
                        resultadoInt = 0;
                        resultadoBola = bolaBranca;
                    }
                    break;
                case "!=":
                    if(!(bolaEscolhidaScript.parOuImpar != condicaoEscolhidaScript.parOuImpar)){
                        Debug.Log("Errado");
                        
                        resultadoInt = 0;
                        resultadoBola = bolaBranca;
                    }
                    break;
            }
            for(int i=0; i<bolasAtivas.Count; i++){
                if(bolasAtivas[i] != bolaEscolhida){
                    switch(operadorEscolhidoScript.operador){
                        case "==":
                            if(bolasAtivas[i].GetComponent<Bola>().parOuImpar == condicaoEscolhidaScript.parOuImpar){
                                Debug.Log("Meio Errado");
                                
                                resultadoInt = 1;
                                resultadoBola = bolasAtivas[i];
                            }
                            break;
                        case "!=":
                            if(bolasAtivas[i].GetComponent<Bola>().parOuImpar != condicaoEscolhidaScript.parOuImpar){
                                Debug.Log("Meio Errado");
                                
                                resultadoInt = 1;
                                resultadoBola = bolasAtivas[i];
                            }
                            break;
                    }
                }   
            }
        }}

        if(resultadoInt == 2){
            resultadoBola = bolaEscolhida;
            return (resultadoInt, resultadoBola);
        }else{
            return (resultadoInt, resultadoBola);
        }
    }
    public void comecarNovaFase(){
        desativarEmojis();
        Button_X();
        desativarBolas();
        interactableAllYes();
        partidaJogadas++;
        bolaDoMomento = escolheFase();
    }
    public int escolheFase(){
        //desativarBolas();
        int faseAleatoria, bolaEscolhida = -2;
        if(partidaJogadas > 1){
            do{
                faseAleatoria = UnityEngine.Random.Range(0,miniFases.Length);
                if(!miniFasesChamadas[faseAleatoria]){
                    bolaEscolhida = miniFases[faseAleatoria]();
                    miniFasesChamadas[faseAleatoria] = true;
                    break;
                }
            }while(miniFasesChamadas[faseAleatoria]);
        }else{
            faseAleatoria = 8;
            bolaEscolhida = miniFases[faseAleatoria]();
            miniFasesChamadas[faseAleatoria] = true;
        }

        objetivoDaFase.text = "Encaçape a bola " + (bolaEscolhida+1);

        return bolaEscolhida;
    }
    public void IsGameFinished(){ // verifica se o jogo acabou ou não
        if(error >= 2){
            Fase3Manager.Instance.Finish_Game(false);
        }else{
            Fase3Manager.Instance.Finish_Game(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(partidaJogadas > 8){
            IsGameFinished();
        }else{
            partidas.text = partidaJogadas + "/8";
        }
        if(!tipoFase){
            fasePar();
        }else{
            faseNumeros();
        }
    }
}

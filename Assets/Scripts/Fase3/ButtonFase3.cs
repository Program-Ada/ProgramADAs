using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class ButtonFase3 : MonoBehaviour
{   
    public GameObject[] bola;
    public static ButtonFase3 Instance;
    public bool tipoFase;
    public bool funcaoOperador = false;
    public bool funcaoCondicao = false;
    public bool operadorEscolhido = false;
    public bool condicaoEscolhida = false;
    public GameObject[] spriteOperador;
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
            MiniFases.Instance.fase1a,
            MiniFases.Instance.fase1b,
            MiniFases.Instance.fase1c,
            MiniFases.Instance.fase1d,
            MiniFases.Instance.fase1e,
            MiniFases.Instance.fase1f
        };
        miniFasesChamadas = new bool[6];
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
            b.SetActive(false);
        }
        /*for(int i=0; i< bola.Length; i++){
            if(bola[i].activeSelf)
                bola[i].SetActive(false);
        }*/
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
            botoesCondicional[0].gameObject.SetActive(false);
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
            interactableNo(cores);
            interactableNo(parOuImpar);
            spriteNumero[i].SetActive(true);
            botoesCondicional[1].gameObject.SetActive(false);
            condicaoEscolhida = true;
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
            }
            interactableNo(parOuImpar);
            interactableNo(numeros);
            botoesCondicional[1].gameObject.SetActive(false);
            spriteCores[i].SetActive(true);
            condicaoEscolhida = true;
        }else{
            if(!funcaoOperador && funcaoCondicao){
            Debug.Log("Primeiro precisa escolher o operador");
            }else{
                Debug.Log("Primeiro precisa ativar a funcao da condicao");
            }
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
        }
    }
    public void Button_Ok(){
        if(condicaoEscolhida && partidaJogadas < 6 && error <3){
            int resultado = verificaCondicional(bola[bolaDoMomento]);
            if(resultado == 2){
                emojis[2].SetActive(true);
            }else{
                if(resultado == 1){
                    emojis[1].SetActive(true);
                    error++;
                    menosVida(error);
                }else{
                    emojis[0].SetActive(true);
                    error++;
                    menosVida(error);
                }
                ScoreFase3.instance.Update_Score(resultado);
            }
            Invoke("comecarNovaFase", 2f);
            
        }else{
            Debug.Log("partidas é maior que 6 ou nao escolheu a condicional totalmente");
        }
    }
    public void menosVida(int error){
        perdeuVida[error].SetActive(true);
        vidas[error].SetActive(false);
    }
    public void comecarNovaFase(){
        desativarEmojis();
        Button_X();
        desativarBolas();
        partidaJogadas++;
        bolaDoMomento = escolheFase();
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
    public int verificaCondicional(GameObject bolaEscolhida){
        /*GameObject[] todasBolas = GameObject.FindGameObjectsWithTag("Bola");
        GameObject[] bolasAtivas = todasBolas.Where(bola => bola.activeInHierarchy).ToArray();

        GameObject[] operadoresObjetos = GameObject.FindGameObjectsWithTag("Operador");
        Button operadorInteractable = operadoresObjetos.Select(op => op.GetComponent<Button>()).Where(btn => btn.interactable).FirstOrDefault();

        GameObject[] condicaoObjetos = GameObject.FindGameObjectsWithTag("Numero").Concat(GameObject.FindGameObjectsWithTag("Cor")).Concat(GameObject.FindGameObjectsWithTag("ParOuImpar")).ToArray();
        Button condicaoEscolhida = condicaoObjetos.Select(cond => cond.GetComponent<Button>()).Where(btn => btn.interactable).FirstOrDefault();*/
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
                        return 0;
                    }
                    break;
                case "!=":
                    if(!(bolaEscolhidaScript.numero != condicaoEscolhidaScript.numero)){
                        Debug.Log("Errado");
                        FeedbackManagerFase3.Instance.Feedback_Test("errado");
                        return 0;
                    }
                    break;
                case ">":  
                    if(!(bolaEscolhidaScript.numero > condicaoEscolhidaScript.numero)){
                        Debug.Log("Errado");
                        FeedbackManagerFase3.Instance.Feedback_Test("errado");
                        return 0;
                    }
                    break;
                case "<":
                    if(!(bolaEscolhidaScript.numero < condicaoEscolhidaScript.numero)){
                        Debug.Log("Errado");
                        FeedbackManagerFase3.Instance.Feedback_Test("errado");
                        return 0;
                    }
                    break;
                case ">=":
                    if(!(bolaEscolhidaScript.numero >= condicaoEscolhidaScript.numero)){
                        Debug.Log("Errado");
                        FeedbackManagerFase3.Instance.Feedback_Test("errado");
                        return 0;
                    }
                    break;
                case "<=":
                    if(!(bolaEscolhidaScript.numero <= condicaoEscolhidaScript.numero)){
                        Debug.Log("Errado");
                        FeedbackManagerFase3.Instance.Feedback_Test("errado");
                        return 0;
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
                                return 1;
                            }
                            break;
                        case "!=":
                            if(bolasAtivas[i].GetComponent<Bola>().numero != condicaoEscolhidaScript.numero){
                                Debug.Log("Meio Errado");
                                FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");
                                return 1;
                            }
                            break;
                        case ">":
                            if(bolasAtivas[i].GetComponent<Bola>().numero > condicaoEscolhidaScript.numero){
                                Debug.Log("Meio Errado");
                                FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");
                                return 1;
                            }
                            break;
                        case "<":
                            if(bolasAtivas[i].GetComponent<Bola>().numero < condicaoEscolhidaScript.numero){
                                Debug.Log("Meio Errado");
                                FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");
                                return 1;
                            }
                            break;
                        case ">=":
                            if(bolasAtivas[i].GetComponent<Bola>().numero >= condicaoEscolhidaScript.numero){
                                Debug.Log("Meio Errado");
                                FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");
                                return 1;
                            }
                            break;
                        case "<=":
                            if(bolasAtivas[i].GetComponent<Bola>().numero <= condicaoEscolhidaScript.numero){
                                Debug.Log("Meio Errado");
                                FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");
                                return 1;
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
                        return 0;
                    }
                    break;
                case "!=":
                    if(!(bolaEscolhidaScript.cor != condicaoEscolhidaScript.cor)){
                        Debug.Log("Errado");
                        FeedbackManagerFase3.Instance.Feedback_Test("errado");
                        return 0;
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
                                return 1;
                            }
                            break;
                        case "!=":
                            if(bolasAtivas[i].GetComponent<Bola>().cor != condicaoEscolhidaScript.cor){
                                Debug.Log("Meio Errado");
                                FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");
                                return 1;
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
                        return 0;
                    }
                    break;
                case "!=":
                    if(!(bolaEscolhidaScript.parOuImpar != condicaoEscolhidaScript.parOuImpar)){
                        Debug.Log("Errado");
                        FeedbackManagerFase3.Instance.Feedback_Test("errado");
                        return 0;
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
                                return 1;
                            }
                            break;
                        case "!=":
                            if(bolasAtivas[i].GetComponent<Bola>().parOuImpar != condicaoEscolhidaScript.parOuImpar){
                                Debug.Log("Meio Errado");
                                FeedbackManagerFase3.Instance.Feedback_Test("meioErrado");
                                return 1;
                            }
                            break;
                    }
                }   
            }
        }}

        Debug.Log("Certo");
        return 2;
    }
    public int escolheFase(){
        //desativarBolas();
        int faseAleatoria, bolaEscolhida = -2;
        do{
            faseAleatoria = UnityEngine.Random.Range(0,miniFases.Length);
            if(!miniFasesChamadas[faseAleatoria]){
                bolaEscolhida = miniFases[faseAleatoria]();
                miniFasesChamadas[faseAleatoria] = true;
                break;
            }
        }while(miniFasesChamadas[faseAleatoria]);

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
        /*Button operadorEscolhido = operador[2];
        ButtonQuadro2Fase3 scriptOperador = operadorEscolhido.GetComponent<ButtonQuadro2Fase3>();
        Debug.Log(scriptOperador.operador);*/
        //IsGameFinished();
        if(partidaJogadas > 5 || error >= 3){
            IsGameFinished();
        }
        partidas.text = partidaJogadas + "/6";
        if(!tipoFase){
            fasePar();
        }else{
            faseNumeros();
        }
    }
}

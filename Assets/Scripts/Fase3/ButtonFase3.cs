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
            MiniFases.Instance.fase10,
            MiniFases.Instance.fase11,
            MiniFases.Instance.fase12,
            MiniFases.Instance.fase13,
            MiniFases.Instance.fase14,
            MiniFases.Instance.fase15
        };
        miniFasesChamadas = new bool[15];
        //comecarNovaFase();
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
            emojis[0].SetActive(true);
            Invoke("comecarNovaFase", 2f);
            //verificaCondicional(bola[bolaDoMomento]);
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
    public T descobreBolaAtiva<T>(GameObject bolaAtiva, string tag){
        Bola scriptBolaAtiva = bolaAtiva.GetComponent<Bola>();
        
        object valor = tag switch {
            "Numero" => scriptBolaAtiva.numero,
            "Cor" => scriptBolaAtiva.cor,
            _ => scriptBolaAtiva.parOuImpar
        };

        return (T)valor;
    }
    public (int, GameObject) verificaSwitch<T>(
    GameObject bolaEscolhida, 
    T condicaoButton, 
    T condicaoBola, 
    string operadorMiniFase, 
    List<GameObject> bolasAtivas,
    string tag){
        int resultadoInt = 2;
        GameObject resultadoBola = bolaBranca;
        var comparer = Comparer<T>.Default;
        var equality = EqualityComparer<T>.Default;
        switch(operadorMiniFase){
            case "==":
                if(!(comparer.Compare(condicaoBola, condicaoButton) == 0)){
                    Debug.Log("Errado");
                    resultadoInt = 0;
                }
                break;
            case "!=":
                if(!(comparer.Compare(condicaoBola, condicaoButton) != 0)){
                    Debug.Log("Errado");
                    resultadoInt = 0;
                }
                break;
            case ">":  
                if(tipoFase && !(comparer.Compare(condicaoBola, condicaoButton) > 0)){
                    Debug.Log("Errado");
                    resultadoInt = 0;
                }
                break;
            case "<":
                if(tipoFase && !(comparer.Compare(condicaoBola, condicaoButton) < 0)){
                    Debug.Log("Errado");
                    resultadoInt = 0;
                }
                break;
            case ">=":
                if(tipoFase && !(comparer.Compare(condicaoBola, condicaoButton) >= 0)){
                    Debug.Log("Errado");
                    resultadoInt = 0;
                }
                break;
            case "<=":
                if(tipoFase && !(comparer.Compare(condicaoBola, condicaoButton) <= 0)){
                    Debug.Log("Errado");
                    resultadoInt = 0;
                }
                break;
        }
        for(int i=0; i<bolasAtivas.Count; i++){
            T condicaoBolaAtiva = descobreBolaAtiva<T>(bolasAtivas[i], tag);
            if(bolasAtivas[i] != bolaEscolhida){
                switch(operadorMiniFase){
                    case "==":
                        Debug.Log("Entrou no case");
                        if(comparer.Compare(condicaoBolaAtiva, condicaoButton) == 0){
                            if(resultadoInt == 2){
                                Debug.Log("Meio Errado");
                                resultadoInt = 1;
                                resultadoBola = bolasAtivas[i];
                            }else{
                                Debug.Log("Entrou aqui");
                                resultadoBola = bolasAtivas[i];
                            }
                        }
                        break;
                        //Debug.Log(resultadoBola.GetComponent<Bola>().numero);
                    case "!=":
                        Debug.Log("Entrou no case");
                        if(comparer.Compare(condicaoBolaAtiva, condicaoButton) != 0){
                            if(resultadoInt == 2){
                                Debug.Log("Meio Errado");
                                resultadoInt = 1;
                                resultadoBola = bolasAtivas[i];
                            }else{
                                Debug.Log("Entrou aqui");
                                resultadoBola = bolasAtivas[i];
                            }
                        }
                        break;
                        //Debug.Log(resultadoBola.GetComponent<Bola>().numero);
                    case ">":
                        Debug.Log("Entrou no case");
                        if(tipoFase && comparer.Compare(condicaoBolaAtiva, condicaoButton) > 0){
                            if(resultadoInt == 2){
                                Debug.Log("Meio Errado");
                                resultadoInt = 1;
                                resultadoBola = bolasAtivas[i];
                            }else{
                                Debug.Log("Entrou aqui");
                                resultadoBola = bolasAtivas[i];
                            }
                        }
                        break;
                        //Debug.Log(resultadoBola.GetComponent<Bola>().numero);
                    case "<":
                        Debug.Log("Entrou no case");
                        if(tipoFase && comparer.Compare(condicaoBolaAtiva, condicaoButton) < 0){
                            if(resultadoInt == 2){
                                Debug.Log("Meio Errado");
                                resultadoInt = 1;
                                resultadoBola = bolasAtivas[i];
                            }else{
                                Debug.Log("Entrou aqui");
                                resultadoBola = bolasAtivas[i];
                            }
                        }
                        break;
                        //Debug.Log(resultadoBola.GetComponent<Bola>().numero);
                    case ">=":
                        Debug.Log("Entrou no case");
                        if(tipoFase && comparer.Compare(condicaoBolaAtiva, condicaoButton) >= 0){
                            if(resultadoInt == 2){
                                Debug.Log("Meio Errado");
                                resultadoInt = 1;
                                resultadoBola = bolasAtivas[i];
                            }else{
                                Debug.Log("Entrou aqui");
                                resultadoBola = bolasAtivas[i];
                            }
                        }
                        break;
                        //Debug.Log(resultadoBola.GetComponent<Bola>().numero);
                    case "<=":
                        Debug.Log("Entrou no case");
                        if(tipoFase && comparer.Compare(condicaoBolaAtiva, condicaoButton) <= 0){
                            if(resultadoInt == 2){
                                Debug.Log("Meio Errado");
                                resultadoInt = 1;
                                resultadoBola = bolasAtivas[i];
                            }else{
                                Debug.Log("Entrou aqui");
                                resultadoBola = bolasAtivas[i];
                            }
                        }
                        break;
                        //Debug.Log(resultadoBola.GetComponent<Bola>().numero);
                }
                if(resultadoInt == 1 || (resultadoInt == 0 && resultadoBola != bolaBranca))
                    break;
            }
        }
        if(resultadoInt == 2){
            Debug.Log("Entrou no resultadoInt == 2");
            Debug.Log("Certo");
            resultadoBola = bolaEscolhida;
        }
        return (resultadoInt, resultadoBola);
    }
    
    public Button criaCondicional(Button[] escolhido){
        for(int i=0; i<escolhido.Length; i++){
            if(escolhido[i].interactable){
                return escolhido[i];
            }
        }
        return null;
    }
    public void verificaCondicional(GameObject bolaEscolhida){
        int resultadoInt = -1;
        GameObject resultadoBola = null;
        List<GameObject> bolasAtivas = new List<GameObject>();
        for(int i=0; i<bola.Length; i++){
            if(bola[i].activeSelf){
                bolasAtivas.Add(bola[i]);
            }
        }
        Button operadorEscolhidoCondicional = criaCondicional(operador);
        Button condicaoEscolhida = null;
        if(tipoFase){
            condicaoEscolhida = criaCondicional(numeros);
        }else{
            condicaoEscolhida = criaCondicional(parOuImpar);
            if(condicaoEscolhida == null){
                condicaoEscolhida = criaCondicional(cores);
            }
        }
        if(condicaoEscolhida == null){
            Debug.Log("Condicao Escolhida é null");
        }else{
            string operadorMiniFase = operadorEscolhidoCondicional.GetComponent<ButtonQuadro2Fase3>().operador;
            ButtonQuadro2Fase3 condicaoEscolhidaScript = condicaoEscolhida.GetComponent<ButtonQuadro2Fase3>();
            Bola bolaEscolhidaScript = bolaEscolhida.GetComponent<Bola>();
            if(condicaoEscolhida.CompareTag("Numero")){
                int numeroCondicaoButton = condicaoEscolhidaScript.numero;
                int numeroCondicaoBola = bolaEscolhidaScript.numero;
                (resultadoInt, resultadoBola) = verificaSwitch<int>(bolaEscolhida, numeroCondicaoButton, numeroCondicaoBola, operadorMiniFase, bolasAtivas, "Numero");
            }else if(condicaoEscolhida.CompareTag("Cor")){
                string corCondicaoButton = condicaoEscolhidaScript.cor;
                string corCondicaoBola = bolaEscolhidaScript.cor;
                (resultadoInt, resultadoBola) = verificaSwitch<string>(bolaEscolhida, corCondicaoButton, corCondicaoBola, operadorMiniFase, bolasAtivas, "Cor");
            }else{
                string parOuImparCondicaoButton = condicaoEscolhidaScript.parOuImpar;
                string parOuImparCondicaoBola = bolaEscolhidaScript.parOuImpar;
                (resultadoInt, resultadoBola) = verificaSwitch<string>(bolaEscolhida, parOuImparCondicaoButton, parOuImparCondicaoBola, operadorMiniFase, bolasAtivas, "ParOuImpar");
            }
        }
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
                Invoke("IsGameFinished", 2f);
            }else{
                Invoke("comecarNovaFase", 4f);
                ScoreFase3.instance.Update_Score(resultadoInt);
            }
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
    public void ButtonFase(bool fase){
        if(fase){
            tipoFase = true;
            faseNumeros();
        }else{
            tipoFase = false;
            fasePar();
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
    }
}

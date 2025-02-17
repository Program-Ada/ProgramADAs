using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonFase3 : MonoBehaviour
{   
    public GameObject[] spriteOperador;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<spriteOperador.Length; i++){
            spriteOperador[i].SetActive(false);
        }
    }
    public void Button_EscolheOperador(int i){
        spriteOperador[i].SetActive(true);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

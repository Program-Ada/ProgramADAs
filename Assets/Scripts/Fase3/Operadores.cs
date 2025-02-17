using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operadores : MonoBehaviour
{
    // Start is called before the first frame update
    public static Operadores Instance;
    public string operador;
    public bool buttonOperador;
    void Start()
    {
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condicao : MonoBehaviour
{
    public static Condicao Instance;
    public bool buttonCondicao;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

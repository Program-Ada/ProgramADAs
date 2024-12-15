using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCutscene : MonoBehaviour
{
    private int count = 0;
    public GameObject jump;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("Escape key was released");
            count = 0;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Escape key is being pressed: " + count);
            count++;
        }

        if(count >= 1){ // a ideia seria ativar uma animação para mostrar quanto precisa pressionar para pular mas vou deixar só o clique por enquanto
            jump.SetActive(true);
        }

        
    }
}

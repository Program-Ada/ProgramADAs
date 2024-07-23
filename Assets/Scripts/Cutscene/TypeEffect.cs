using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeEffect : MonoBehaviour
{
    public string currentLine;
    public TextMeshProUGUI cutsceneTextField;

    void OnEnable(){
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence (string currentLine){
        cutsceneTextField.text = "";
        foreach(char letter in currentLine.ToCharArray()){
            cutsceneTextField.text += letter;
            yield return new WaitForSeconds((float)0.06);
        }
    }
}

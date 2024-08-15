using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public Sprite image;
    public string name;

    [TextArea(3, 10)]
    public string[] setences;
    public bool haveQuestion;
    public GameObject question;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Chapter 
{
    public int chapterID;
    public string tittle;
    [TextArea(3,10)]
    public string content;
}

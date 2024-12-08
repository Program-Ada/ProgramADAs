using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [System.Serializable]
 public class Feedback{
    public Sprite image;
    public string name;
    [TextArea(3,10)]
    public List<string> sentences = new List<string>(); 
}

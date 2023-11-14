using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

 [System.Serializable]
public class Dialogue{

public Sprite image;
public string name;

[TextArea(3,10)]
public string[] setences;

}

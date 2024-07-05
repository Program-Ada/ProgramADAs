using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [System.Serializable]
 public class DialogueCharacter{
    public Sprite image;
    public string name;
}


 [System.Serializable]
 public class DialogueLine{

    public DialogueCharacter character;

    [TextArea(3,10)]
    public string sentence;
}

 [System.Serializable]
public class Dialogue{

    public List<DialogueLine> dialogueLines = new List<DialogueLine>();

}


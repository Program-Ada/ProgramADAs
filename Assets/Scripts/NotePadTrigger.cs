using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class NotePadTrigger : MonoBehaviour
{
    public Chapter chapter;
    public ChapterManager cm;
    // public bool teste;
    // Start is called before the first frame update
    void Start()
    {
        cm = FindObjectOfType<ChapterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(teste) {
            TriggerChapter();
        // }
    }

    public void TriggerChapter() {
        cm.ShowChapter(chapter);
    }
}

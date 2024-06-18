using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class NotePadTrigger : MonoBehaviour
{
    public Chapter chapter;
    private ChapterManager cm;

    // Start is called before the first frame update
    void Start()
    {
        cm = FindObjectOfType<ChapterManager>();
    }

    public void TriggerChapter() {
        cm.ShowChapter(chapter);
    }
}

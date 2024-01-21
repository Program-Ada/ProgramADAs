using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChapterManager : MonoBehaviour
{
    public TextMeshProUGUI tittleChapter;
    public TextMeshProUGUI contentChapter;

    public Animator animator;
    
    // private Queue<string> tittleChapter;

    int currentpage = 1;

    // Start is called before the first frame update
    void Start()
    {
        // tittleChapter = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowChapter(Chapter chapter) {
        // animator.SetBool("IsOpen", true);

        tittleChapter.text = chapter.tittle;
        contentChapter.text = chapter.content;

        // foreach (string word in chapter.tittle){
        //     tittleChapter.Enqueue(word);
        // }
    }

    public void NextPage_Btn()
    {
        int totalpages = contentChapter.textInfo.pageCount;

        if (currentpage < totalpages)
        {
            currentpage++;
            contentChapter.pageToDisplay++;
        }
    }

    public void PrevPage_Btn()
    {
        if (currentpage > 0)
        {
            currentpage--;
            contentChapter.pageToDisplay--;
        }
    }
}

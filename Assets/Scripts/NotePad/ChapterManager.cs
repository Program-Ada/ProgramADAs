using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChapterManager : MonoBehaviour
{
    public TextMeshProUGUI titleChapter;
    public TextMeshProUGUI contentChapter;

    public int currentpage = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentpage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowChapter(Chapter chapter) {
        Debug.Log(chapter.tittle);
        titleChapter.text = chapter.tittle;
        contentChapter.text = chapter.content;
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

    public void ResetPage() {
        currentpage = 1;
        contentChapter.pageToDisplay = 1;
    }
}

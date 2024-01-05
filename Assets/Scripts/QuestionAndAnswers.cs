using UnityEngine;

[System.Serializable]
public class QuestionAndAnswers
{
    [TextArea(3,10)]
    public string Question;
    public string[] Answers;
    public int correctAnswer;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeManager : MonoBehaviour
{
    public static CafeManager instance;
    public int maxOrders;
    void Start()
    {
        instance = this;
        maxOrders = 6;
    }

    public void Finish_Game(bool finish){
        if(finish){
            ScoreCafe.instance.Show_Score();
        }else{
            ScoreCafe.instance.Show_Loose();
        }
    }

    public void CheckParameter(string flavor){
        if(Foods.Instance.isFoodFunctionSelected){
            switch (flavor)
            {
                case "chocolate":
                    Foods.Instance.Show_Option(0);
                    break;
                case "morango":
                    Foods.Instance.Show_Option(1);
                    break;
                default:
                    FeedbackManager.Instance.Feedback_Test("parametroBolo");
                    break;
                    
            }
        }else if(Drinks.Instance.isDrinkFunctionSelected){
            switch (flavor)
            {
                case "melancia":
                    Drinks.Instance.Show_Option(0);
                    break;
                case "uva":
                    Drinks.Instance.Show_Option(1);
                    break;
                case "laranja":
                    Drinks.Instance.Show_Option(2);
                    break;
                default:
                    FeedbackManager.Instance.Feedback_Test("parametroSuco");
                    break;
                    
            }
        }
    }
}

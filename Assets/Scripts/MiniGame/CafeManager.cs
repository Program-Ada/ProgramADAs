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
}

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
}

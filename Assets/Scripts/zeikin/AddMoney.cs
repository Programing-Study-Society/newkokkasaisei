using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoney : MonoBehaviour
{
    private int oldMonth;
    const int addMoney = 1000000000;//追加するお金

    // Start is called before the first frame update
    void Start()
    {
        oldMonth = globalValue.monthNumber;
    }

    // Update is called once per frame
    void Update()
    {
        TradeAddMoney();
    }

    public void TradeAddMoney()
    {
        if (globalValue.monthNumber != oldMonth)
        {
            globalValue.money += (int)(addMoney * globalValue.tradeSize);
            oldMonth = globalValue.monthNumber;
        }
    }
}

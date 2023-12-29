using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoney : MonoBehaviour
{
    private int oldMonth;
    const int addMoney = 1000000;//�ǉ����邨��

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
            globalValue.money += (int)((addMoney * globalValue.population * 8) / 2000);
            oldMonth = globalValue.monthNumber;
        }
    }
}

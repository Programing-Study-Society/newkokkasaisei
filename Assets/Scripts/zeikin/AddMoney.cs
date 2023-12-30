using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoney : MonoBehaviour
{
    private int oldMonth;
    const int addMegaMoney = 1;
    const int addMoney = 1000000;//’Ç‰Á‚·‚é‚¨‹à
    public Kenkyuu kenkyuu;
    public money money;
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
        int addMega = 0;

        if (globalValue.monthNumber != oldMonth)
        {
            double moneyAdd = (double)(addMegaMoney * globalValue.tradeSize);
            moneyAdd += (double)((double)(addMegaMoney * globalValue.population) / 2500);
            
            if (moneyAdd > 1.0)
            {
                double moneyAddBox = moneyAdd; 
                addMega = (int)(moneyAddBox);
            }

            globalValue.money += (int)((moneyAdd - (double)addMega) * (double)addMoney);
            globalValue.gigaMoney += addMega;
            
            kenkyuu.Ani();
            oldMonth = globalValue.monthNumber;
        }
    }
}

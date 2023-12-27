using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpace;

public class YesOrNoButton : MonoBehaviour
{
    public EventManager eventManager;
    public MainTextController mainTextController;
    public ButtonActive buttonActive;

    public void YesButtonClick()
    {
        if (mainTextController.CanGoToTheNextLine())
        {
            mainTextController.OnClickNextText();
            buttonActive.ButtonSetActiveFalse();
            eventManager.randomAddValue();
            globalValue.friendshipLevel[globalValue.randomValue] += 5;
            if (globalValue.friendshipLevel[globalValue.randomValue] > 100)
            {
                globalValue.friendshipLevel[globalValue.randomValue] = 100;
            }
            TradeMagnification();
            
        }
    }

    public void NoButtonClick()
    {
        if (mainTextController.CanGoToTheNextLine()){
            mainTextController.OnClickNextText();
            buttonActive.ButtonSetActiveFalse();
            globalValue.friendshipLevel[globalValue.randomValue] -= 10;
            if (globalValue.friendshipLevel[globalValue.randomValue] <= 0)
            {
                globalValue.friendshipLevel[globalValue.randomValue] = 0;
                globalValue.tradeSituation[globalValue.randomValue] = "戦争中";
            }
            if (globalValue.friendshipLevel[globalValue.randomValue] < 60)
            {
                globalValue.tradeSituation[globalValue.randomValue] = "していない";
            }
            TradeMagnification();
            
        }
    }

    //貿易で得られるお金の倍率を求める関数
    public void TradeMagnification()
    {
        double magnification = 0;
        globalValue.tradeSize = 0;
        for (int i = 0; i < globalValue.tradeSituation.Count; i++)
        {
            if (globalValue.tradeSituation[i] == "貿易中")
            {
                magnification += globalValue.friendshipLevel[i] - 50;
                globalValue.tradeSize++;
            }
        }
        magnification /= 10;
        magnification *= 0.5;
        globalValue.tradeSize += magnification;
        //Debug.Log(globalValue.tradeSize);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpace;

public class YesOrNoButton : MonoBehaviour
{
    public EventManager eventManager;
    public MainTextController mainTextController;

    public void YesButtonClick()
    {
        mainTextController.OnClickNextText();
        eventManager.randomAddValue();
        globalValue.friendshipLevel[globalValue.randomValue] += 5;
        if (globalValue.friendshipLevel[globalValue.randomValue] > 100)
        {
            globalValue.friendshipLevel[globalValue.randomValue] = 100;
        }
        TradeMagnification();
    }

    public void NoButtonClick()
    {
        mainTextController.OnClickNextText();
        globalValue.friendshipLevel[globalValue.randomValue] -= 10;
        if (globalValue.friendshipLevel[globalValue.randomValue] <= 0)
        {
            globalValue.friendshipLevel[globalValue.randomValue] = 0;
            globalValue.tradeSituation[globalValue.randomValue] = "í‘ˆ’†";
        }
        if (globalValue.friendshipLevel[globalValue.randomValue] < 60)
        {
            globalValue.tradeSituation[globalValue.randomValue] = "‚µ‚Ä‚¢‚È‚¢";
        }
        TradeMagnification();
    }

    //–fˆÕ‚Å“¾‚ç‚ê‚é‚¨‹à‚Ì”{—¦‚ð‹‚ß‚éŠÖ”
    public void TradeMagnification()
    {
        double magnification = 0;
        globalValue.tradeSize = 0;
        for (int i = 0; i < globalValue.tradeSituation.Count; i++)
        {
            if (globalValue.tradeSituation[i] == "–fˆÕ’†")
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

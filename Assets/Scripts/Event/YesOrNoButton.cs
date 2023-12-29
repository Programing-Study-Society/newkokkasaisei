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
            if (globalValue.randomEventNumber == 4)
            {
                globalValue.friendshipLevel[globalValue.randomValue] += 10;
                if (globalValue.friendshipLevel[globalValue.randomValue] > 100)
                {
                    globalValue.friendshipLevel[globalValue.randomValue] = 100;
                }
                TradeMagnification();
            }
            else if (globalValue.randomEventNumber == 5)
            {
                if (globalValue.complain > 0)
                {
                    globalValue.complain -= 5;
                }
            }
            
        }
    }

    public void NoButtonClick()
    {
        if (mainTextController.CanGoToTheNextLine()){
            mainTextController.OnClickNextText();
            buttonActive.ButtonSetActiveFalse();
            if (globalValue.randomEventNumber == 4)
            {
                globalValue.friendshipLevel[globalValue.randomValue] -= 5;
                if (globalValue.friendshipLevel[globalValue.randomValue] <= 0)
                {
                    globalValue.friendshipLevel[globalValue.randomValue] = 0;
                    globalValue.tradeSituation[globalValue.randomValue] = "�푈��";
                }
                if (globalValue.friendshipLevel[globalValue.randomValue] < 50)
                {
                    globalValue.tradeSituation[globalValue.randomValue] = "�ł��܂���";
                }
                TradeMagnification();
            }else if (globalValue.randomEventNumber == 5)
            {
                globalValue.complain += 10;
            }

        }
    }

    //�f�Ղœ����邨���̔{�������߂�֐�
    public void TradeMagnification()
    {
        double magnification = 0;
        globalValue.tradeSize = 0;
        for (int i = 0; i < globalValue.tradeSituation.Count; i++)
        {
            if (globalValue.tradeSituation[i] == "�f�Ւ�")
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

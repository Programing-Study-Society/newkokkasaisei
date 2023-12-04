using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class butoonActive : MonoBehaviour
{
    public List<GameObject> buttonList;
    int buttonListPoint = 0;
    int buttonListMax;

    bool buttonNumber = false;

    public void buttonInteractable()
    {
        buttonListMax = buttonList.Count;

        for (buttonListPoint = 0; buttonListPoint < buttonListMax; buttonListPoint++)
        {
            buttonListMax = buttonList.Count;
            Button btn = buttonList[buttonListPoint].GetComponent<Button>();
            if(buttonNumber == false)
            {
                btn.interactable = false;
            }
            else
            {
                btn.interactable = true;
            }
        }
        if(buttonNumber == false)
        {
            buttonNumber = true;
        }
        else
        {
            buttonNumber = false;
        }
    }
}

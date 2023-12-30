using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActive : MonoBehaviour
{
    public List<GameObject> buttonList;
    
    bool buttonNumber = false;

    public void buttonInteractable()
    {
        int buttonListMax = buttonList.Count;

        for (int buttonListPoint = 0; buttonListPoint < buttonListMax; buttonListPoint++)
        {
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

    public void ButtonSetActiveFalse()
    {
        int buttonListMax = buttonList.Count;
        for (int buttonListPoint = 0; buttonListPoint < buttonListMax; buttonListPoint++)
        {
            buttonList[buttonListPoint].SetActive(false);
        }
        
    }
    public void ButtonSetActiveTrue()
    {
        int buttonListMax = buttonList.Count;
        for (int buttonListPoint = 0; buttonListPoint < buttonListMax; buttonListPoint++)
        {
            buttonList[buttonListPoint].SetActive(true);
        }

    }
}

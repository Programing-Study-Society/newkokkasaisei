using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialLimitRange : MonoBehaviour
{
    public List<GameObject> buttonList;
    int buttonListPoint = 0;
    int buttonListPoint2 = 0;
    int buttonListMax;

    RectTransform buttonListPos;

    public void buttonInteractable()
    {
        buttonListMax = buttonList.Count;
        
        for (buttonListPoint = 0; buttonListPoint < buttonListMax; buttonListPoint++)
        {
            buttonListMax = buttonList.Count;
            Button btn = buttonList[buttonListPoint].GetComponent<Button>();
            btn.interactable = false;
        }

        buttonListPoint = 0;
    }

    public void buttonTrue()
    {
        buttonListMax = buttonList.Count;
        for (buttonListPoint = 0; buttonListPoint < buttonListMax; buttonListPoint++)
        {
            Button btn = buttonList[buttonListPoint].GetComponent<Button>();
            btn.interactable = true;
        }

        buttonListPoint = 0;
    }

    public void buttonSelect(RectTransform selectTransform)
    {
        buttonListMax = buttonList.Count;

        if (buttonListPoint2 < buttonListMax)
        {
            buttonListPos = buttonList[buttonListPoint2].GetComponent<RectTransform>();
            if (buttonListPos == selectTransform)
            {
                Button btn = buttonList[buttonListPoint2].GetComponent<Button>();
                btn.interactable = true;
                buttonListPoint2++;

            }
        }
        else
        {
            buttonListPoint2 = 0;
        }
        
    }
    
}

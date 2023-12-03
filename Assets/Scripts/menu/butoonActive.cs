using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class butoonActive : MonoBehaviour
{
    public List<GameObject> buttonList;
    int buttonListPoint = 0;
    int buttonListMax;

    public void buttonInteractable()
    {
        buttonListMax = buttonList.Count;

        for (buttonListPoint = 0; buttonListPoint < buttonListMax; buttonListPoint++)
        {
            buttonListMax = buttonList.Count;
            Button btn = buttonList[buttonListPoint].GetComponent<Button>();
            if(btn.interactable == false)
            {
                btn.interactable = true;
            }
            else
            {
                btn.interactable = false;
            }
        }
    }
}

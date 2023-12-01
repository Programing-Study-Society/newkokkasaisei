using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialLimitRange : MonoBehaviour
{
    public TutorialManager tutorialManager;
    public List<GameObject> buttonList;
    int buttonListPoint = 0;
    int buttonListPoint2 = 0;
    int buttonListMax;

    RectTransform buttonListPos;

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {

    }

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

    public void buttonSelect()
    {
        buttonListMax = buttonList.Count;

        if (buttonListPoint2 < buttonListMax)
        {
            buttonListPos = buttonList[buttonListPoint2].GetComponent<RectTransform>();
            if (buttonListPos == tutorialManager.movingObjectList[tutorialManager.movingObjectListPoint])
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

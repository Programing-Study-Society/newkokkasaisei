using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeSetActive : MonoBehaviour
{

    public List<GameObject> setActiveObject;

    private int setActiveObjectListPoint = 0;

    private int listMaxCount = 0;

    public void OnButton()
    {
        listMaxCount = setActiveObject.Count;
        for(setActiveObjectListPoint = 0; setActiveObjectListPoint < listMaxCount; setActiveObjectListPoint++)
        {
            if (setActiveObject[setActiveObjectListPoint].gameObject.activeSelf)
            {
                setActiveObject[setActiveObjectListPoint].gameObject.SetActive(false);
            }
            else
            {
                setActiveObject[setActiveObjectListPoint].gameObject.SetActive(true);
            }
        }
        
    }

    public void changeTutorialExecution()
    {
        if(globalValue.tutorialExecution == false)
        {
            globalValue.tutorialExecution = true;
        }
        else
        {
            globalValue.tutorialExecution = false;
        }
    }
}

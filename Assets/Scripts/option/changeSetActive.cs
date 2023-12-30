using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeSetActive : MonoBehaviour
{

    public List<GameObject> setActiveObject;

    private int setActiveObjectListPoint = 0;

    private int listMaxCount = 0;

    
    public void OnSetActiveButton()
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
    public void LeftSlideSetActive()
    {
        listMaxCount = setActiveObject.Count;
        
        for (setActiveObjectListPoint = 0; setActiveObjectListPoint < listMaxCount; setActiveObjectListPoint++)
        {
            if (setActiveObject[setActiveObjectListPoint].gameObject.activeSelf)
            {
                if (setActiveObjectListPoint > 0)
                {
                    setActiveObject[setActiveObjectListPoint].gameObject.SetActive(false);
                    setActiveObject[setActiveObjectListPoint - 1].gameObject.SetActive(true);
                }
                break;
            }
            
        }
    }
    public void RightSlideSetActive()
    {
        listMaxCount = setActiveObject.Count;
        for (setActiveObjectListPoint = 0; setActiveObjectListPoint < listMaxCount; setActiveObjectListPoint++)
        {
            if (setActiveObject[setActiveObjectListPoint].gameObject.activeSelf)
            {
                if (setActiveObjectListPoint < listMaxCount -1)
                {
                    Debug.Log(setActiveObjectListPoint);
                    Debug.Log(setActiveObjectListPoint + 1);
                    setActiveObject[setActiveObjectListPoint].gameObject.SetActive(false);
                    setActiveObject[setActiveObjectListPoint + 1].gameObject.SetActive(true);
                }
                break;
            }

        }
    }
}

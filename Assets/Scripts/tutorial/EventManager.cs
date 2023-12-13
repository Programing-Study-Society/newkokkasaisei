using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public List<GameObject> eventObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TutorialFrag();
    }

    public void StartEvent()
    {
        eventObject[globalValue.eventNumber].SetActive(true);
    }
    
    public void EndEvent()
    {
        globalValue.eventExecution = false;
        eventObject[globalValue.eventNumber].SetActive(false);
        globalValue.eventNumber++;
    }

    public void TutorialFrag()
    {
        if(globalValue.eventNumber == 0)
        {
            if (!globalValue.eventExecution)
            {
                globalValue.eventExecution = true;
                StartEvent();
                
            }
        }
        else if(globalValue.eventNumber == 1)
        {
            globalValue.eventExecution = true;
            StartEvent();
        }
        else
        {

        }
    }
}

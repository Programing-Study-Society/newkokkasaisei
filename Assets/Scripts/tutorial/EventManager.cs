using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public List<GameObject> eventObject;

    [HideInInspector] public int eventNumber = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TutorialFrag();
    }

    public void EventSetActive()
    {
        eventObject[eventNumber].SetActive(true);
    }

    public void TutorialFrag()
    {
        if (globalValue.eventExecution)
        {
            EventSetActive();
            globalValue.eventExecution = true;
        }
    }
}

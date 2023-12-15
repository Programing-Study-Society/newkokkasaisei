using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpace;

public class RandomEventManager : MonoBehaviour
{
    public EventManager eventManager;
    public MainTextController mainTextController;
    public MousePosition MousePosition;
    
    public int lastLine;//行の最後

    // Update is called once per frame
    void Update()
    {

        //どこを押しても次のテキストに行けるようにする
        MousePosition.UpDataRangeObject();

        //最後の行から改行したら終了
        if (globalValue.lineNumber > lastLine - 1)
        {
            EndRandomEvent();
        }
    }

    public void EndRandomEvent()
    {
        eventManager.EndEvent(false,globalValue.randomEventNumber);
        //Debug.Log(globalValue.eventExecution);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpace;

public class RandomEventManager : MonoBehaviour
{
    public EventManager eventManager;
    public MousePosition MousePosition;
    public UserScriptManager userScriptManager;
    public MainTextController mainTextController;
    public RectTransform notClickObject;

    public List<TextAsset> readText;

    public int lastLine;//行の最後

    private bool first = true;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(globalValue.lineNumber);
        if (first)
        {
            //どこを押しても次のテキストに行けるようにする
            Debug.Log(globalValue.randomEventNumber);
            if (globalValue.randomEventNumber != 3)
            {
                MousePosition.UpDataRangeObject(globalValue.canvas);
            }
            else
            {
                MousePosition.UpDataRangeObject(notClickObject);
            }
            first = false;
        }
        if (globalValue.randomEventNumber == 3)
        {
            if(globalValue.lineNumber != 0)
            {
                MousePosition.UpDataRangeObject(globalValue.canvas);
            }
        }
        //最後の行から改行したら終了
        if (globalValue.lineNumber > lastLine - 1)
        {
            
            EndRandomEvent();
        }
        
    }

    public void EndRandomEvent()
    {
        mainTextController.first = true;
        first = true;
        eventManager.EndEvent(false,globalValue.randomEventNumber);
        //Debug.Log(globalValue.eventExecution);
    }

    public void ChangeReadText(int Number)
    {
        userScriptManager._sentences = new List<string>();
        userScriptManager._textFile = readText[Number];
    }
}

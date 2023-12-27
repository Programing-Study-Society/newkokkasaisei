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

    public int lastLine;//�s�̍Ō�

    private bool first = true;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(globalValue.lineNumber);
        if (first)
        {
            //�ǂ��������Ă����̃e�L�X�g�ɍs����悤�ɂ���
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
        //�Ō�̍s������s������I��
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

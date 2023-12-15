using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpace;

public class RandomEventManager : MonoBehaviour
{
    public EventManager eventManager;
    public MainTextController mainTextController;
    public MousePosition MousePosition;
    
    public int lastLine;//�s�̍Ō�

    // Update is called once per frame
    void Update()
    {

        //�ǂ��������Ă����̃e�L�X�g�ɍs����悤�ɂ���
        MousePosition.UpDataRangeObject();

        //�Ō�̍s������s������I��
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpace;

public class RandomEventManager : MonoBehaviour
{
    public SoundVolume soundVolume;
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
        if (first == true)
        {
            //�ǂ��������Ă����̃e�L�X�g�ɍs����悤�ɂ���
            //Debug.Log(globalValue.randomEventNumber);
            if (globalValue.randomEventNumber < 4)
            {
                MousePosition.UpDataRangeObject(globalValue.canvas);
            }
            else
            {
                MousePosition.UpDataRangeObject(notClickObject);
            }
            first = false;
        }
        if (globalValue.randomEventNumber >= 4)
        {
            if(globalValue.lineNumber != 0)
            {
                MousePosition.UpDataRangeObject(globalValue.canvas);
            }
        }
        if (globalValue.randomEventNumber == 2)
        {
            DisasterEventSound();
        }
        //�Ō�̍s������s������I��
        if (globalValue.lineNumber > lastLine - 1)
        {
            
            EndRandomEvent();
        }
        
    }

    public void DisasterEventSound()
    {
        if (globalValue.randomValue == 0)
        {
            if (globalValue.lineNumber == 1)
            {
                soundVolume.seVolume[8].Play();
            }
            else if (globalValue.lineNumber > lastLine - 1)
            {
                soundVolume.seVolume[8].Stop();
            }
        }
        else if (globalValue.randomValue == 1)
        {
            if (globalValue.lineNumber == 1)
            {
                soundVolume.seVolume[4].Play();
            }
            else if (globalValue.lineNumber > lastLine - 1)
            {
                soundVolume.seVolume[4].Stop();
            }
        }
        else if (globalValue.randomValue == 2)
        {
            if (globalValue.lineNumber == 1)
            {
                soundVolume.seVolume[5].Play();
            }
            else if (globalValue.lineNumber > lastLine - 1)
            {
                soundVolume.seVolume[5].Stop();
            }
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

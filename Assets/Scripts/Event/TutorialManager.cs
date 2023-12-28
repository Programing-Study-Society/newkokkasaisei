using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpace;

public class TutorialManager : MonoBehaviour
{
    public EventManager eventManager;
    public TutorialLimitRange TutorialLimitRange;
    public MainTextController mainTextController;
    public UserScriptManager userScriptManager;
    public GameObject mousePositionManager;
    public GameObject highlightObject;
    public SoundVolume soundVolume;
    //次に選択できる所
    public List<RectTransform> movingObjectList;
    
    MousePosition MousePosition;
    RectTransform highlightObjectRect;

    [HideInInspector] public int listMaxCount;

    private int oldLine = 0;

    bool first = true;

    // Start is called before the first frame update
    void Start()
    {
        
        TutorialLimitRange.buttonInteractable();

        listMaxCount = movingObjectList.Count;

        highlightObjectRect = highlightObject.GetComponent<RectTransform>();
        MousePosition = mousePositionManager.GetComponent<MousePosition>();
    }

    // Update is called once per frame
    void Update()
    {
        if (first)
        {
            mainTextController.DisplayText();
            TutorialRangeMovement();
            first = false;
        }
        //改行したら制限範囲移動
        if(oldLine != globalValue.lineNumber)
        {
            TutorialLimitRange.buttonInteractable();
            TutorialRangeMovement();
            oldLine = globalValue.lineNumber;
            if (globalValue.rootEventNumber == 0)
            {
                BuildingEventSound();
            }
        }

        //globalValue.lineNumber行の文字すべて表示したらボタンを押せる
        if (mainTextController.CanGoToTheNextLine())
        {
            TutorialLimitRange.buttonSelect(movingObjectList[globalValue.lineNumber]);
        }
    }

    public void BuildingEventSound()
    {
        if(globalValue.lineNumber == 2)
        {
            soundVolume.bgmVolume[0].Stop();
            soundVolume.seVolume[0].Play();
        }
        else if (globalValue.lineNumber == 3)
        {
            soundVolume.bgmVolume[1].Play();
        }
        else if (globalValue.lineNumber == 11)
        {
            soundVolume.bgmVolume[1].Stop();
            soundVolume.bgmVolume[0].Play();
        }
    }

    public void TutorialRangeMovement()
    {
        if (globalValue.lineNumber < listMaxCount)
        {
            //チュートリアル制限範囲移動
            MousePosition.UpDataRangeObject(movingObjectList[globalValue.lineNumber]);

            //ハイライト移動
            highlightObjectRect.position = movingObjectList[globalValue.lineNumber].position;
            highlightObjectRect.sizeDelta = movingObjectList[globalValue.lineNumber].sizeDelta;

            Vector2 highlightPosition = highlightObjectRect.position;
            highlightPosition.y += highlightObjectRect.sizeDelta.y;
            highlightObjectRect.position = highlightPosition;
            
            if (movingObjectList[globalValue.lineNumber] == globalValue.canvas)
            {
                highlightObject.SetActive(false);
            }
            else
            {
                highlightObject.SetActive(true);
            }

        }
        else
        {
            TutorialLimitRange.buttonTrue();
            eventManager.EndEvent(true,globalValue.rootEventNumber);
            //Debug.Log(globalValue.eventExecution);
        }
    }
}



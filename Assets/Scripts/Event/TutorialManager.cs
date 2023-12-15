using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpace;

public class TutorialManager : MonoBehaviour
{
    public EventManager eventManager;
    public TutorialLimitRange TutorialLimitRange;
    public MainTextController mainTextController;
    public GameObject mousePositionManager;
    public GameObject highlightObject;

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
            TutorialRangeMovement();
            first = false;
        }
        //改行したら制限範囲移動
        if(oldLine != globalValue.lineNumber)
        {
            TutorialLimitRange.buttonInteractable();
            TutorialRangeMovement();
            oldLine = globalValue.lineNumber;
        }

        //globalValue.lineNumber行の文字すべて表示したらボタンを押せる
        if (mainTextController.CanGoToTheNextLine())
        {
            TutorialLimitRange.buttonSelect(movingObjectList[globalValue.lineNumber]);
        }
    }

    public void TutorialRangeMovement()
    {
        if (globalValue.lineNumber < listMaxCount)
        {
            //チュートリアル制限範囲移動
            MousePosition.rangeObject = movingObjectList[globalValue.lineNumber];
            MousePosition.UpDataRangeObject();

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



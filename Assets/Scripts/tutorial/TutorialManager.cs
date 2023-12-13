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

    // Start is called before the first frame update
    void Start()
    {
        TutorialLimitRange.buttonInteractable();

        listMaxCount = movingObjectList.Count;

        highlightObjectRect = highlightObject.GetComponent<RectTransform>();
        MousePosition = mousePositionManager.GetComponent<MousePosition>();

        TutorialRangeMovement();

        if (movingObjectList[globalValue.lineNumber] == globalValue.canvas)
        {
            highlightObject.SetActive(false);
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TutorialRangeMovement()
    {
        if (globalValue.lineNumber < listMaxCount)
        {
            if (movingObjectList[globalValue.lineNumber] == globalValue.canvas)
            {
                highlightObject.SetActive(false);
            }
            else
            {
                highlightObject.SetActive(true);
            }

            //チュートリアル制限範囲移動
            MousePosition.rangeObject = movingObjectList[globalValue.lineNumber];
            MousePosition.UpDataRangeObject();

            //ハイライト移動
            highlightObjectRect.position = movingObjectList[globalValue.lineNumber].position;
            highlightObjectRect.sizeDelta = movingObjectList[globalValue.lineNumber].sizeDelta;

            Vector2 highlightPosition = highlightObjectRect.position;
            highlightPosition.y += highlightObjectRect.sizeDelta.y;
            highlightObjectRect.position = highlightPosition;

            TutorialLimitRange.buttonSelect();
        }
        else
        {
            TutorialLimitRange.buttonTrue();
            globalValue.lineNumber = 0;
            eventManager.EndEvent();
            //Debug.Log(globalValue.eventExecution);
        }
    }
}



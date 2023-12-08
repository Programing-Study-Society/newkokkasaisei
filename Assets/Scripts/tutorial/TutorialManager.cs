using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpace;

public class TutorialManager : MonoBehaviour
{
    public changeSetActive changeSetActive;
    public TutorialLimitRange TutorialLimitRange;
    public MainTextController mainTextController;
    public GameObject mousePositionManager;
    public GameObject highlightObject;

    //次に選択できる所
    public List<RectTransform> movingObjectList;

    MousePosition MousePosition;
    RectTransform highlightObjectRect;

    [HideInInspector] public int listMaxCount;
    [HideInInspector] public int movingObjectListPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        TutorialLimitRange.buttonInteractable();
        
        movingObjectListPoint = 0;

        listMaxCount = movingObjectList.Count;

        highlightObjectRect = highlightObject.GetComponent<RectTransform>();
        MousePosition = mousePositionManager.GetComponent<MousePosition>();

        TutorialRangeMovement();

        if (movingObjectList[movingObjectListPoint] == globalValue.canvas)
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
        if (movingObjectListPoint < listMaxCount)
        {
            if (movingObjectList[movingObjectListPoint] == globalValue.canvas)
            {
                highlightObject.SetActive(false);
            }
            else
            {
                highlightObject.SetActive(true);
            }

            //チュートリアル制限範囲移動
            MousePosition.rangeObject = movingObjectList[movingObjectListPoint];
            MousePosition.UpDataRangeObject();

            //ハイライト移動
            highlightObjectRect.position = movingObjectList[movingObjectListPoint].position;
            highlightObjectRect.sizeDelta = movingObjectList[movingObjectListPoint].sizeDelta;
            
            TutorialLimitRange.buttonSelect();
        }
        else
        {
            TutorialLimitRange.buttonTrue();
            globalValue.lineNumber = 0;
            globalValue.eventExecution = false;
            //Debug.Log(globalValue.eventExecution);
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MousePosition : MonoBehaviour
{
    public GameObject canvasObject;
    public TutorialLimitRange tutorialLimitRange;
    
    [HideInInspector] public RectTransform rangeObject;
    [HideInInspector] public float width;
    [HideInInspector] public float height;
    [HideInInspector] public float messageWidth;
    [HideInInspector] public float messageHeight;
    [HideInInspector] public bool messageMousePosition = false;
    [HideInInspector] public Vector2 messagePos;
    [HideInInspector] public Vector3 mousePosition;

    [HideInInspector] public RectTransform thisRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        globalValue.canvas = canvasObject.GetComponent<RectTransform>();
        rangeObject = canvasObject.GetComponent<RectTransform>();
        thisRectTransform = this.GetComponent<RectTransform>();

        messagePos = rangeObject.position;

        width = messagePos.x;
        height = messagePos.y;
        messageWidth = rangeObject.sizeDelta.x / 2;
        messageHeight = rangeObject.sizeDelta.y / 2;
        thisRectTransform.position = messagePos;
        thisRectTransform.sizeDelta = rangeObject.sizeDelta;
    }

    // Update is called once per frame
    void Update()
    {
        // カーソル位置を取得
        mousePosition = Input.mousePosition;

        if(width - messageWidth <= mousePosition.x && mousePosition.x <= width + messageWidth && height - messageHeight <= mousePosition.y && mousePosition.y <= height + messageHeight)
        {
            messageMousePosition = true;
        }
        else
        {
            messageMousePosition = false;
        }
        //Debug.Log(mousePosition);
        //Debug.Log(messageMousePosition);


    }

    public void UpDataRangeObject() {
        globalValue.canvas = canvasObject.GetComponent<RectTransform>();
        thisRectTransform = this.GetComponent<RectTransform>();

        Vector2 messagePos = rangeObject.position;

        width = messagePos.x;
        
        height = messagePos.y;
        
        messageWidth = rangeObject.sizeDelta.x / 2;
        messageHeight = rangeObject.sizeDelta.y / 2;
        
        thisRectTransform.position = messagePos;
        thisRectTransform.sizeDelta = rangeObject.sizeDelta;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLimitRange : MonoBehaviour
{
    public MousePosition mousePosition;

    public RectTransform upRectTransform;
    public RectTransform downRectTransform;
    public RectTransform lightRectTransform;
    public RectTransform leftRectTransform;

    float width;
    float height;
    
    Vector2 thisRectTransformPos;
    Vector2 thisRectTransformDelta;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void upImage()
    {
        upRectTransform.sizeDelta = globalValue.canvas.sizeDelta;
        thisRectTransformPos = upRectTransform.position;
        thisRectTransformDelta = upRectTransform.sizeDelta;

        height = mousePosition.messagePos.y + (mousePosition.height / 2);
        thisRectTransformDelta.y = (upRectTransform.sizeDelta.y / 2) - height;
        thisRectTransformPos.y = height + (thisRectTransformDelta.y / 2);
    }
    public void downImage()
    {
        downRectTransform.sizeDelta = globalValue.canvas.sizeDelta;
        thisRectTransformPos = downRectTransform.position;
        thisRectTransformDelta = upRectTransform.sizeDelta;

        height = mousePosition.messagePos.y - (mousePosition.height / 2);
        thisRectTransformDelta.y = (upRectTransform.sizeDelta.y / 2) + height;
        thisRectTransformPos.y = height - (thisRectTransformDelta.y / 2);
    }
    public void lightImage()
    {
        //lightRectTransform.sizeDelta = globalValue.canvas.sizeDelta;
        //thisRectTransformPos = lightRectTransform.position;

    }
    public void leftImage()
    {
        //leftRectTransform.sizeDelta = globalValue.canvas.sizeDelta;
        //thisRectTransformPos = leftRectTransform.position;
    }
    
}

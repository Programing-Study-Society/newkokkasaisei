using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuButton : MonoBehaviour
{
    
    public List<Slider> slider;

    public List<Text> valueText;

    // Start is called before the first frame update
    void Start()
    {
        slider[0].value = globalValue.sensitiveMove;
        slider[1].value = globalValue.sensitiveZoom;
        slider[2].value = globalValue.textSpeed;
    }

    public void MoveValue()
    {
        globalValue.sensitiveMove = slider[0].value;
        valueText[0].text = slider[0].value.ToString();
    }

    public void ZoomValue()
    {
        globalValue.sensitiveZoom = slider[1].value;
        valueText[1].text = slider[1].value.ToString();
    }

    public void textSpeedValue()
    {
        globalValue.textSpeed = slider[2].value;
        valueText[2].text = slider[2].value.ToString();
    }
}

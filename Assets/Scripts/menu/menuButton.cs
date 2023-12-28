using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuButton : MonoBehaviour
{
    
    public List<Slider> slider;

    public List<Text> valueText;

    public SoundVolume Volume;

    // Start is called before the first frame update
    void Start()
    {
        slider[0].value = globalValue.sensitiveMove;
        slider[1].value = globalValue.sensitiveZoom;
        slider[2].value = globalValue.textSpeed;
        slider[3].value = globalValue.bgmVolume;
        slider[4].value = globalValue.seVolume;
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

    public void BGMVolume()
    {
        globalValue.bgmVolume = slider[3].value;
        int volume = (int)(slider[3].value * 100);
        valueText[3].text = volume.ToString() + "%";
        Volume.BGMVolume();
    }

    public void SEVolume()
    {
        globalValue.seVolume = slider[4].value;
        int volume = (int)(slider[4].value * 100);
        valueText[4].text = volume.ToString() + "%";
        Volume.SEVolume();
    }

}

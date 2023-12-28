using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gage : MonoBehaviour
{
    Slider slider;
    float max;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = globalValue.complain;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = globalValue.complain;   
    }
}


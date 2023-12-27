using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderPlus : MonoBehaviour
{
    public int plusValue;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public void click()
    {
        globalValue.complain += plusValue;
        globalValue.money += (plusValue * 50000000);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gagetext : MonoBehaviour
{
    Text g_text;
    
    //Start is called before the first frame update
    void Start()
    {
        g_text = GetComponent<Text>();
    }

    //Update is called once per frame
    void Update()
    {
        if (globalValue.complain < globalValue.complainMax)
        {
            g_text.text = globalValue.complain.ToString() + "%";
        }
        else
        {
            g_text.text = "OVER";
        }

    }

}
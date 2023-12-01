using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using System;

public class hizuke : MonoBehaviour
{
    double dt = 0;

    public Text textUI;

    // Start is called before the first frame update
    void Start()
    {
        textUI.text = "日付: " + globalValue.yearNumber.ToString() + " 年目 " + globalValue.monthNumber.ToString() + " 月 " + globalValue.dayNumber.ToString() + " 日";
    }

    // Update is called once per frame
    void Update()
    {  
        Hizuke();
    }
        
   public void Hizuke()
   {
        dt += Time.deltaTime;
    
        if (dt > 0.5)
        {

            dt = 0.0f;
            globalValue.dayNumber += 1;
            
            if (globalValue.monthNumber == 0 || globalValue.monthNumber == 4 || globalValue.monthNumber == 6 || globalValue.monthNumber == 9 || globalValue.monthNumber == 11)
            {    
                if (globalValue.dayNumber == 31  )
                {
                    globalValue.monthNumber += 1;
                    globalValue.dayNumber = 1;
                }
            }

            else if (globalValue.monthNumber == 1 || globalValue.monthNumber == 3 || globalValue.monthNumber == 5 || globalValue.monthNumber == 7 || globalValue.monthNumber == 8 || globalValue.monthNumber == 10 || globalValue.monthNumber == 12)
            {
                if (globalValue.dayNumber == 32 )
                {
                    globalValue.monthNumber += 1;
                    globalValue.dayNumber = 1;
                }
            }

            else if(globalValue.monthNumber == 2 )
            {
                if (globalValue.dayNumber == 29)
                {
                    globalValue.monthNumber += 1;
                    globalValue.dayNumber = 1;
                }
            }

            else if (globalValue.monthNumber > 12)
            {
                globalValue.yearNumber += 1;
                globalValue.monthNumber = 1;
            }

         
            
            textUI.text = "日付: " + globalValue.yearNumber.ToString() + " 年目 " + globalValue.monthNumber.ToString() + " 月 " + globalValue.dayNumber.ToString() + " 日";
        }
   }
}
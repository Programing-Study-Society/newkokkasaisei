using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using System;

public class hizuke : MonoBehaviour
{
    int a = 0;
    int b = 0;
    int c = 0;
    double dt = 0;

    char d = '年';
    char e = '月';
    char f = '日';
    string s = "経過日数: ";
    public Text textUI;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {  
        Hizuke();
    }

   public void Hizuke()
    {
      dt += Time.deltaTime;
      dt *= 1.25;
      if (dt > 1)
      {
        dt = 0.0f;
        c += 1;
        
        if (b == 0 || b == 4 || b == 6 || b == 9 || b == 11)
        {    
          if (c == 31  )
          {
            b += 1;
            c =1;
          }
        }

        else if ( b == 1 || b == 3 || b == 5 || b == 7 || b == 8 || b == 10 || b == 12)
        {
          if (c == 32 )
          {
            b += 1;
            c =1;
          }
        }

        else if(b == 2 )
        {
          if (c == 29)
          {
            b += 1;
            c = 1;
          }
        }

        else if (b > 12)
        {
          a += 1;
          b = 1;
        }

         
        
        string g = Convert.ToString(a);
        string h = Convert.ToString(b);
        string i = Convert.ToString(c);
        textUI.text =s + g + d + h + e + i + f;
      }
    }
}
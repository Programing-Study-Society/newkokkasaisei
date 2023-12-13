using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class money : MonoBehaviour
{

    public Text text;

    const int Giga = 1000000000;
    // Start is called before the first frame update
    void Start()
    {
        Abbreviation();
    }

    // Update is called once per frame
    void Update()
    {
        Abbreviation(); 
    }

    public void Abbreviation()
    {
        if (globalValue.money >= Giga)
        {
            globalValue.gigaMoney  += globalValue.money / Giga;
            globalValue.money = globalValue.money % Giga;
        }
        
        if(globalValue.gigaMoney == 0)
        {
            text.text = "Åè" + globalValue.money.ToString();
        }
        else
        {
            ulong money = globalValue.money / (Giga / 10);
            text.text = "Åè" + globalValue.gigaMoney.ToString() + "." + money.ToString() + "M";
        }
    }
}

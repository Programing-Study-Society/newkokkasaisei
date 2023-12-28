using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class War : MonoBehaviour
{
    public WarEventManager warEventManager;
    public Slider werSlider;
    public GameObject warObject;
    public bool myCountryWin;

    int random;
    int advantage;
    float time = 0.0f;
    bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (first)
        {
            AdvantageFunction();
            werSlider.value = 50;
            first = false;
        }

        time += Time.deltaTime;
        if (time >= 0.5f)
        {
            time -= 0.5f;

            RandomFunction(100);
            if (random < 50 + advantage)
            {
                werSlider.value += 10;
            }
            else
            {
                werSlider.value -= 10;
            }
        }
        //100 or 0で終了
        if (werSlider.value == 100)
        {
            myCountryWin = true;
            warEventManager.warEventNumber = 3;
            warObject.SetActive(false);
        }
        else if (werSlider.value == 0)
        {
            myCountryWin = false;
            warEventManager.warEventNumber = 3;
            warObject.SetActive(false);
        }
    }

    //戦争での有利不利を求める関数
    public void AdvantageFunction()
    {
        int warCountryPower = globalValue.economicPower[globalValue.randomValue] + globalValue.militaryPower[globalValue.randomValue];
        advantage = globalValue.countryPower - warCountryPower;
        advantage = advantage / 10;
        //Debug.Log(advantage);
    }

    // ランダムな値(0 ～ randomValue の間)を取得する関数 ※randomValueは含まない
    public void RandomFunction(int randomValue)
    {
        random = Random.Range(0, randomValue);
        //Debug.Log(random);
    }
}   

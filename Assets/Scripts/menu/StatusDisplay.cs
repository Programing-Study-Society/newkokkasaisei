using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusDisplay : MonoBehaviour
{
    public Text statusText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ClickButtonRelationshipText();
    }
    //関係値を表示する関数
    public void ClickButtonRelationshipText()
    {
        statusText.text = "ステータス" + "\n" +
            "国力：" + globalValue.countryPower + "\n" +
            "経済力：" + globalValue.industryPower + "\n" +
            "軍事力：" + globalValue.armamentsPower + "\n" +
            "外交度：" + globalValue.diplomacyDegrees + "\n" +
            "人口：" + globalValue.population + "人" + "\n";
    }
}

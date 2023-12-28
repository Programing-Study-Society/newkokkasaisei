using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayRelationship : MonoBehaviour
{
    [Header("国")] public string country;
    [Header("友好度")] public float friendshipLevel;
    [Header("経済力")] public float economicPower;
    [Header("軍事力")] public float militaryPower;
    [Header("貿易品")] public string tradeGoods;
    [Header("貿易状況")] public string tradeSituation;

    private string country2;//国
    private float friendshipLevel2;//友好度
    private float economicPower2;//経済力
    private float militaryPower2;//軍事力
    private string tradeGoods2;//貿易品
    private string tradeSituation2;//貿易状況

    Text RelationshipText;

    // Start is called before the first frame update
    void Start()
    {
        RelationshipText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(country != country2)
        {
            country2 = country;
            ClickButtonRelationshipText();
        }
        else if(friendshipLevel != friendshipLevel2)
        {
            friendshipLevel2 = friendshipLevel;
            ClickButtonRelationshipText();
        }
        else if(economicPower != economicPower2)
        {
            economicPower2 = economicPower;
            ClickButtonRelationshipText();
        }
        else if (militaryPower != militaryPower2)
        {
            militaryPower2 = militaryPower;
            ClickButtonRelationshipText();
        }
        else if (tradeGoods != tradeGoods2)
        {
            tradeGoods2 = tradeGoods;
            ClickButtonRelationshipText();
        }
        else if(tradeSituation != tradeSituation2)
        {
            tradeSituation2 = tradeSituation;
            ClickButtonRelationshipText();
        }
    }

    //関係値を表示する関数
    public void ClickButtonRelationshipText()
    {
        float countryPower = economicPower + militaryPower;
        RelationshipText.text = "関係値" + "\n" +
            "国：" + country + "\n" +
            "友好度：" + friendshipLevel + "%" + "\n" +
            "国力：" + countryPower + "\n" +
            "経済力：" + economicPower + "\n" +
            "軍事力：" + militaryPower + "\n" +
            "貿易品：" + tradeGoods + "\n" +
            "貿易状況：" + tradeSituation;
    }
}

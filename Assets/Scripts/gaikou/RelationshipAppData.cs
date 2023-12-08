using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelationshipAppData : MonoBehaviour
{
    [Header("アメリカ関係値")] public GameObject america;
    [Header("日本関係値")] public GameObject japan;
    [Header("インド関係値")] public GameObject india;
    [Header("ドイツ関係値")] public GameObject germany;
    [Header("コンゴ関係値")] public GameObject kongo;
    [Header("関係値出力場所")] public GameObject outputRelationship;
    [Header("国")] public string country = "none";
    [Header("友好度")] public float friendshipLevel;
    [Header("経済力")] public float economicPower;
    [Header("軍事力")] public float militaryPower;
    [Header("貿易品")] public string tradeGoods;
    [Header("貿易状況")] public string tradeSituation;

    private GameObject upDataCountry;//更新する国

    RelationshipDisplay RelationshipDisplay;
    RelationShip Relationship;
    Text RelationshipText;

    // Start is called before the first frame update
    void Start()
    {
        RelationshipDisplay = outputRelationship.GetComponent<RelationshipDisplay>();
        RelationshipText = outputRelationship.GetComponent<Text>();
    }

    //関係値を表示するオブジェクトに表示している値を入力する関数
    public void ClickButtonRelationshipDisplay()
    {
        RelationshipDisplay.country = country;
        RelationshipDisplay.friendshipLevel = friendshipLevel;
        RelationshipDisplay.economicPower = economicPower;
        RelationshipDisplay.militaryPower = militaryPower;
        RelationshipDisplay.tradeGoods = tradeGoods;
        RelationshipDisplay.tradeSituation = tradeSituation;
    }

    //今表示している国は何か判別する関数
    public void Identification()
    {
        if (country == "アメリカ")
        {
            upDataCountry = america;
        }
        else if (country == "日本")
        {
            upDataCountry = japan;
        }
        else if (country == "インド")
        {
            upDataCountry = india;
        }
        else if (country == "ドイツ")
        {
            upDataCountry = germany;
        }
        else if (country == "コンゴ")
        {
            upDataCountry = kongo;
        }
        else
        {

        }
    }

    //国のオブジェクトの関係値をアップデートする関数
    public void RelationshipApp()
    {
        country = RelationshipDisplay.country;
        Identification();
        Relationship = upDataCountry.GetComponent<RelationShip>();
        Relationship.country = country;
        Relationship.friendshipLevel = friendshipLevel;
        Relationship.economicPower = economicPower;
        Relationship.militaryPower = militaryPower;
        Relationship.tradeGoods = tradeGoods;
        Relationship.tradeSituation = tradeSituation;
    }

    //貿易状況を変える関数
    public void ClickButtonTradeSituationAppData()
    {
        if(country == "none")
        {

        }
        else
        {
            if (friendshipLevel >= 80)
            {
                if (tradeSituation == "していない")
                {
                    tradeSituation = "貿易中";
                }
                else
                {
                    tradeSituation = "していない";
                }
                RelationshipApp();
                ClickButtonRelationshipDisplay();
            }
            
            
        }
    }
}

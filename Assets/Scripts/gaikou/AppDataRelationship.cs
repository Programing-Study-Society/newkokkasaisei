using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppDataRelationship : MonoBehaviour
{
    public WorldRelationShip worldRelationShip;//全ての国の国力と関係値のデータベース

    [Header("関係値出力場所")] public DisplayRelationship relationshipDisplay;

    [Header("国")] public string country = "none";
    [Header("友好度")] public float friendshipLevel;
    [Header("経済力")] public float economicPower;
    [Header("軍事力")] public float militaryPower;
    [Header("貿易品")] public string tradeGoods;
    [Header("貿易状況")] public string tradeSituation;

    private CountryRelationShip upDataCountry;//更新する国
    private int tradeSituationConditions = 50;//貿易条件（友好度）の値

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    //関係値を表示するオブジェクトに表示したい値を入力する関数
    public void ClickButtonRelationshipDisplay()
    {

        relationshipDisplay.country = country;
        relationshipDisplay.friendshipLevel = friendshipLevel;
        relationshipDisplay.economicPower = economicPower;
        relationshipDisplay.militaryPower = militaryPower;
        relationshipDisplay.tradeGoods = tradeGoods;
        relationshipDisplay.tradeSituation = tradeSituation;
    }

    //今表示している国は何か判別する関数
    public void Identification()
    {
        if (country == "アメリカ")
        {
            upDataCountry = worldRelationShip.america;
        }
        else if (country == "日本")
        {
            upDataCountry = worldRelationShip.japan;
        }
        else if (country == "インド")
        {
            upDataCountry = worldRelationShip.india;
        }
        else if (country == "ドイツ")
        {
            upDataCountry = worldRelationShip.germany;
        }
        else if (country == "コンゴ")
        {
            upDataCountry = worldRelationShip.kongo;
        }
        else
        {

        }
    }

    //国のオブジェクトの関係値をアップデートする関数
    public void RelationshipApp()
    {
        //upDataCountryの更新
        country = relationshipDisplay.country;
        Identification();

        //値の更新
        upDataCountry.country = country;
        upDataCountry.friendshipLevel = friendshipLevel;
        upDataCountry.economicPower = economicPower;
        upDataCountry.militaryPower = militaryPower;
        upDataCountry.tradeGoods = tradeGoods;
        upDataCountry.tradeSituation = tradeSituation;
    }

    //貿易状況を変える関数
    public void ClickButtonTradeSituationAppData()
    {
        if (country == "none")
        {

        }
        else
        {
            if (friendshipLevel >= tradeSituationConditions)//貿易条件以上なら true
            {
                if (tradeSituation == "していない")
                {
                    tradeSituation = "貿易中";
                }
                else
                {
                    tradeSituation = "していない";
                }

                //更新した値をオブジェクトに保存
                RelationshipApp();

                //表示オブジェクトを更新
                ClickButtonRelationshipDisplay();
            }


        }
    }

    //貿易で得られるお金の倍率を求める関数
    public void TradeMagnification()
    {
        double magnification = 0;
        globalValue.tradeSize = 0;
        for (int i = 0; i < worldRelationShip.worldCountry.Count; i++)
        {
            if (worldRelationShip.worldCountry[i].tradeSituation == "貿易中")
            {
                magnification += worldRelationShip.worldCountry[i].friendshipLevel - 50;
                globalValue.tradeSize++;
            }
        }
        magnification /= 10;
        magnification *= 0.5;
        globalValue.tradeSize += magnification;
        //Debug.Log(globalValue.tradeSize);
    }


}

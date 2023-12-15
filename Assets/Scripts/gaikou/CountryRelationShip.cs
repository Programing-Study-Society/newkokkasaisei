using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountryRelationShip: MonoBehaviour
{
    [Header("国")] public string country;
    [Header("友好度")] public float friendshipLevel;
    [Header("経済力")] public float economicPower;
    [Header("軍事力")] public float militaryPower;
    [Header("貿易品")] public string tradeGoods;
    [Header("貿易状況")] public string tradeSituation;
    [Header("関係値アップロード場所")] public AppDataRelationship relationshipAppData;

    //関係値のアップデートを行う関数
    public void ClickButtonRelationshipApp()
    {
        relationshipAppData.country = country;
        relationshipAppData.friendshipLevel = friendshipLevel;
        relationshipAppData.economicPower = economicPower;
        relationshipAppData.militaryPower = militaryPower;
        relationshipAppData.tradeGoods = tradeGoods;
        relationshipAppData.tradeSituation = tradeSituation;
    }

    //友好度が0%になったら貿易状況を戦争状態に移行
    public void warSituation()
    {
        if(friendshipLevel>= 0)
        {
            tradeSituation = "戦争中";
        }
    }
}

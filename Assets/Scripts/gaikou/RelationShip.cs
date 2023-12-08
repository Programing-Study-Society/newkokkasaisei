using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RelationShip: MonoBehaviour
{
    [Header("国")] public string country;
    [Header("友好度")] public float friendshipLevel;
    [Header("経済力")] public float economicPower;
    [Header("軍事力")] public float militaryPower;
    [Header("貿易品")] public string tradeGoods;
    [Header("貿易状況")] public string tradeSituation;
    [Header("関係値アップロード場所")] public GameObject relationshipApp;

    RelationshipAppData relationshipAppData;

    // Start is called before the first frame update
    void Start()
    {
        relationshipAppData = relationshipApp.GetComponent<RelationshipAppData>();
    }

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountryRelationShip: MonoBehaviour
{
    [Header("関係値アップロード場所")] public AppDataRelationship relationshipAppData;
    [Header("関係値保存番号")] public int SaveListNumber;

    // Start is called before the first frame update
    void Start()
    {
        warSituation();
    }

    //関係値のアップデートを行う関数
    public void ClickButtonRelationshipApp()
    {
        warSituation();
        relationshipAppData.country = globalValue.country[SaveListNumber];
        relationshipAppData.friendshipLevel = globalValue.friendshipLevel[SaveListNumber];
        relationshipAppData.economicPower = globalValue.economicPower[SaveListNumber];
        relationshipAppData.militaryPower = globalValue.militaryPower[SaveListNumber];
        relationshipAppData.tradeGoods = globalValue.tradeGoods[SaveListNumber];
        relationshipAppData.tradeSituation = globalValue.tradeSituation[SaveListNumber];
    }

    //友好度が0%になったら貿易状況を戦争状態に移行
    public void warSituation()
    {
        if (globalValue.friendshipLevel[SaveListNumber] <= 0)
        {
            globalValue.tradeSituation[SaveListNumber] = "戦争中";
        }
        else if (globalValue.friendshipLevel[SaveListNumber] < 50)
        {
            globalValue.tradeSituation[SaveListNumber] = "できません";
        }
        else if (globalValue.friendshipLevel[SaveListNumber] >= 50)
        {
            if (globalValue.tradeSituation[SaveListNumber] != "貿易中")
            {
                globalValue.tradeSituation[SaveListNumber] = "していない";
            }
        }
    }
}

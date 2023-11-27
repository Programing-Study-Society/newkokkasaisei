using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelationshipDisplay : MonoBehaviour
{
    [Header("‘")] public string country;
    [Header("—FD“x")] public float friendshipLevel;
    [Header("ŒoÏ—Í")] public float economicPower;
    [Header("ŒR–—Í")] public float militaryPower;
    [Header("–fˆÕ•i")] public string tradeGoods;
    [Header("–fˆÕó‹µ")] public string tradeSituation;

    private string country2;//‘
    private float friendshipLevel2;//—FD“x
    private float economicPower2;//ŒoÏ—Í
    private float militaryPower2;//ŒR–—Í
    private string tradeGoods2;//–fˆÕ•i
    private string tradeSituation2;//–fˆÕó‹µ

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

    //ŠÖŒW’l‚ğ•\¦‚·‚éŠÖ”
    public void ClickButtonRelationshipText()
    {

        RelationshipText.text = "ŠÖŒW’l" + "\n" +
            "‘F" + country + "\n" +
            "—FD“xF" + friendshipLevel + "%" + "\n" +
            "ŒoÏ—ÍF" + economicPower + "ˆÊ" + "\n" +
            "ŒR–—ÍF" + militaryPower + "ˆÊ" + "\n" +
            "–fˆÕ•iF" + tradeGoods + "\n" +
            "–fˆÕó‹µF" + tradeSituation;
    }
}

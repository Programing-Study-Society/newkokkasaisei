using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayRelationship : MonoBehaviour
{
    [Header("��")] public string country;
    [Header("�F�D�x")] public float friendshipLevel;
    [Header("�o�ϗ�")] public float economicPower;
    [Header("�R����")] public float militaryPower;
    [Header("�f�Օi")] public string tradeGoods;
    [Header("�f�Տ�")] public string tradeSituation;

    private string country2;//��
    private float friendshipLevel2;//�F�D�x
    private float economicPower2;//�o�ϗ�
    private float militaryPower2;//�R����
    private string tradeGoods2;//�f�Օi
    private string tradeSituation2;//�f�Տ�

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

    //�֌W�l��\������֐�
    public void ClickButtonRelationshipText()
    {
        float countryPower = economicPower + militaryPower;
        RelationshipText.text = "�֌W�l" + "\n" +
            "���F" + country + "\n" +
            "�F�D�x�F" + friendshipLevel + "%" + "\n" +
            "���́F" + countryPower + "\n" +
            "�o�ϗ́F" + economicPower + "\n" +
            "�R���́F" + militaryPower + "\n" +
            "�f�Օi�F" + tradeGoods + "\n" +
            "�f�Տ󋵁F" + tradeSituation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountryRelationShip: MonoBehaviour
{
    [Header("��")] public string country;
    [Header("�F�D�x")] public float friendshipLevel;
    [Header("�o�ϗ�")] public float economicPower;
    [Header("�R����")] public float militaryPower;
    [Header("�f�Օi")] public string tradeGoods;
    [Header("�f�Տ�")] public string tradeSituation;
    [Header("�֌W�l�A�b�v���[�h�ꏊ")] public AppDataRelationship relationshipAppData;

    //�֌W�l�̃A�b�v�f�[�g���s���֐�
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

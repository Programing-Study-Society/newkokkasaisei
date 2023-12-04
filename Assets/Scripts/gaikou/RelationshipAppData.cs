using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelationshipAppData : MonoBehaviour
{
    [Header("�A�����J�֌W�l")] public GameObject america;
    [Header("���{�֌W�l")] public GameObject japan;
    [Header("�C���h�֌W�l")] public GameObject india;
    [Header("�h�C�c�֌W�l")] public GameObject germany;
    [Header("�R���S�֌W�l")] public GameObject kongo;
    [Header("�֌W�l�o�͏ꏊ")] public GameObject outputRelationship;
    [Header("��")] public string country = "none";
    [Header("�F�D�x")] public float friendshipLevel;
    [Header("�o�ϗ�")] public float economicPower;
    [Header("�R����")] public float militaryPower;
    [Header("�f�Օi")] public string tradeGoods;
    [Header("�f�Տ�")] public string tradeSituation;

    private GameObject upDataCountry;//�X�V���鍑

    RelationshipDisplay RelationshipDisplay;
    RelationShip Relationship;
    Text RelationshipText;

    // Start is called before the first frame update
    void Start()
    {
        RelationshipDisplay = outputRelationship.GetComponent<RelationshipDisplay>();
        RelationshipText = outputRelationship.GetComponent<Text>();
    }

    //�֌W�l��\������I�u�W�F�N�g�ɕ\�����Ă���l����͂���֐�
    public void ClickButtonRelationshipDisplay()
    {
        RelationshipDisplay.country = country;
        RelationshipDisplay.friendshipLevel = friendshipLevel;
        RelationshipDisplay.economicPower = economicPower;
        RelationshipDisplay.militaryPower = militaryPower;
        RelationshipDisplay.tradeGoods = tradeGoods;
        RelationshipDisplay.tradeSituation = tradeSituation;
    }

    //���\�����Ă��鍑�͉������ʂ���֐�
    public void Identification()
    {
        if (country == "�A�����J")
        {
            upDataCountry = america;
        }
        else if (country == "���{")
        {
            upDataCountry = japan;
        }
        else if (country == "�C���h")
        {
            upDataCountry = india;
        }
        else if (country == "�h�C�c")
        {
            upDataCountry = germany;
        }
        else if (country == "�R���S")
        {
            upDataCountry = kongo;
        }
        else
        {

        }
    }

    //���̃I�u�W�F�N�g�̊֌W�l���A�b�v�f�[�g����֐�
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

    //�f�Տ󋵂�ς���֐�
    public void ClickButtonTradeSituationAppData()
    {
        if(country == "none")
        {

        }
        else
        {
            if (friendshipLevel >= 80)
            {
                if (tradeSituation == "���Ă��Ȃ�")
                {
                    tradeSituation = "�f�Ւ�";
                }
                else
                {
                    tradeSituation = "���Ă��Ȃ�";
                }
                RelationshipApp();
                ClickButtonRelationshipDisplay();
            }
            
            
        }
    }
}

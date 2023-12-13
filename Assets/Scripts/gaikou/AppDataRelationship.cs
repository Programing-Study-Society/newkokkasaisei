using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppDataRelationship : MonoBehaviour
{
    public WorldRelationShip worldRelationShip;//�S�Ă̍��̍��͂Ɗ֌W�l�̃f�[�^�x�[�X

    [Header("�֌W�l�o�͏ꏊ")] public DisplayRelationship relationshipDisplay;

    [Header("��")] public string country = "none";
    [Header("�F�D�x")] public float friendshipLevel;
    [Header("�o�ϗ�")] public float economicPower;
    [Header("�R����")] public float militaryPower;
    [Header("�f�Օi")] public string tradeGoods;
    [Header("�f�Տ�")] public string tradeSituation;

    private CountryRelationShip upDataCountry;//�X�V���鍑
    private int tradeSituationConditions = 50;//�f�Տ����i�F�D�x�j�̒l

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    //�֌W�l��\������I�u�W�F�N�g�ɕ\���������l����͂���֐�
    public void ClickButtonRelationshipDisplay()
    {

        relationshipDisplay.country = country;
        relationshipDisplay.friendshipLevel = friendshipLevel;
        relationshipDisplay.economicPower = economicPower;
        relationshipDisplay.militaryPower = militaryPower;
        relationshipDisplay.tradeGoods = tradeGoods;
        relationshipDisplay.tradeSituation = tradeSituation;
    }

    //���\�����Ă��鍑�͉������ʂ���֐�
    public void Identification()
    {
        if (country == "�A�����J")
        {
            upDataCountry = worldRelationShip.america;
        }
        else if (country == "���{")
        {
            upDataCountry = worldRelationShip.japan;
        }
        else if (country == "�C���h")
        {
            upDataCountry = worldRelationShip.india;
        }
        else if (country == "�h�C�c")
        {
            upDataCountry = worldRelationShip.germany;
        }
        else if (country == "�R���S")
        {
            upDataCountry = worldRelationShip.kongo;
        }
        else
        {

        }
    }

    //���̃I�u�W�F�N�g�̊֌W�l���A�b�v�f�[�g����֐�
    public void RelationshipApp()
    {
        //upDataCountry�̍X�V
        country = relationshipDisplay.country;
        Identification();

        //�l�̍X�V
        upDataCountry.country = country;
        upDataCountry.friendshipLevel = friendshipLevel;
        upDataCountry.economicPower = economicPower;
        upDataCountry.militaryPower = militaryPower;
        upDataCountry.tradeGoods = tradeGoods;
        upDataCountry.tradeSituation = tradeSituation;
    }

    //�f�Տ󋵂�ς���֐�
    public void ClickButtonTradeSituationAppData()
    {
        if (country == "none")
        {

        }
        else
        {
            if (friendshipLevel >= tradeSituationConditions)//�f�Տ����ȏ�Ȃ� true
            {
                if (tradeSituation == "���Ă��Ȃ�")
                {
                    tradeSituation = "�f�Ւ�";
                }
                else
                {
                    tradeSituation = "���Ă��Ȃ�";
                }

                //�X�V�����l���I�u�W�F�N�g�ɕۑ�
                RelationshipApp();

                //�\���I�u�W�F�N�g���X�V
                ClickButtonRelationshipDisplay();
            }


        }
    }

    //�f�Ղœ����邨���̔{�������߂�֐�
    public void TradeMagnification()
    {
        double magnification = 0;
        globalValue.tradeSize = 0;
        for (int i = 0; i < worldRelationShip.worldCountry.Count; i++)
        {
            if (worldRelationShip.worldCountry[i].tradeSituation == "�f�Ւ�")
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

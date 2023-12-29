using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppDataRelationship : MonoBehaviour
{
    [Header("�֌W�l�o�͏ꏊ")] public DisplayRelationship relationshipDisplay;

    [Header("��")] public string country = "none";
    [Header("�F�D�x")] public int friendshipLevel;
    [Header("�o�ϗ�")] public int economicPower;
    [Header("�R����")] public int militaryPower;
    [Header("�f�Օi")] public string tradeGoods;
    [Header("�f�Տ�")] public string tradeSituation;

    private int upDataCountryNumber;//�X�V���鍑
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
            upDataCountryNumber = 0;
        }
        else if (country == "���{")
        {
            upDataCountryNumber = 1;
        }
        else if (country == "�C���h")
        {
            upDataCountryNumber = 2;
        }
        else if (country == "�h�C�c")
        {
            upDataCountryNumber = 3;
        }
        else if (country == "�R���S")
        {
            upDataCountryNumber = 4;
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
        globalValue.country[upDataCountryNumber] = country;
        globalValue.friendshipLevel[upDataCountryNumber] = friendshipLevel;
        globalValue.economicPower[upDataCountryNumber] = economicPower;
        globalValue.militaryPower[upDataCountryNumber] = militaryPower;
        globalValue.tradeGoods[upDataCountryNumber] = tradeGoods;
        globalValue.tradeSituation[upDataCountryNumber] = tradeSituation;
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
                else if(tradeSituation == "�f�Ւ�")
                {
                    tradeSituation = "���Ă��Ȃ�";
                }
                else
                {

                }
            }
            else
            {
                tradeSituation = "�ł��܂���";
            }

            //�X�V�����l���I�u�W�F�N�g�ɕۑ�
            RelationshipApp();

            //�\���I�u�W�F�N�g���X�V
            ClickButtonRelationshipDisplay();

        }
    }

    //�f�Ղœ����邨���̔{�������߂�֐�
    public void TradeMagnification()
    {
        double magnification = 0;
        globalValue.tradeSize = 0;
        for (int i = 0; i < globalValue.tradeSituation.Count; i++)
        {
            if (globalValue.tradeSituation[i] == "�f�Ւ�")
            {
                magnification += globalValue.friendshipLevel[i] - 50;
                globalValue.tradeSize++;
            }
        }
        magnification /= 10;
        magnification *= 0.5;
        globalValue.tradeSize += magnification;
        //Debug.Log(globalValue.tradeSize);
    }

}

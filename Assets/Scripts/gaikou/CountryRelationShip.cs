using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountryRelationShip: MonoBehaviour
{
    [Header("�֌W�l�A�b�v���[�h�ꏊ")] public AppDataRelationship relationshipAppData;
    [Header("�֌W�l�ۑ��ԍ�")] public int SaveListNumber;

    // Start is called before the first frame update
    void Start()
    {
        warSituation();
    }

    //�֌W�l�̃A�b�v�f�[�g���s���֐�
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

    //�F�D�x��0%�ɂȂ�����f�Տ󋵂�푈��ԂɈڍs
    public void warSituation()
    {
        if (globalValue.friendshipLevel[SaveListNumber] <= 0)
        {
            globalValue.tradeSituation[SaveListNumber] = "�푈��";
        }
        else if (globalValue.friendshipLevel[SaveListNumber] < 50)
        {
            globalValue.tradeSituation[SaveListNumber] = "�ł��܂���";
        }
        else if (globalValue.friendshipLevel[SaveListNumber] >= 50)
        {
            if (globalValue.tradeSituation[SaveListNumber] != "�f�Ւ�")
            {
                globalValue.tradeSituation[SaveListNumber] = "���Ă��Ȃ�";
            }
        }
    }
}

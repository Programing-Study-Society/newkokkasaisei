using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusDisplay : MonoBehaviour
{
    public Text statusText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ClickButtonRelationshipText();
    }
    //�֌W�l��\������֐�
    public void ClickButtonRelationshipText()
    {
        statusText.text = "�X�e�[�^�X" + "\n" +
            "���́F" + globalValue.countryPower + "\n" +
            "�o�ϗ́F" + globalValue.industryPower + "\n" +
            "�R���́F" + globalValue.armamentsPower + "\n" +
            "�O��x�F" + globalValue.diplomacyDegrees + "\n" +
            "�l���F" + globalValue.population + "�l" + "\n";
    }
}

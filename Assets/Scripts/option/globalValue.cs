using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class globalValue
{
    //�`���[�g���A���f�[�^
    public  static int lineNumber = 0;
    public static int rootEventNumber = 0;//�ǉ��@�ϐ��F�C�x���g�̐i��
    public static int randomEventNumber = 0;//�ǉ��@�ϐ��F�i�s���Ă��郉���_���C�x���g�̔ԍ�
    public static bool eventExecution = false;
    //�폜�@public static bool first = true;
    public static RectTransform canvas;
    public static int randomValue = 0;

    //�l��
    public static int population = 500;// �ǉ��@ulong --> int

    //�������f�[�^
    public static int money = 0;
    public static int gigaMoney = 30;
    public static double tradeSize = 0.0;�@//�ǉ��@�ϐ��F�f�ՂŒǉ����邨���̔{��

    //�����s���Q�[�W�f�[�^
    public static float complain = 50.0f;
    public static float complainMax = 100.0f;
    
    //�N�����f�[�^
    public static int yearNumber = 1;
    public static int monthNumber = 1;
    public static int dayNumber = 1;

    //�R����
    public static int armamentsPower = 0;

    //�H�Ɨ�
    public static int industryPower = 0;

    //�O��x
    public static int diplomacyDegrees = 0;

    //����
    public static int countryPower = 0;

    //�e�L�X�g���x
    public static float textSpeed = 0.05f;

    //�J�������x
    public static float sensitiveMove = 0.4f;
    public static float sensitiveZoom = 5.0f;

    //���S�Ēǉ�
    //�O���V�[��
    //��
    public static List<string> country = new List<string> { "�A�����J", "���{", "�C���h", "�h�C�c", "�R���S" };
    //�F�D�x
    public static List<int> friendshipLevel = new List<int> { 60, 30, 30, 30, 30 };
    //�o�ϗ�
    public static List<int> economicPower = new List<int> { 400, 300, 200, 100, 100 };
    //�R����
    public static List<int> militaryPower = new List<int> { 400, 300, 100, 400, 100 };
    //�f�Օi
    public static List<string> tradeGoods = new List<string> { "�@�B��", "��", "�H���i", "�C�N��", "�Ζ�" };
    //�f�Տ�
    public static List<string> tradeSituation = new List<string> { "���Ă��Ȃ�", "���Ă��Ȃ�", "���Ă��Ȃ�", "���Ă��Ȃ�", "���Ă��Ȃ�" };

}

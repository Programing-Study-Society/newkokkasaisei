using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class globalValue
{
    //�`���[�g���A���f�[�^
    public  static int lineNumber = 0;
    public static int eventNumber = 0;//�ǉ��@�ϐ��F�C�x���g�̔ԍ�
    public static bool eventExecution = false;
    public static bool first = true;
    public static RectTransform canvas;

    //�l��
    public static ulong population = 0;

    //�������f�[�^
    public static ulong money = 0;// �ǉ��@int --> ulong
    public static ulong gigaMoney = 0;// �ǉ��@int --> ulong
    public static double tradeSize = 0.0;�@//�ǉ��@�ϐ��F�f�ՂŒǉ����邨���̔{��

    //�����s���Q�[�W�f�[�^
    public static float complain = 0.0f;
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
}

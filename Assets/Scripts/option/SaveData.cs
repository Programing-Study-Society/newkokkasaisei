using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectData
{
    public List<int> originalID = new List<int>();
    public List<int> objID = new List<int>();
    public List<Vector3> pos = new List<Vector3>();
}

[System.Serializable]
public class SaveData
{
    //�`���[�g���A���f�[�^
    public int rootEventNumber = 0;//�ǉ��@�ϐ��F�C�x���g�̐i��
    
    //�l��
    public int population = 0;
    
    //�������f�[�^
    public int money = 0;// �ǉ��@int --> ulong
    public int gigaMoney = 0;// �ǉ��@int --> ulong
    public double tradeSize = 0.0;�@//�ǉ��@�ϐ��F�f�ՂŒǉ����邨���̔{��
    
    //�����s���Q�[�W�f�[�^
    public float complain = 0.0f;
    
    //�N�����f�[�^
    public int yearNumber = 1;
    public int monthNumber = 1;
    public int dayNumber = 1;
    
    //�R����
    public int armamentsPower = 0;

    //�H�Ɨ�
    public int industryPower = 0;

    //�O��x
    public int diplomacyDegrees = 0;

    //����
    public int countryPower = 0;

    //�e�L�X�g���x
    public float textSpeed = 0.05f;

    //�J�������x
    public float sensitiveMove = 0.4f;
    public float sensitiveZoom = 5.0f;

    //����
    public float bgmVolume = 0.2f;
    public float seVolume = 0.2f;

    //�F�D�x
    public List<int> friendshipLevel = new List<int> { 0, 0, 0, 0, 0 };

    //�f�Տ�
    public List<string> tradeSituation = new List<string> { "���Ă��Ȃ�", "���Ă��Ȃ�", "���Ă��Ȃ�", "���Ă��Ȃ�", "���Ă��Ȃ�" };

    // ���z���̎�ނ���W�f�[�^
    public ObjectData objectData = new ObjectData();
}

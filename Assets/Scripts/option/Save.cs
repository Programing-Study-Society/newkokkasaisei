using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    [HideInInspector] public SaveData data;     // json�ϊ�����f�[�^�̃N���X
    string filePath;                            // json�t�@�C���̃p�X
    string fileName = "SaveData.json";              // json�t�@�C����
    string metaFileName = "SaveData.json.meta";
    int countryNumber = 5;//���̐�

    
    // json�Ƃ��ăf�[�^��ۑ�
    void jsonSave(SaveData data)
    {
        InSaveData();
        string json = JsonUtility.ToJson(data);                 // json�Ƃ��ĕϊ�
        StreamWriter wr = new StreamWriter(filePath, false);    // �t�@�C���������ݎw��
        wr.Write(json);                                     // json�ϊ�����������������
        wr.Flush();
        wr.Close();                                             // �t�@�C������
    }

    // json�t�@�C���ǂݍ���
    SaveData Load(string path)
    {
        StreamReader rd = new StreamReader(path);               // �t�@�C���ǂݍ��ݎw��
        string json = rd.ReadToEnd();                           // �t�@�C�����e�S�ēǂݍ���
        rd.Close();                                             // �t�@�C������

        return JsonUtility.FromJson<SaveData>(json);            // json�t�@�C�����^�ɖ߂��ĕԂ�
    }

    //�X�^�[�g����Json�t�@�C���ɂ���l���o���Ă���
    void Awake()
    {
        // �p�X���擾
        filePath = Application.dataPath + "/" + fileName;
        //Debug.Log(filePath);
        // �t�@�C�����Ȃ��Ƃ��A�t�@�C���쐬
        if (!File.Exists(filePath))
        {
            jsonSave(data);
        }

        // �t�@�C����ǂݍ���� data �Ɋi�[
        data = Load(filePath);

        //�i�[�����l��GlobalValue�Ɋi�[
        InGlobalValue();
    }

    //�Z�[�u
    public void ClickSave()
    {
        // �Q�[���I�����ɕۑ�
        jsonSave(data);
    }

    //�Z�[�u���폜���čŏ�����n�߂�
    public void ClickReStart()
    {
        JsonFileDelete();
        endGame();
    }

    //�Q�[���I��
    public void endGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
        Application.Quit();//�Q�[���v���C�I��
#endif
    }

    //Json�t�@�C�����폜
    void JsonFileDelete()
    {
        filePath = Application.dataPath + "/" + fileName;
        
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        filePath = Application.dataPath + "/" + metaFileName;

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        //�V�[��������
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    //public static �ϐ��Ŏw�肵������SaveData�ɕۑ�
    public void InSaveData()
    {
        
        data.rootEventNumber = globalValue.rootEventNumber;
        data.population = globalValue.population;
        data.money = globalValue.money;
        data.gigaMoney = globalValue.gigaMoney;
        data.tradeSize = globalValue.tradeSize;
        data.complain = globalValue.complain;
        data.yearNumber = globalValue.yearNumber;
        data.monthNumber = globalValue.monthNumber;
        data.dayNumber = globalValue.dayNumber;
        data.armamentsPower = globalValue.armamentsPower;
        data.industryPower = globalValue.industryPower;
        data.diplomacyDegrees = globalValue.diplomacyDegrees;
        data.countryPower = globalValue.countryPower;
        data.textSpeed = globalValue.textSpeed;
        data.sensitiveMove = globalValue.sensitiveMove;
        data.sensitiveZoom = globalValue.sensitiveZoom;
        data.objectData = globalValue.objectData;
        data.bgmVolume = globalValue.bgmVolume;
        data.seVolume = globalValue.seVolume;

        for (int i = 0; i< countryNumber;i++)
        {

            data.friendshipLevel[i] = globalValue.friendshipLevel[i];
            
            data.tradeSituation[i] = globalValue.tradeSituation[i];

        }
        
    }

    //SaveData�̒l��GlobalValue�ɕۑ�
    public void InGlobalValue()
    {

        globalValue.rootEventNumber = data.rootEventNumber;
        globalValue.population = data.population;
        globalValue.money = data.money;
        globalValue.gigaMoney = data.gigaMoney;
        globalValue.tradeSize = data.tradeSize;
        globalValue.complain = data.complain;
        globalValue.yearNumber = data.yearNumber;
        globalValue.monthNumber = data.monthNumber;
        globalValue.dayNumber = data.dayNumber;
        globalValue.armamentsPower = data.armamentsPower;
        globalValue.industryPower = data.industryPower;
        globalValue.diplomacyDegrees = data.diplomacyDegrees;
        globalValue.countryPower = data.countryPower;
        globalValue.textSpeed = data.textSpeed;
        globalValue.sensitiveMove = data.sensitiveMove;
        globalValue.sensitiveZoom = data.sensitiveZoom;
        globalValue.objectData = data.objectData;
        globalValue.bgmVolume = data.bgmVolume;
        globalValue.seVolume = data.seVolume;

        for (int i = 0; i < countryNumber; i++)
        {

            globalValue.friendshipLevel[i] = data.friendshipLevel[i];

            globalValue.tradeSituation[i] = data.tradeSituation[i];

        }

    }
}

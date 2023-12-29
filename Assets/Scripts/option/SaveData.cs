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
    //チュートリアルデータ
    public int rootEventNumber = 0;//追加　変数：イベントの進捗
    
    //人口
    public int population = 0;
    
    //所持金データ
    public int money = 0;// 追加　int --> ulong
    public int gigaMoney = 0;// 追加　int --> ulong
    public double tradeSize = 0.0;　//追加　変数：貿易で追加するお金の倍率
    
    //国民不満ゲージデータ
    public float complain = 0.0f;
    
    //年月日データ
    public int yearNumber = 1;
    public int monthNumber = 1;
    public int dayNumber = 1;
    
    //軍備力
    public int armamentsPower = 0;

    //工業力
    public int industryPower = 0;

    //外交度
    public int diplomacyDegrees = 0;

    //国力
    public int countryPower = 0;

    //テキスト速度
    public float textSpeed = 0.05f;

    //カメラ速度
    public float sensitiveMove = 0.4f;
    public float sensitiveZoom = 5.0f;

    //音声
    public float bgmVolume = 0.2f;
    public float seVolume = 0.2f;

    //友好度
    public List<int> friendshipLevel = new List<int> { 0, 0, 0, 0, 0 };

    //貿易状況
    public List<string> tradeSituation = new List<string> { "していない", "していない", "していない", "していない", "していない" };

    // 建築物の種類や座標データ
    public ObjectData objectData = new ObjectData();
}

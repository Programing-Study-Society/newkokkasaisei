using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    [HideInInspector] public SaveData data;     // json変換するデータのクラス
    string filePath;                            // jsonファイルのパス
    string fileName = "SaveData.json";              // jsonファイル名
    string metaFileName = "SaveData.json.meta";
    int countryNumber = 5;//国の数

    
    // jsonとしてデータを保存
    void jsonSave(SaveData data)
    {
        InSaveData();
        string json = JsonUtility.ToJson(data);                 // jsonとして変換
        StreamWriter wr = new StreamWriter(filePath, false);    // ファイル書き込み指定
        wr.Write(json);                                     // json変換した情報を書き込み
        wr.Flush();
        wr.Close();                                             // ファイル閉じる
    }

    // jsonファイル読み込み
    SaveData Load(string path)
    {
        StreamReader rd = new StreamReader(path);               // ファイル読み込み指定
        string json = rd.ReadToEnd();                           // ファイル内容全て読み込む
        rd.Close();                                             // ファイル閉じる

        return JsonUtility.FromJson<SaveData>(json);            // jsonファイルを型に戻して返す
    }

    //スタート時にJsonファイルにある値を出してくる
    void Awake()
    {
        // パス名取得
        filePath = Application.dataPath + "/" + fileName;
        //Debug.Log(filePath);
        // ファイルがないとき、ファイル作成
        if (!File.Exists(filePath))
        {
            jsonSave(data);
        }

        // ファイルを読み込んで data に格納
        data = Load(filePath);

        //格納した値をGlobalValueに格納
        InGlobalValue();
    }

    //セーブ
    public void ClickSave()
    {
        // ゲーム終了時に保存
        jsonSave(data);
    }

    //セーブを削除して最初から始める
    public void ClickReStart()
    {
        JsonFileDelete();
        endGame();
    }

    //ゲーム終了
    public void endGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
        Application.Quit();//ゲームプレイ終了
#endif
    }

    //Jsonファイルを削除
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
        //シーン初期化
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    //public static 変数で指定した物をSaveDataに保存
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
        data.diplomacyDegrees = globalValue.diplomacyDegrees;
        data.countryPower = globalValue.countryPower;
        data.textSpeed = globalValue.textSpeed;
        data.sensitiveMove = globalValue.sensitiveMove;
        data.sensitiveZoom = globalValue.sensitiveZoom;
        data.objectData = globalValue.objectData;
        
        for (int i = 0; i< countryNumber;i++)
        {

            data.friendshipLevel[i] = globalValue.friendshipLevel[i];
            
            data.tradeSituation[i] = globalValue.tradeSituation[i];

        }
        
    }

    //SaveDataの値をGlobalValueに保存
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
        globalValue.diplomacyDegrees = data.diplomacyDegrees;
        globalValue.countryPower = data.countryPower;
        globalValue.textSpeed = data.textSpeed;
        globalValue.sensitiveMove = data.sensitiveMove;
        globalValue.sensitiveZoom = data.sensitiveZoom;
        globalValue.objectData = data.objectData;

        for (int i = 0; i < countryNumber; i++)
        {

            globalValue.friendshipLevel[i] = data.friendshipLevel[i];

            globalValue.tradeSituation[i] = data.tradeSituation[i];

        }

    }
}

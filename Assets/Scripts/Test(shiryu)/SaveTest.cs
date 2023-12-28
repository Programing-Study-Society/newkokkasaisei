using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Collections.Generic;

[Serializable]
public class ObjectData
{
    public List<int> originalID;
    public List<int> objID;
    public List<Vector3> pos;

    public ObjectData()
    {
        this.originalID = new List<int>();
        this.objID = new List<int>();
        this.pos = new List<Vector3>();
    }
}

public class SaveTest : MonoBehaviour
{
    // テスト用 削除予定
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            ObjectSave(globalValue.objectData, "Data.json");
        }
    }
    // public GameObject obj;
    // public GameObject obj2;
    // void Start()
    // {
    //     string fileName = "Data.json";
    //     string filepath = Application.dataPath + "/" + fileName;
    //     ObjectData data = new ObjectData();

    //     data.vec.Add(obj.transform.position);
    //     data.vec.Add(obj2.transform.position);
    //     ObjectSave(data, filepath);
    // }

    // jsonとしてデータを保存
    void ObjectSave(ObjectData data, string filepath)
    {
        Debug.Log("Save");

        string json = JsonUtility.ToJson(data); // jsonとして変換
        StreamWriter wr = new StreamWriter(filepath, false); // ファイル書き込み指定
        wr.WriteLine(json); // json変換した情報を書き込み
        wr.Close(); // ファイル閉じる
        // // ゲームを終了する
        // #if UNITY_EDITOR
        //     UnityEditor.EditorApplication.isPlaying = false;
        // #else
        //     Application.Quit();
        // #endif
    }
}

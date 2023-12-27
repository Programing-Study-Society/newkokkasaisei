using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

[Serializable]
public class SaveData
{
    public int[] ObjID;
    public Vector3[] vec;

    public SaveData(int size)
    {
        this.ObjID = new int[size];
        this.vec = new Vector3[size];
    }
}

public class SaveTest : MonoBehaviour
{
    public GameObject obj;
    public GameObject obj2;
    void Start()
    {
        string fileName = "Data.json";
        string filepath = Application.dataPath + "/" + fileName;
        SaveData data = new SaveData(2);

        data.vec[0] = obj.transform.position;
        data.vec[1] = obj2.transform.position;
        ObjectSave(data, filepath);
    }

    // jsonとしてデータを保存
    void ObjectSave(SaveData data, string filepath)
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

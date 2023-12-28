using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBuilding : MonoBehaviour
{
    public GameObject[] buildings;
    void Start()
    {
        // リストの長さを取得
        int len = globalValue.objectData.originalID.Count;
        for(int i = 0; i < len; i++)
        {
            // 各建築物を設置し、originalIDを再取得する
            GameObject targetPrefab = buildings[globalValue.objectData.objID[i]];
            GameObject gameObject = (GameObject)Instantiate(targetPrefab, globalValue.objectData.pos[i], targetPrefab.transform.rotation);
            globalValue.objectData.originalID[i] = gameObject.GetInstanceID();
        }
    }
}

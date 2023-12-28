using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : BuildingParent
{
    [SerializeField] float maxDistance = 100.0f; // 無限にする場合は Mathf.Infinity
    int layerMask;
    
    void Start()
    {
        layerMask = 1 << LayerMask.NameToLayer("Mesh");
    }

    void Update()
    {
        // マウスの位置を取得
        Vector3 mousePos = Input.mousePosition;

        // マウス位置をRayに変換    
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Input.GetMouseButtonDown(1))  // マウスの左ボタンがクリックされたら
        {
            // Rayがタイルマップ上にヒットしたら
            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask))
            {
                Debug.Log(hit);
                // ヒットしたオブジェクトを取得し、スクリプトを取得
                GameObject delObject = hit.collider.gameObject.transform.parent.gameObject;
                BuildingInfo buildingInfo = delObject.GetComponent<BuildingInfo>();
                // 各ステータスの調整
                globalValue.population -= buildingInfo.population; // 人口の増減
                // globalValue.money += buildingInfo.cost; // 所持金増減(削除時は変動なし)
                globalValue.armamentsPower -= buildingInfo.armamentsPower; // 軍備力の増減
                globalValue.industryPower -= buildingInfo.industryPower; // 工業力の増減
                // 建築物と座標データをリストから削除し、オブジェクトを破壊
                int index = globalValue.objectData.originalID.IndexOf(delObject.GetInstanceID());
                if(index >= 0) // 対象のオブジェクトがリスト内に存在するなら
                {
                    // リストから削除
                    globalValue.objectData.originalID.RemoveAt(index);
                    globalValue.objectData.objID.RemoveAt(index);
                    globalValue.objectData.pos.RemoveAt(index);
                    // オブジェクトを破壊(削除)
                    Destroy(delObject);
                }
                else
                {
                    Debug.Log(delObject.name);
                    Debug.Log(delObject.GetInstanceID());
                    Debug.Log("エラー：選択したオブジェクトがリスト内に存在しませんでした\nInstanceIDの変更が反映されていない可能性があります");
                }
            }
        }
    }
}

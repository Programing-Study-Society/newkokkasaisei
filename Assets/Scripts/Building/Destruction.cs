using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : BuildingParent
{
    [SerializeField] float maxDistance = 100.0f; // 無限にする場合は Mathf.Infinity
    int layerMask;
    
    void Start()
    {
        layerMask = 1 << LayerMask.NameToLayer("Architecture");
    }

    void Update()
    {
        // マウスの位置を取得
        Vector3 mousePos = Input.mousePosition;

        // マウス位置をRayに変換    
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Input.GetMouseButtonDown(0))  // マウスの左ボタンがクリックされたら
        {
            // Rayがタイルマップ上にヒットしたら
            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask))
            {
                Destroy(hit.collider.gameObject.transform.parent.gameObject);
                Debug.Log(hit);
            }
        }
    }
}

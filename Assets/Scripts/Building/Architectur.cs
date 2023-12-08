using UnityEngine;
using UnityEngine.Tilemaps;

public class Architecture : MonoBehaviour
{
    private GameObject targetPrefab;
    private Tilemap tilemap;  // Tilemapの参照
    private GameObject originalObj;
    float maxDistance = 100.0f; // 無限にする場合は Mathf.Infinity
    int layerMask;
    bool isActive;

    public void SetAll(Tilemap tilemap, GameObject targetPrefab)
    {
        this.layerMask = 1 << LayerMask.NameToLayer("Ground");
        this.targetPrefab = targetPrefab;
        this.originalObj = (GameObject)Instantiate(targetPrefab, targetPrefab.transform.position, targetPrefab.transform.rotation);
        this.tilemap = tilemap;
        this.isActive = true;
        Debug.Log("初期化");
    }

    public void Run(GameObject targetPrefab)
    {
        this.targetPrefab = targetPrefab;
        this.originalObj = (GameObject)Instantiate(targetPrefab, targetPrefab.transform.position, targetPrefab.transform.rotation);
        this.isActive = true;
        forUpdate(); // マウスの位置にオブジェクトを移動
    }

    public void Stop()
    {
        this.isActive = false;
        Destroy(this.originalObj);
    }

    public void forUpdate()
    {
        if(isActive)
        {
            // マウスの位置を取得
            Vector3 mousePos = Input.mousePosition;

            // マウス位置をRayに変換    
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            // Rayがタイルマップ上にヒットしたら
            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask))
            {
                // タイルマップ上のセル位置をワールド座標に変換
                Vector3Int cellPosition = tilemap.WorldToCell(hit.point);
                Vector3 cellCenterWorldPos = tilemap.GetCellCenterWorld(cellPosition);
                cellCenterWorldPos += targetPrefab.transform.position; // 建物ごとの誤差を埋める(prefabの座標を取ってくる)

                if (Input.GetMouseButtonDown(1))  // マウスの右ボタンがクリックされたら
                {
                    // オブジェクトを設置
                    Instantiate(targetPrefab, cellCenterWorldPos, targetPrefab.transform.rotation);
                }
                else
                {
                    originalObj.transform.position = cellCenterWorldPos; // マウスの位置にオブジェクトを設置
                }
            }
        }
    }
}
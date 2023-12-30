using UnityEngine;
using UnityEngine.Tilemaps;

public class Architecture : MonoBehaviour
{
    private GameObject targetPrefab;
    private Tilemap tilemap;  // Tilemapの参照
    private GameObject originalObj;
    private GameObject block;
    private GameObject mesh;
    private MeshRenderer meshRend;
    private BuildingInfo buildingInfo;
    float maxDistance = 100.0f; // 無限にする場合は Mathf.Infinity
    int layerMask;
    bool isActive;
    private RotateObject rotateObject;
    public void SetAll(Tilemap tilemap)
    {
        Debug.Log("初期化");
        this.layerMask = 1 << LayerMask.NameToLayer("Ground");
        this.tilemap = tilemap;
    }

    public void Run(GameObject targetPrefab, AudioSource audioSource, RotateObject rotateObject)
    {
        this.targetPrefab = targetPrefab;
        this.originalObj = (GameObject)Instantiate(targetPrefab, targetPrefab.transform.position, targetPrefab.transform.rotation);
        this.buildingInfo = this.originalObj.GetComponent<BuildingInfo>();
        FindAndSet(this.originalObj);
        rotateObject.targetPrefab = this.originalObj;
        this.isActive = true;
        forUpdate(audioSource); // マウスの位置にオブジェクトを移動
    }

    public void Stop()
    {
        this.isActive = false;
        Destroy(this.originalObj);
    }

    public void forUpdate(AudioSource audioSource)
    {
        if (isActive)
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
                originalObj.transform.position = cellCenterWorldPos; // マウスの位置にオブジェクトを設置

                // 建築物が他の障害物と衝突しているか否かの処理
                if (block.GetComponent<ObstacleDetection>().IsHit())
                {
                    // ここに四角を赤に変更する処理を記述する
                    meshRend.material.color = Color.red;
                    // Debug.Log("Hit");
                }
                else // 建築物が障害物と衝突していない(設置可能の場合)
                {
                    // ここに四角を白or青に変更する処理を記述する
                    meshRend.material.color = Color.blue;
                    if (Input.GetMouseButtonDown(1))  // マウスの右ボタンがクリックされたら
                    {
                        //建築音を鳴らす
                        audioSource.Play();
                        // オブジェクトを設置
                        GameObject gameObject = Instantiate(targetPrefab, cellCenterWorldPos, targetPrefab.transform.rotation);
                        // 各ステータスの調整
                        globalValue.population += buildingInfo.population; // 人口の増減
                        globalValue.money += buildingInfo.cost; // 所持金増減(基本的にcostは負の値)
                        globalValue.armamentsPower += buildingInfo.armamentsPower; // 軍備力の増減
                        globalValue.industryPower += buildingInfo.industryPower; // 工業力の増減
                        // 建築物と座標データをリストに格納
                        globalValue.objectData.originalID.Add(gameObject.GetInstanceID());
                        globalValue.objectData.objID.Add(buildingInfo.objID);
                        globalValue.objectData.pos.Add(gameObject.transform.position);
                    }
                }
            }
        }
    }

    private GameObject GetBlock(GameObject targetObject)
    {
        // 子オブジェクトを検索して取得
        Transform[] childTransforms = targetObject.GetComponentsInChildren<Transform>(true);

        foreach (Transform childTransform in childTransforms)
        {
            // 子オブジェクトのレイヤーが"Block"であるかを確認
            if (childTransform.gameObject.layer == LayerMask.NameToLayer("Block"))
            {
                // "Block"のオブジェクトを見つけた場合の処理
                return childTransform.gameObject; // GameObjectを返すように修正
            }
        }

        // "Block"のオブジェクトが見つからなかった場合はnullを返す
        return null;
    }

    private void FindAndSet(GameObject targetObj)
    {
        // targetObjの子要素からBlockとMeshレイヤーを持つオブジェクトを探してセットする
        Transform[] childTransforms = targetObj.GetComponentsInChildren<Transform>(true);
        foreach (Transform childTransform in childTransforms)
        {
            if (childTransform.gameObject.layer == LayerMask.NameToLayer("Block"))
            {
                this.block = childTransform.gameObject;
            }
            else if (childTransform.gameObject.layer == LayerMask.NameToLayer("Mesh"))
            {
                this.mesh = childTransform.gameObject;
            }
        }
        this.meshRend = this.mesh.GetComponent<MeshRenderer>();
        this.meshRend.enabled = true;
        this.block.AddComponent<ObstacleDetection>();
    }
}
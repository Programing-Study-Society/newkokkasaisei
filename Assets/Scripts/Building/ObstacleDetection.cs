using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetection : MonoBehaviour
{
    // 衝突が発生しているオブジェクトの数
    private int colliderCount = 0;

    // 衝突が始まったときに呼ばれるメソッド
    private void OnTriggerEnter(Collider collision)
    {
        // 衝突が発生したらカウントを増やす
        if(collision.gameObject.layer == LayerMask.NameToLayer("Block"))
            colliderCount++;
    }

    // 衝突が終わったときに呼ばれるメソッド
    private void OnTriggerExit(Collider collision)
    {
        // 衝突が終わったらカウントを減らす
        if(collision.gameObject.layer == LayerMask.NameToLayer("Block"))
            colliderCount--;
    }

    public bool IsHit()
    {
        //Debug.Log(colliderCount);
        return colliderCount > 0;
    }
}

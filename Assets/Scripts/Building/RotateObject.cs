using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public GameObject targetPrefab;

    public void RotateObject90Degrees()
    {

        // オブジェクトの中心を取得
        Vector3 center = targetPrefab.GetComponent<Renderer>().bounds.center;
        Vector3 rotate = targetPrefab.GetComponent<Transform>().localEulerAngles;
        if (rotate.z == -90)
        {
            // オブジェクトをZ軸を中心に90度回転させる
            targetPrefab.transform.RotateAround(center, Vector3.forward, 90f);
        }
        else
        {
            // オブジェクトを中心を基準Y軸に90度回転させる
            targetPrefab.transform.RotateAround(center, Vector3.up, 90f);
        }
    }
}

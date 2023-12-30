using UnityEngine;

public class RotateObject : MonoBehaviour
{
    void Update()
    {
        // スペースキーが押されたらオブジェクトを中心を基準に90度回転させる
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RotateObject90Degrees();
        }
    }

    void RotateObject90Degrees()
    {
        // オブジェクトの中心を取得
        Vector3 center = GetComponent<Renderer>().bounds.center;

        // オブジェクトを中心を基準に90度回転させる
        transform.RotateAround(center, Vector3.up, 90f);
    }
}

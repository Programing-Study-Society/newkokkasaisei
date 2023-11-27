using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transform : MonoBehaviour
{
    //全部のスクリプトのstartを最初に読み込み、次にupdate
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left;
        Debug.Log(3);
    }
}

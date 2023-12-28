using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// テスト用削除予定
public class DebugValue : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("人口：" + globalValue.population);
            Debug.Log("所持金：" + globalValue.money);
            Debug.Log("軍事力：" + globalValue.armamentsPower);
            Debug.Log("工業力："+ globalValue.industryPower);
        }
    }
}

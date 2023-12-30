using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using TMPro;
using System.Diagnostics;
public class Kenkyuu : MonoBehaviour
{
    // Start is called before the first frame update
    //文字のコンポーネント(アニメーしょん、書き込み用）
     public Animator anim; 
     public static TextMeshProUGUI moji;
     //ボタン2つ(canvas1)
     public GameObject button;

    int firstBuilding = 5;//最初の建築物の数

    public bool start = true;

    void Start()
    {
        //文字
        anim = GetComponent<Animator>();
        moji = GetComponent<TextMeshProUGUI>();

         //お金が最低必要コストに達しない時は文字を表示しない
        moji.color = new Color(0,0,0,0);
        //buttonは最初透明で触れないようにしたい
        // button.interactable = false;
        Ani();
    }
    void Update()
    {
    }

    public void Ani()
    {
        if (start)
        {
            if (globalValue.studyNumber - firstBuilding < globalValue.buildingcos.Length)
            {
                //  お金が墓の必要コストに達したら
                if (globalValue.gigaMoney >= globalValue.buildingcos[globalValue.studyNumber - firstBuilding])
                {
                    start = false;
                    moji.text = "新しい建築物が" +  "\n" +
                        globalValue.buildingcos[globalValue.studyNumber - firstBuilding] + "Mで研究可能です";

                    anim.Play("moji1", 0, 0);
                    UnityEngine.Debug.Log(2);
                }
                else
                {
                    moji.text = "次の建築物は" + "\n" +
                        globalValue.buildingcos[globalValue.studyNumber - firstBuilding] + "Mで研究可能になりなす";
                }
            }
        }
    }

//animationeventで制御されている関数
    public void sakusei()
    {
        Invoke("kakik",3);
    }

    public void kakik()
    {
        moji.text = "新しい建築物を" +"\n" + globalValue.buildingcos[globalValue.studyNumber - firstBuilding] + "Mで作成しますか？";
        //ボタンを再度触れられるようにする
        button.SetActive(true);
    }
}
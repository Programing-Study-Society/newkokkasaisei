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
     public CanvasGroup button;
    
    int x = 12;
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
        for(int i = globalValue.buildingcos.Length -1; i >= 0; i--)
        {
            //  お金が墓の必要コストに達したら
            if (x >= globalValue.buildingcos[i])
            {
                anim.SetBool("mojitoumei",true);
                UnityEngine.Debug.Log(2);
                return;
            }
        }
    }

//animationeventで制御されている関数
    public void sakusei()
    {
        Invoke("kakik",5);
    }

    public void kakik()
    {
        moji.text = "新しい建物を\n作成しますか？";
        //ボタンを再度触れられるようにする
        button.alpha = 1;
        button.interactable = true;
    }
}
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using TMPro;
public class Kenkyuu : MonoBehaviour
{
    // Start is called before the first frame update
     Animator anim; 
     Animator anim2; 
     public SpriteRenderer hukidasiToumei;
     public static TextMeshProUGUI moji;
    public  GameObject tmp;
    int x = 1;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim2 = tmp.GetComponent<Animator>();
        hukidasiToumei = gameObject.GetComponent<SpriteRenderer>();
        tmp = GameObject.Find("moji1");
        moji = tmp.GetComponent<TextMeshProUGUI>();
         //お金が最低必要コストに達しない時は吹き出しや文字を表示しない
         hukidasiToumei.color = new Color(0,0,0,0);
         moji.color = new Color(0,0,0,0);
        
    }
    void Update()
    {
        Ani();
    }

    public void Ani()
    {
         //  お金が墓の必要コストに達したら
        if (x >= globalValue.newkentiku.)
        {
            anim.SetBool("toumei", true);
            anim2.SetBool("mojitoumei",true);
            //アニメーションが終わったら、文字を変更
            if(anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1)
                moji.text = "新しい建物を\n";
        }
    }
}
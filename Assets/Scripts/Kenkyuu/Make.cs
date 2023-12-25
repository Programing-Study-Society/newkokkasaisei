using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Make : MonoBehaviour
{
    //文字書き込みコンポーネント
    public GameObject moji1;
    public TextMeshProUGUI moji1com;
    //ボタンコンポーネント
    public CanvasGroup canvas1;
    // Start is called before the first frame update
    
    void Start()
    {
        moji1 = GameObject.Find("moji1");
        moji1com = moji1.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void k()
    {
         //文字、ボタンを視認、触れられなくする
        moji1com.text = "";
        canvas1.interactable = false;
        canvas1.alpha = 0;
    }
}

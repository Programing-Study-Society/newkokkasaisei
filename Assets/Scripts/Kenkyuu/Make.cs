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
    public GameObject canvas1;
    public Kenkyuu kenkyuu;

    int firstBuilding = 5;//最初の建築物の数

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
        moji1com.color = new Color(0, 0, 0, 0);
        canvas1.SetActive(false);
        kenkyuu.start = true;
        globalValue.gigaMoney -= globalValue.buildingcos[globalValue.studyNumber - firstBuilding];
    }
}

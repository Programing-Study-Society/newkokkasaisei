using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zeikinn2 : MonoBehaviour
{
    // Start is called before the first frame update
    public string a;
    void Start()
    {
        Text score_text = GetComponent<Text>();
        score_text.text = a;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

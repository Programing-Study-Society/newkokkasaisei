using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class zikken : MonoBehaviour
{
    public TMP_InputField inputField;
    int a;
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
    }
    public void str_func()
    {
        a = int.Parse(inputField.text);
        Debug.Log("Œ‹‰Ê" + a);
    }
}
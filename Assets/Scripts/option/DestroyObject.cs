using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyObject : MonoBehaviour
{
    public GameObject destroyObject;

    public void destroyOnClick()
    {
        Destroy(destroyObject, .5f);
    }
}

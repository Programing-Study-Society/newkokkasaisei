using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleton : MonoBehaviour
{
    private static singleton _instance;

    public static singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                SetupInstance();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private static void SetupInstance()
    {
        _instance = FindObjectOfType<singleton>();

        if (_instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = "Singleton";
            _instance = gameObj.AddComponent<singleton>();
            DontDestroyOnLoad(gameObj);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChange : MonoBehaviour
{
    public string[] keyCodes;
    public BuildingParent[] buildingParents;
    int old = 0;

    void Start()
    {
        if(buildingParents.Length != keyCodes.Length)
            Debug.Log("警告：buildingParentsとkeyCodesの要素数が異なります。\n無効な値を読み取る可能性があります。");
        modeSet(old, old);
    }

    void Update()
    {
        for(int i = 0; i < keyCodes.Length; i++)
            if(Input.GetKeyDown(keyCodes[i]))
            {
                modeSet(i, old);
                old = i;
            }
    }

    void modeSet(int run, int stop)
    {
        buildingParents[stop].Stop();
        buildingParents[run].Run();
    }
}

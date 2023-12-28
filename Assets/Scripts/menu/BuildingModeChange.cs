using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingModeChange : MonoBehaviour
{
    public BuildingParent[] buildingParents;
    int old = 0;
    [HideInInspector] public int modeSetNumber = 0;

    void Update()
    {
        if(old != modeSetNumber)
        {
            modeSet(modeSetNumber, old);
            old = modeSetNumber;
        }
    }

    // ごり押しバグ修正すみません！！
    void OnDisable()
    {
        old = 0;
        modeSetNumber = 0;
        foreach(BuildingParent obj in buildingParents)
        {
            obj.Stop();
        }
    }

    void modeSet(int run, int stop)
    {
        buildingParents[stop].Stop();
        buildingParents[run].Run();
    }
}

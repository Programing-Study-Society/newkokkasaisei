using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingModeChange : MonoBehaviour
{
    public BuildingParent[] buildingParents;
    int old = 0;
    [HideInInspector] public int modeSetNumber = 0;

    void Start()
    {
        modeSet(old, old);
    }

    void Update()
    {
        if(old != modeSetNumber)
        {
            modeSet(modeSetNumber, old);
            old = modeSetNumber;
        }
    }

    void modeSet(int run, int stop)
    {
        buildingParents[stop].Stop();
        buildingParents[run].Run();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAddObject : MonoBehaviour
{
    public BuildingSelect buildingSelect;
    public BuildingObjectSelect buildingObjectSelect;
    public SetBuilding setBuilding;

    int firstBuilding = 5;

    void Start()
    {
        for (int number = firstBuilding; number < globalValue.studyNumber; number++)
        {
            buildingSelect.objects[number] = setBuilding.buildings[0];
        }
    }

    public void BuildingAddList()
    {
        buildingSelect.objects[globalValue.studyNumber] = setBuilding.buildings[0];
        
        globalValue.studyNumber++;

        //ボタンのオンオフ切替
        buildingObjectSelect.CreateModeSetActive();
    }
}

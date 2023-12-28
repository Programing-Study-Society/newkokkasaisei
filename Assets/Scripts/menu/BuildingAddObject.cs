using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAddObject : MonoBehaviour
{
    public BuildingSelect buildingSelect;
    public BuildingObjectSelect buildingObjectSelect;
    public GameObject[] addObjects;

    int addObjectsNumber = 0;

    //最初から建築できる数
    private int firstBuilding = 2;

    public void BuildingAddList()
    {
        buildingSelect.objects[addObjectsNumber + firstBuilding] = addObjects[addObjectsNumber];
        addObjectsNumber++;
        buildingObjectSelect.CreateModeSetActive();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingObjectSelect : MonoBehaviour
{
    public BuildingSelect buildingSelect;
    public BuildingModeChange buildingModeChange;

    public int buildingObjectNumber;

    void Start()
    {
        BuildingObjectExistence(buildingObjectNumber);
    }

    void Update()
    {
        BuildingObjectExistence(buildingObjectNumber);
    }

    public void BuildingSelectOnClick()
    {
        buildingSelect.buildingObjectListPoint = buildingObjectNumber;
    }

    public void BuildModeChangeOnClick()
    {
        buildingModeChange.modeSetNumber = buildingObjectNumber;
    }

    public void BuildingObjectExistence(int number)
    {
        if (!buildingSelect.objects[number])
        {
            Button btn = this.GetComponent<Button>();
            btn.interactable = false;
        }
        else
        {
            Button btn = this.GetComponent<Button>();
            btn.interactable = true;
        }
    }
}

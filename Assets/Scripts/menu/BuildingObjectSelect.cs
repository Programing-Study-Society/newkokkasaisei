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
        CreateModeSetActive();

    }

    // ごり押しバグ修正すみません！！
    void OnDisable()
    {
        CreateModeSetActive();
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
    public void DeleteModeSetActive()
    {
        int number = 0;
        while (buildingSelect.objects[number])
        {
            Button btn = buildingSelect.objectsButton[number].GetComponent<Button>();
            btn.interactable = false;
            number++;
        }
    }

    public void CreateModeSetActive()
    {
        for (int number = 0; number < globalValue.studyNumber; number++)
        {
            Button btn = buildingSelect.objectsButton[number].GetComponent<Button>();
            btn.interactable = true;
        }
    }
}

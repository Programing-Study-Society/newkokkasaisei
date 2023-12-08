using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAddObject : MonoBehaviour
{
    public BuildingSelect buildingSelect;
    public GameObject[] addObjects;
    int addObjectsNumber = 0;

    //Å‰‚©‚çŒš’z‚Å‚«‚é”
    private int firstBuilding = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuildingAddList()
    {
        buildingSelect.objects[addObjectsNumber + firstBuilding] = addObjects[addObjectsNumber];
        addObjectsNumber++;
    }
}

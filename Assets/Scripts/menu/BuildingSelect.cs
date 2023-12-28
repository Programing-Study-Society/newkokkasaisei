using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSelect : BuildingParent
{
    public Tilemap tilemap;
    public InfoDisplay infoDisplay;

    [HideInInspector] public int buildingObjectListPoint = 0;

    public List<GameObject> objects;
    public List<GameObject> objectsButton;

    private Architecture architecture;
    private int old = 0;

    void Awake()
    {
        architecture = gameObject.AddComponent<Architecture>();
        architecture.SetAll(tilemap);
    }

    // ごり押しバグ修正すみません！！
    void OnEnable()
    {
        Run();
    }

    void Update()
    {
        architecture.forUpdate();

        if(buildingObjectListPoint != old)
        {
            old = buildingObjectListPoint;
            architecture.Stop();
            GameObject obj =objects[buildingObjectListPoint];
            architecture.Run(obj);
            infoDisplay.Display(obj);
        }
        

    }
    public override void Run()
    {
        infoDisplay.gameObject.SetActive(true);
        GameObject obj = objects[old];
        architecture.Run(obj);
        infoDisplay.Display(obj);
    }

    public override void Stop()
    {
        infoDisplay.gameObject.SetActive(false);
        architecture.Stop();
    }
}

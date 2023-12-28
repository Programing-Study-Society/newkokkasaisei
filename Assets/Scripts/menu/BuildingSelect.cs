using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSelect : BuildingParent
{
    public Tilemap tilemap;

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
            architecture.Run(objects[buildingObjectListPoint]);
        }
        

    }
    public override void Run()
    {
        Debug.Log("建築セレクトRun");
        architecture.Run(objects[old]);
    }

    public override void Stop()
    {
        architecture.Stop();
    }
}

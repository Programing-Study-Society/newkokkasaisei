using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSelect : BuildingParent
{
    public SoundVolume soundVolume;
    public Tilemap tilemap;
    public InfoDisplay infoDisplay;
    public RotateObject rotateObject;

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
        architecture.forUpdate(soundVolume.seVolume[10]);

        if (buildingObjectListPoint != old)
        {
            old = buildingObjectListPoint;
            architecture.Stop();
            GameObject obj = objects[buildingObjectListPoint];
            architecture.Run(obj, soundVolume.seVolume[10], rotateObject);
            infoDisplay.Display(obj);
        }


    }
    public override void Run()
    {
        infoDisplay.gameObject.SetActive(true);
        GameObject obj = objects[old];
        architecture.Run(obj, soundVolume.seVolume[10], rotateObject);
        infoDisplay.Display(obj);
    }

    public override void Stop()
    {
        infoDisplay.gameObject.SetActive(false);
        architecture.Stop();
    }
}

using UnityEngine;
using UnityEngine.Tilemaps;

public class Building : BuildingParent
{
    public Tilemap tilemap;
    public string[] keyCodes;
    public GameObject[] objects;
    private Architecture architecture;
    private int old = 0;

    void Awake()
    {
        architecture = gameObject.AddComponent<Architecture>();
    }

    void Start()
    {
        if(objects.Length != keyCodes.Length)
            Debug.Log("警告：objectsとkeyCodesの要素数が異なります。\n無効な値を読み取る可能性があります。");
        architecture.SetAll(tilemap, objects[0]);
    }

    void Update()
    {
        architecture.forUpdate();

        for(int i = 0; i < keyCodes.Length; i++)
        {
            if(Input.GetKeyDown(keyCodes[i]))
            {
                old = i;
                architecture.Stop();
                architecture.Run(objects[i]);
            }
        }
    }

    public override void Run()
    {
        architecture.Run(objects[old]);
    }

    public override void Stop()
    {
        architecture.Stop();
    }
}

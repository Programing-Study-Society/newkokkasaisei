using UnityEngine;
using UnityEngine.Tilemaps;

public class Building : BuildingParent
{
    public SoundVolume soundVolume;
    public Tilemap tilemap;
    public string[] keyCodes;
    public GameObject[] objects;
    private Architecture architecture;
    private int old = 0;
    private bool isActive = false;

    void Awake()
    {
        architecture = gameObject.AddComponent<Architecture>();
    }

    void Start()
    {
        if(objects.Length != keyCodes.Length)
            Debug.Log("警告：objectsとkeyCodesの要素数が異なります。\n無効な値を読み取る可能性があります。");
        architecture.SetAll(tilemap);
    }

    void Update()
    {
        architecture.forUpdate(soundVolume.seVolume[10]);

        if(isActive)
        {
            for(int i = 0; i < keyCodes.Length; i++)
            {
                if(Input.GetKeyDown(keyCodes[i]))
                {
                    old = i;
                    architecture.Stop();
                    architecture.Run(objects[i] , soundVolume.seVolume[10]);
                }
            }
        }
    }

    public override void Run()
    {
        isActive = true;
        architecture.Run(objects[old], soundVolume.seVolume[10]);
    }

    public override void Stop()
    {
        isActive = false;
        architecture.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolume : MonoBehaviour
{
    public List<AudioSource> bgmVolume;
    public List<AudioSource> seVolume;

    // Start is called before the first frame update
    void Start()
    {
        BGMVolume();
        SEVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BGMVolume()
    {
        for(int i = 0; i < bgmVolume.Count; i++)
        {
            bgmVolume[i].volume = globalValue.bgmVolume;
        }
    }

    public void SEVolume()
    {
        for (int i = 0; i < seVolume.Count; i++)
        {
            seVolume[i].volume = globalValue.seVolume;
        }
    }
}

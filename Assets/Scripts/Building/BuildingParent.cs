using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingParent : MonoBehaviour
{
    public virtual void Run()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void Stop()
    {
        this.gameObject.SetActive(false);
    }
}

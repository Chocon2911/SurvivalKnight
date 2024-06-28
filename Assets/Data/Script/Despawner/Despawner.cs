using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawner : HuyMonoBehaviour
{
    public virtual void DespawnObj()
    {
        Destroy(transform);
    }
}

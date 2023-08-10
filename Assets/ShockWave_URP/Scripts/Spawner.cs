using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private PoolManager PM;

    public Vector3 point;
    public bool spawn;

    // Start is called before the first frame update
    void Start()
    {
        PM = PoolManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            GameObject item = PM.Spawn("SpriteExplosion") as GameObject;
            item.transform.position = point;

            spawn = false;
        }
    }
}

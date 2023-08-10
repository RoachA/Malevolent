/*
RecycleAfter.cs
This script Recycles an Object after t seconds
*/

using UnityEngine;
using System.Collections;

public class RecycleAfter : MonoBehaviour {

#region Variables

    //the Name of the Prefab that created this
    private string PrefabName;

    //time it was created
    private float StartTime;

    //number of seconds until Recycle
    public float t = 1f;

#endregion


#region Methods

    // Use this before initialization
    void Awake()
    {
        PrefabName = gameObject.name.Replace("(Clone)","");
        StartTime = Time.time;
    }

    //reset the time...if it's already been recycled once
    void OnEnable()
    {
        StartTime = Time.time;
    }

    //Update is called once per render
    void FixedUpdate()
    {
        if (Time.time - StartTime >= t)
        {
            PoolManager.Instance.Recycle(PrefabName,gameObject);
        }
    }

#endregion
}

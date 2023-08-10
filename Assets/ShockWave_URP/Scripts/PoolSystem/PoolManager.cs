﻿/*
PoolManager.cs
This script manages pools of objects
Spawning and Recycling.
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// A struct for objects to be pooled.
[System.Serializable]
public class ObjectToPool
{
	public GameObject prefab;
	public int initialCapacity;
}

// Singleton for managing pools of different objects.
public class PoolManager : MonoBehaviour {

	#region PUBLIC VARIABLES
	// Objects to be pooled at initialization.
	public ObjectToPool[] prefabsToPool;
	#endregion

	#region PRIVATE VARIABLES
	private Dictionary<string, ObjectPool> pools;
	#endregion

	#region SINGLETON PATTERN
	public static PoolManager _instance;
	
	//execute this on Awake()
    public void singletonAwake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject); //or this
        }
    }

    public static PoolManager Instance
	{
		get {
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<PoolManager>();
				
				if (_instance == null)
				{
					GameObject container = new GameObject("Pool Manager");
					_instance = container.AddComponent<PoolManager>();
				}
			}
			
			return _instance;
		}
	}
	#endregion

	#region MONOBEHAVIOUR METHODS
	void Awake()
    {
        singletonAwake();
    }
    
	void Start()
	{
		for (int i = 0; i < prefabsToPool.Length; i++)
		{
			CreatePool(prefabsToPool[i].prefab, prefabsToPool[i].initialCapacity);
		}
	}
	#endregion

	#region PUBLIC METHODS
	// Create a new pool of objects at runtime.
	public void CreatePool(GameObject prefab, int initialCapacity)
	{
		if (pools == null)
        {
			pools = new Dictionary<string, ObjectPool>();
        }

		ObjectPool newPool = new ObjectPool(prefab, initialCapacity);      
		pools.Add(prefab.name, newPool);
	}

	// Spawn an object with the given name.
	public GameObject Spawn(string prefabName)
	{
		if (!pools.ContainsKey(prefabName))
        {
            Debug.Log("no pool by that name");
			return null;
        }

		return pools[prefabName].Spawn();
	}

    
	// Recycle an object with the given name.
	public void Recycle(string prefabName, GameObject obj)
	{
		if (!pools.ContainsKey(prefabName))
        {
            Debug.Log("no pool by that name");
			return;
        }

		pools[prefabName].Recycle(obj);
  
	}


    // Recycle an object with the given name.
    public void Recycle(GameObject obj)
    {
        if (!pools.ContainsKey(obj.name))
        {
            Debug.Log("no pool by that name");
            return;
        }

        pools[obj.name].Recycle(obj);
    }


	#endregion
}
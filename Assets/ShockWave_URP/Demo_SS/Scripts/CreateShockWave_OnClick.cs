//This script is Just used for Demo1.
//this script is pretty basic...so there is not a lot of comments.



using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(ShockWaveSS_Manager))]
public class CreateShockWave_OnClick : MonoBehaviour {

    private ShockWaveSS_Manager shockwavess_manager;

    void Start()
    {
        shockwavess_manager = GetComponent<ShockWaveSS_Manager>();
    }

	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            shockwavess_manager.create(Input.mousePosition);
        }
	}

}

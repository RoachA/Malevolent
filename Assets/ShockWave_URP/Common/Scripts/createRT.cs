/*

this script creates a render texture according to the current screen's size (divided by 2)
and set it to the camera and the shockwave prefab

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class createRT : MonoBehaviour
{
    /// <summary>
    /// this is the camera that creates/updates the render texture 
    /// </summary>
    public Camera RT_Camera;

    public RenderTexture RT;

    // Start is called before the first frame update
    void Start()
    {
        int half_H = (int)Screen.width / 2;
        int half_W = (int)Screen.height / 2;
        RT = new RenderTexture(half_H, half_W, 16, RenderTextureFormat.ARGBFloat);
        RT.Create();

        AssetDatabase.CreateAsset(RT, "Assets/ShockWave_URP/Common/Images/RT.renderTexture");

        RT_Camera.targetTexture = RT;
    }

}

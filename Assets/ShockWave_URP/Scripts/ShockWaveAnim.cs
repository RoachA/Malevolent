using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ShockWaveAnim : MonoBehaviour
{

    ///// <summary>
    ///// this is the material that will store the ShockWave Shader
    ///// </summary>
    //public Material material; // this is no longer needed 
    public Shader shader;
    private Material mat;

    /// <summary>
    /// The speed. if speed is zero animation will not run, and can be animated with animator
    /// </summary>
    //[Range(0.01f, 100f)]
    public float speed = 1f;

    /// <summary>
    /// The t, the time for this object
    /// </summary>
    public float t = 0f;

    /// <summary>
    /// The radius over time.
    /// </summary>
    public AnimationCurve radiusAnim;

    /// <summary>
    /// The wave size over time.
    /// </summary>
    public AnimationCurve wavesizeAnim;

    /// <summary>
    /// The amplitude over time.
    /// </summary>
    public AnimationCurve amplitudeAnim;

    /// <summary>
    /// color over time
    /// </summary>
    public Gradient colorAnim;

    /// <summary>
    /// Saturation over time
    /// </summary>
    public AnimationCurve SatAnim;

    /// <summary>
    /// the path to the render texture that should be used (i.e. rtUpdater.cs)
    /// </summary>
    public string renderTexture_assetpath = "Assets/ShockWave_URP/Common/Images/RT.renderTexture";

    /// <summary>
    /// this is the render texture that can be used,
    /// </summary>
    public RenderTexture renderTexture;

    /// <summary>
    /// destory object when done animating
    /// </summary>
    public bool destoryWhenDone = false;

    // Start is called before the first frame update
    void Start()
    {

        if (renderTexture_assetpath != "")
        {
            renderTexture = AssetDatabase.LoadAssetAtPath<RenderTexture>(renderTexture_assetpath);
        }

        mat = new Material(shader);

        GetComponent<Renderer>().material = mat;
        //GetComponent<Renderer>().material.CopyPropertiesFromMaterial(material);
        //mat = GetComponent<Renderer>().material;


        //set the radius amplitude and wavesize to zero
        mat.SetFloat("_radius", radiusAnim.Evaluate(0.0f));
        mat.SetFloat("_amplitude", amplitudeAnim.Evaluate(0.0f));
        mat.SetFloat("_wavesize", wavesizeAnim.Evaluate(0.0f));
        mat.SetColor("_color", colorAnim.Evaluate(0.0f));
        mat.SetFloat("_saturation", SatAnim.Evaluate(0.0f));
        mat.SetInt("_active", 1);

        mat.SetTexture("_texture", renderTexture);

        if (renderTexture == null)
            mat.SetInt("_useRenderTexture", 0);
        else
            mat.SetInt("_useRenderTexture", 1);

        t = 0;
    }

    void OnEnable()
    {
        t = 0;
    }

    // Update is called once per frame
    //void Update()
    void FixedUpdate()
    {

        //update the radius amplitude and waveSize
        mat.SetFloat("_radius", radiusAnim.Evaluate(t));
        mat.SetFloat("_amplitude", amplitudeAnim.Evaluate(t));
        mat.SetFloat("_wavesize", wavesizeAnim.Evaluate(t));
        mat.SetColor("_color", colorAnim.Evaluate(t));
        mat.SetFloat("_saturation", SatAnim.Evaluate(t));

        gameObject.transform.position -= gameObject.transform.forward * 0.001f;

        if (speed == 0f)
        {
            return;
        }

        //increment t
        t += (speed * Time.deltaTime);

        if (t > 1f)
        {
            //mat.SetInt("_active", 0);

            if (destoryWhenDone)
            {
                Destroy(gameObject);
            }
        }

    }

    private RenderTexture FindRT()
    {
        foreach (Camera C in GameObject.FindObjectsOfType<Camera>() )
        {

            if (C.targetTexture != null)
            {
                Debug.Log(C.name);
                return C.targetTexture;
            }
        }

        return null;
    
    }

    //this part is used in the editor only...allows a preview of the animation by using the slider

    /*
#if UNITY_EDITOR || UNITY_EDITOR_OSX || UNITY_EDITOR_64
    [Range(0.0f, 1.0f)]
    public float timePreview_InEditModeOnly = 0f;
    void Update()
    {
        //not while the editor is in play mode
        if (!Application.isPlaying)
        {
            mat.SetFloat("_radius", radiusAnim.Evaluate(timePreview_InEditModeOnly));
            mat.SetFloat("_amplitude", amplitudeAnim.Evaluate(timePreview_InEditModeOnly));
            mat.SetFloat("_wavesize", wavesizeAnim.Evaluate(timePreview_InEditModeOnly));
            mat.SetColor("_color", colorAnim.Evaluate(timePreview_InEditModeOnly));
            mat.SetFloat("_saturation", SatAnim.Evaluate(timePreview_InEditModeOnly));
        }
    }
#endif
    */

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWaveSS_Manager : MonoBehaviour
{
    // Start is called before the first frame update



    public struct_Shockwave[] shockWaves;

    [System.Serializable]
    public struct struct_Shockwave
    {
        public bool isOn;
        public float anim;
        public Material material;
    }

    public float speed = 1.0f;
    public AnimationCurve radiusCurve;
    public AnimationCurve amplitudeCurve;
    public AnimationCurve wavesizeCurve;
    public AnimationCurve colorsaturationCurve;

    public bool useGradient = true;

    [GradientUsage(true)]
    public Gradient colorGradient;

    [ColorUsageAttribute(true, true, 0f, 8f, 0.125f, 3f)]
    public Color altColor;

    public bool overrideMax = true;
    public float overrideOver = 0.95f;


    void Awake()
    {
        //on Awake set all to off and make them invisible
        for (int i = 0; i < shockWaves.Length; i++)
        {
            shockWaves[i].isOn = false;
            shockWaves[i].anim = 0.0f;
            shockWaves[i].material.SetVector("_position", Vector4.zero);
            shockWaves[i].material.SetFloat("_radius", 0.0f);
            shockWaves[i].material.SetFloat("_amplitude", 0.0f);
            shockWaves[i].material.SetFloat("_wavesize", 0.0f);
            shockWaves[i].material.SetFloat("_saturation", 0.0f);
        }
    }

    public void create(Vector2 position)
    {
        bool created = false;
        for (int i = 0; i < shockWaves.Length; i++)
        {
            // get the top inactive... or over 80
            if (shockWaves[i].isOn == false)
            {
                shockWaves[i].isOn = true;
                shockWaves[i].material.SetVector("_position", new Vector4(position.x, position.y,0.0f,0.0f));
                created = true;
                break; //break if you made 1 
            }
        }

        // did not create a shockwave... lets just over
        if (created == false)
        {
            if (overrideMax == true && shockWaves[0].anim >=overrideOver)
            {
                shockWaves[0].isOn = true;
                shockWaves[0].material.SetVector("_position", new Vector4(position.x, position.y, 0.0f, 0.0f));
                created = true;
            }
        }


        if (created)
        {
            Debug.Log("shockwave created");
        }
        else
        {
            Debug.Log("sorry, unable to create shockwave");
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < shockWaves.Length; i++)
        {
            if (shockWaves[i].isOn == true)
            {
                shockWaves[i].anim += Time.deltaTime * speed;

                float anim = shockWaves[i].anim;

                shockWaves[i].material.SetFloat("_radius", radiusCurve.Evaluate(anim));
                shockWaves[i].material.SetFloat("_amplitude", amplitudeCurve.Evaluate(anim));
                shockWaves[i].material.SetFloat("_wavesize", wavesizeCurve.Evaluate(anim));
                shockWaves[i].material.SetFloat("_saturation", colorsaturationCurve.Evaluate(anim));

                if (useGradient)
                {
                    shockWaves[i].material.SetColor("_color", colorGradient.Evaluate(anim));
                }
                else 
                {
                    shockWaves[i].material.SetColor("_color", altColor);
                }
                

            }

            if (shockWaves[i].anim >= 1.0f)
            {
                shockWaves[i].isOn = false;
                shockWaves[i].anim = 0.0f;
                shockWaves[i].material.SetVector("_position", Vector4.zero);
                shockWaves[i].material.SetFloat("_radius", 0.0f);
                shockWaves[i].material.SetFloat("_amplitude", 0.0f);
                shockWaves[i].material.SetFloat("_wavesize", 0.0f);
                shockWaves[i].material.SetFloat("_saturation", 0.0f);
            }

        }
    }
}

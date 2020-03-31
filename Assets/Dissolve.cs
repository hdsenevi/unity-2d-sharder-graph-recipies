using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    private Material material;

    private bool isDissolving = false;
    private bool isAppearing = false;
    private float fade = 1f;

    void Start()
    {
        // Get reference to the material
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDissolving = true;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            isAppearing = true;
        }

        if (isDissolving)
        {
            fade -= Time.deltaTime;

            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
            }

            // Set the property
            material.SetFloat("_Fade", fade);
        }

        if (isAppearing)
        {
            fade += Time.deltaTime;

            if (fade >= 1f)
            {
                fade = 1f;
                isAppearing = false;
            }

            // Set the property
            material.SetFloat("_Fade", fade);
        }
    }
}

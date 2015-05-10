﻿using UnityEngine;
using System.Collections;

public class ShakeBabyShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeBase;
    private float shake;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    private bool clicked = false;
    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update ()
    {
        if (!clicked)
        {
            shake = shakeBase;
        }

        if (Input.GetButtonDown("Fire1") || clicked == true)
        {
            clicked = true;
                if (shake > 0)
                {
                    camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
                    shake -= Time.deltaTime * decreaseFactor;
                }
                else
                {
                    shake = 0f;
                    camTransform.localPosition = originalPos;
                    clicked = false;
                }    
        }

    }
}
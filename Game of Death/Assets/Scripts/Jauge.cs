using UnityEngine;
using System.Collections;

public class Jauge : MonoBehaviour {

    private int debut = 0;
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    private Transform objectTransform;

    // How long the object should shake for.
    public float shake = 15f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    bool perte;

    // camera pour declencher les animations lors de la perte de pv
    

    public void Start()
    {
        PerteVie(0);
        perte = false;
    }

    public void PerteVie (int points)
    {
        // changer perteVie de la camera en true pour declencher les vibrations
        

        debut = debut + points;

        if (debut < transform.childCount)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

            transform.GetChild(debut).gameObject.SetActive(true);

            GameObject image = transform.GetChild(debut).gameObject;


        }
        else
        {
            transform.GetChild(debut-1).gameObject.SetActive(true);
        }

        if (debut > 0)
        {
            perte = true;
        }
    }
}

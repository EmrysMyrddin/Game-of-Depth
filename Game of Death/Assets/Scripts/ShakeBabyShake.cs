using UnityEngine;
using System.Collections;
using XInputDotNetPure; // Required in C#

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


    //
    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    //

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

        // Find a PlayerIndex, for a single player game
        // Will find the first controller that is connected ans use it
        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }

        prevState = state;
        state = GamePad.GetState(playerIndex);


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
                    GamePad.SetVibration(playerIndex, 2f, 2f);

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
using UnityEngine;
using XInputDotNetPure; // Required in C#

public class PadController : MonoBehaviour
{
    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    // Use this for initialization
    void Start()
    {
        // No need to initialize anything for the plugin
    }

    // Update is called once per frame
    void Update()
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

       
        // Set vibration according to triggers
        GamePad.SetVibration(playerIndex, state.Triggers.Left, state.Triggers.Right);

        // Make the current object turn
        transform.localRotation *= Quaternion.Euler(0.0f, state.ThumbSticks.Left.X * 25.0f * Time.deltaTime, 0.0f);
    }
}

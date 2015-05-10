using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {
	
    public void LoadGame(string game)
    {
        Application.LoadLevel(game);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

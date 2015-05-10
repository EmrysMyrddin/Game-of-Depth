using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {

	public string game;
	
    public void LoadGame(string game)
    {
        Application.LoadLevel(game);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

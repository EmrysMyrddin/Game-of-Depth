using UnityEngine;
using System.Collections;

public class Model : MonoBehaviour {
	public int nbLine = 10;
	public int nbColone = 30;

	private int[,] plateau;

	// Use this for initialization
	void Start () {
		plateau = new int[nbColone, nbLine];
	}

	public int get(int x, int y)
	{
		return plateau [x, y];
	}

	public int set(int x, int y, int value)
	{
		return plateau [x, y] = value;
	}
}

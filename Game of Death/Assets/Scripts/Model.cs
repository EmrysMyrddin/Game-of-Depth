using UnityEngine;
using System.Collections;

public class Model : MonoBehaviour {
	public int nbLine = 10;
	public int nbColone = 30;
	public float moveSpeed = 2f;
	public float unitAnimationSpeed = 1f;

	private int[,] plateau;
	private float nextMove = 0f;
	private float previousMove = 0f;

	// Use this for initialization
	void Start () {
		plateau = new int[nbColone, nbLine];
	}

	void Update(){
		if (Time.time > nextMove) {
			previousMove = nextMove;
			nextMove += 1 / moveSpeed;

			Unit[] units = FindObjectsOfType(typeof(Unit)) as Unit[];
			for(int i = 0; i < units.Length; i++)
			{
				units[i].move();
			}

			Selector[] selectors = FindObjectsOfType (typeof(Selector)) as Selector[];
			for (int i = 0; i < selectors.Length; i++) {
				selectors [i].move();
			}
		}

		if (Time.time > previousMove + 0.1f + 1/unitAnimationSpeed && previousMove != -1) {
			Selector[] selectors = FindObjectsOfType (typeof(Selector)) as Selector[];
			for (int i = 0; i < selectors.Length; i++) {
				selectors [i].hasMoved ();
			}
			previousMove = -1;
		}
	}

	public int get(int x, int y)
	{
		return plateau [x, y];
	}

	public int set(int x, int y, int value)
	{
		return plateau [x, y] = value;
	}

	public void spawnUnit(GameObject prefab, Vector3 position, int x, int y, int direction)
	{
		GameObject newUnit = (GameObject)GameObject.Instantiate (prefab, position , prefab.transform.rotation);
		Unit newUnitScript = newUnit.GetComponent("Unit") as Unit;
		newUnitScript.direction = direction;
		newUnitScript.modelX = x;
		newUnitScript.modelY = y;
		newUnit.SetActive (true);
		if (direction == 1) {
			float rotx = newUnit.transform.rotation.x;
			float roty = newUnit.transform.rotation.y;
			float rotz = newUnit.transform.rotation.z;
			newUnit.transform.Rotate (new Vector3 (rotx, y + 180f, rotz));
		}
		set (x, y, 3);
	}
}

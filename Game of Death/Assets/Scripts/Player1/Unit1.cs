using UnityEngine;
using System.Collections;

public class Unit1 : MonoBehaviour {

	public float velocity = 2f;
	public int nbColone = 10;

	private float x,y,z;
	private Model model;
	private int modelX, modelY;

	// Use this for initialization
	void Start () {
		model = GameObject.Find ("Plateau").GetComponent("Model") as Model;
		modelX = 29;
	}
	
	// Update is called once per frame
	void Update () {
		y = this.gameObject.transform.position.y;
		z = this.gameObject.transform.position.z;
		x = this.gameObject.transform.position.x;

		gameObject.transform.position = new Vector3(x + Time.deltaTime * velocity, y, z);

		if(x > model.nbColone - 0.5)
			Destroy(gameObject);
	}
}
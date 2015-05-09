using UnityEngine;
using System.Collections;

public class Unit2 : MonoBehaviour {

	public float velocity = 2f;
	public int nbColone = 10;
	
	private float x,y,z;
	private Model model;
	
	// Use this for initialization
	void Start () {
		model = GameObject.Find ("Plateau").GetComponent("Model") as Model;
	}
	
	// Update is called once per frame
	void Update () {
		y = this.gameObject.transform.position.y;
		z = this.gameObject.transform.position.z;
		x = this.gameObject.transform.position.x;
		
		gameObject.transform.position = new Vector3(x - Time.deltaTime * velocity, y, z);
		
		if(x < 0.5)
			Destroy(gameObject);
	}
}

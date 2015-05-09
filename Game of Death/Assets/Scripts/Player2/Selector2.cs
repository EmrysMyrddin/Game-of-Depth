using UnityEngine;
using System.Collections;

public class Selector2 : MonoBehaviour {

	private float x, y, z;
	private int modelX, modelY;
	private float nextTime = 0f;
	private bool goingUp = false;
	private bool isFirstPush = true;
	private Model model;
	private float dontSpamDickHead = 0.0f;
	private float CDpop = 1.0f;
	
	public float firstUpdateRate =  0.2f;
	public float secondUpdateRate =  0.1f;
	public GameObject Soldat_p2;
	public GameObject Tank_p2;
	public GameObject Cavalier_p2;
	public int nbLine = 10;
	
	// Use this for initialization
	void Start () {
		x = this.gameObject.transform.position.x;
		y = this.gameObject.transform.position.y;
		modelX = 29;
		modelY = 0;

		model = GameObject.Find ("Plateau").GetComponent("Model") as Model;
	}
	
	// Update is called once per frame
	void Update ()
	{
		z = this.gameObject.transform.position.z;
		
		if (Input.GetAxis ("Vertical_P2") == 0f)
			isFirstPush = true;
		
		if ( Input.GetAxis("Vertical_P2") > 0 && (Time.time > nextTime || !goingUp)) {
			if(isFirstPush){
				isFirstPush = false;
				nextTime = Time.time + firstUpdateRate;
			}
			else{
				nextTime = Time.time + secondUpdateRate;
			}
			
			if(z < nbLine - 0.5f)
			{
				z += 1f;
				modelY ++;
			}
			goingUp = true;
		} else if (Input.GetAxis("Vertical_P2") < 0 && (Time.time > nextTime || goingUp)) {
			if(isFirstPush){
				isFirstPush = false;
				nextTime = Time.time + firstUpdateRate;
			}
			else{
				nextTime = Time.time + secondUpdateRate;
			}
			
			if(z > 0.5)
			{
				z -= 1f;
				modelY --;
			}
			goingUp = false;
		}
		
		this.gameObject.transform.position = new Vector3(x, y, z);

		if (Time.time > dontSpamDickHead) {
			//if(model.get (modelX, modelY) == 0){
			if (Input.GetButtonDown ("Fire1_P2")) {
				GameObject newUnit = (GameObject)GameObject.Instantiate (Soldat_p2, new Vector3 (x, 0.5f, z), Quaternion.identity);
				newUnit.SetActive (true);
				model.set (modelX, modelY, 1);
				dontSpamDickHead = Time.time + CDpop;
			} else if (Input.GetButtonDown ("Fire2_P2")) {
				GameObject newUnit = (GameObject)GameObject.Instantiate (Tank_p2, new Vector3 (x, 0.5f, z), Quaternion.identity);
				newUnit.SetActive (true);
				model.set (modelX, modelY, 2);
				dontSpamDickHead = Time.time + CDpop;
			} else if (Input.GetButtonDown ("Fire3_P2")) {
				GameObject newUnit = (GameObject)GameObject.Instantiate (Cavalier_p2, new Vector3 (x, 0.5f, z), Quaternion.identity);
				newUnit.SetActive (true);
				model.set (modelX, modelY, 3);
				dontSpamDickHead = Time.time + CDpop;
			}
		}
		//}
	}
}

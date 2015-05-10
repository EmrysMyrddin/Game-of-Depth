using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

	private float x, y, z;
	private float nextTime = 0f;
	private bool goingUp = false;
	private bool isFirstPush = true;
	private Model model;
	private bool canSpawn = true;
	private GameObject requestedSpawn = null;

	public float firstUpdateRate =  0.2f;
	public float secondUpdateRate =  0.1f;
	public string inputPostfix;
	public int direction = 1;
	public GameObject Soldat_p1;
	public GameObject Tank_p1;
	public GameObject Cavalier_p1;
	public int modelX, modelY;

	// Use this for initialization
	void Start () {
		x = this.gameObject.transform.position.x;
		y = this.gameObject.transform.position.y;

		model = GameObject.Find ("Plateau").GetComponent("Model") as Model;
	}
	
	// Update is called once per frame
	void Update ()
	{
		z = this.gameObject.transform.position.z;

		if (Input.GetAxis ("Vertical" + inputPostfix) == 0f)
			isFirstPush = true;

		if ( Input.GetAxis("Vertical" + inputPostfix) > 0 && (Time.time > nextTime || !goingUp)) {
			if(isFirstPush){
				isFirstPush = false;
				nextTime = Time.time + firstUpdateRate;
			}
			else{
				nextTime = Time.time + secondUpdateRate;
			}

			if(z < model.nbLine - 1 - 0.5f){
				modelY ++;
				z += 1f;
			}
			goingUp = true;
		} else if (Input.GetAxis("Vertical" + inputPostfix) < 0 && (Time.time > nextTime || goingUp)) {
			if(isFirstPush){
				isFirstPush = false;
				nextTime = Time.time + firstUpdateRate;
			}
			else{
				nextTime = Time.time + secondUpdateRate;
			}

			if(z > 0.5){
				modelY --;
				z -= 1f;
			}

			goingUp = false;
		}

		this.gameObject.transform.position = new Vector3(x, y, z);

		//if (model.get (modelX, modelY) == 0) {
		if (Input.GetButtonDown ("Fire1" + inputPostfix)) {
			if(canSpawn){
				model.spawnUnit(Soldat_p1, new Vector3 (x, 0, z), modelX, modelY, direction);
				canSpawn = false;
			}
			else{
				requestedSpawn = Soldat_p1;
			}
		} else if (Input.GetButtonDown ("Fire2" + inputPostfix)) {
			if(canSpawn){
				model.spawnUnit(Tank_p1, new Vector3 (x, 0, z), modelX, modelY, direction);
				canSpawn = false;
			}
			else{
				requestedSpawn = Tank_p1;
			}
		} else if (Input.GetButtonDown ("Fire3" + inputPostfix)) {
			if(canSpawn){
				model.spawnUnit(Cavalier_p1, new Vector3 (x, 0, z), modelX, modelY, direction);
				canSpawn = false;
			}
			else{
				requestedSpawn = Cavalier_p1;
			}
		}
		//}
	}

	public void move()
	{
		requestedSpawn = null;
		canSpawn = false;
	}

	public void hasMoved()
	{
		if (requestedSpawn != null) {
			model.spawnUnit (requestedSpawn, new Vector3 (x, 0, z), modelX, modelY, direction);
			canSpawn = false;
		}
		else
			canSpawn = true;
	}
}

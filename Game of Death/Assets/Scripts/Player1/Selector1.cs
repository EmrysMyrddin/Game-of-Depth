﻿using UnityEngine;
using System.Collections;

public class Selector1 : MonoBehaviour {

	private float x, y, z;
	private float nextTime = 0f;
	private bool goingUp = false;
	private bool isFirstPush = true;
	private Model model;
	private int modelX, modelY;
	
	public float firstUpdateRate =  0.2f;
	public float secondUpdateRate =  0.1f;
	public GameObject unit1;
	public GameObject unit2;
	public GameObject unit3;
	public int nbLine = 10;

	// Use this for initialization
	void Start () {
		x = this.gameObject.transform.position.x;
		y = this.gameObject.transform.position.y;
		modelX = 0;
		modelY = 0;

		model = GameObject.Find ("Plateau").GetComponent("Model") as Model;
	}
	
	// Update is called once per frame
	void Update ()
	{
		z = this.gameObject.transform.position.z;

		if (Input.GetAxis ("Vertical") == 0f)
			isFirstPush = true;

		if ( Input.GetAxis("Vertical") > 0 && (Time.time > nextTime || !goingUp)) {
			if(isFirstPush){
				isFirstPush = false;
				nextTime = Time.time + firstUpdateRate;
			}
			else{
				nextTime = Time.time + secondUpdateRate;
			}

			if(z < model.nbLine - 0.5f){
				modelY ++;
				z += 1f;
			}
			goingUp = true;
		} else if (Input.GetAxis("Vertical") < 0 && (Time.time > nextTime || goingUp)) {
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
			if (Input.GetButtonDown ("Fire1")) {
				GameObject newUnit = (GameObject)GameObject.Instantiate (unit1, new Vector3 (x, 0.5f, z), Quaternion.identity);
				newUnit.SetActive (true);
				model.set (modelX, modelY, 1);
			} else if (Input.GetButtonDown ("Fire2")) {
				GameObject newUnit = (GameObject)GameObject.Instantiate (unit2, new Vector3 (x, 0.5f, z), Quaternion.identity);
				newUnit.SetActive (true);
				model.set (modelX, modelY, 2);
			} else if (Input.GetButtonDown ("Fire3")) {
				GameObject newUnit = (GameObject)GameObject.Instantiate (unit3, new Vector3 (x, 0.5f, z), Quaternion.identity);
				newUnit.SetActive (true);
				model.set (modelX, modelY, 2);
			}
		//}
	}
}

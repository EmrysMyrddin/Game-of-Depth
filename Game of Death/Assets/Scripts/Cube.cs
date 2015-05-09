using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour 
{

    public float speed;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveX * speed, moveY * speed, 0.0f);
        GetComponent<Rigidbody>().velocity = movement;
	}
}

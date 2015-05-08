using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

	private float nextTime = 0f;
	public float updateRate =  0.0001f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetAxis ("Vertical") > 0 && Time.time >= nextTime) {
			nextTime = Time.time + updateRate;
			this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + 1f);
		} else if (Input.GetAxis ("Vertical") < 0 && Time.time >= nextTime) {
			nextTime = Time.time + updateRate;
			this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z - 1f);
		}
	}
}

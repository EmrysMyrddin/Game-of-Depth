using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FortressWall : MonoBehaviour {

	int life = 10;
	public Text p;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (life <= 0) {
			Destroy(gameObject);
			SetCountText();
		}
	}

	void SetCountText ()
	{
		p.text = "You Win!";
		Time.timeScale = 0;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Soldat") {
			life -= 2;
			print ("ouch");
		} else if (other.gameObject.tag == "Tank") {
			life -= 1;
			print ("ouch");
		} else if (other.gameObject.tag == "Cavalier") {
			life -= 3;
			print ("ouch");
		}
	}
}
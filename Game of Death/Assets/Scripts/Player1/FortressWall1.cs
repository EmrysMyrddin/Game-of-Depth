using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FortressWall1 : MonoBehaviour {
	
	int life = 10;
	public Text p1;
	public Text p2;
	
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
		p2.text = "You Win!";
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
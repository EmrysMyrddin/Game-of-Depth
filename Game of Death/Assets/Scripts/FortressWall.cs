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
			Animation anim = gameObject.GetComponent("Animation") as Animation;
			anim.wrapMode = WrapMode.Once;
			anim.Play("Take 001");
			SetCountText();
		}
	}

	void SetCountText ()
	{
		p.text = "You Win!";
	}

	void OnTriggerEnter(Collider other) {
		Unit unitScript = other.gameObject.GetComponent ("Unit") as Unit;
		life -= unitScript.attack;
		print ("ouch");
	}
}
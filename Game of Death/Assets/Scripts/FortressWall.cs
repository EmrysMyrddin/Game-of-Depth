using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FortressWall : MonoBehaviour {

	public int life = 10;
	public Text p;

	private bool annimationPlayed = false;

    public Jauge jauge;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (life <= 0 && !annimationPlayed) {
			Animation anim = gameObject.GetComponent("Animation") as Animation;
			anim.wrapMode = WrapMode.Once;
			anim.Play("Take 001");
			SetCountText();
			annimationPlayed = true;
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
        jauge.PerteVie(1);
		//Debug.Break ();
	}
}
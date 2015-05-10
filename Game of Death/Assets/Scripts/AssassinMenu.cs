using UnityEngine;
using System.Collections;

public class AssassinMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Animation anim = gameObject.GetComponent<Animation> ();
		anim.Play ("Take 001");
		anim.Stop ();
		anim ["Take 001"].speed = 0;
		anim ["Take 001"].enabled = true;
		anim ["Take 001"].time = (1f/24f)*18;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
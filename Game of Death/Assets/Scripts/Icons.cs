using UnityEngine;
using System.Collections;

public class Icons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1") &&  GetComponent<Animator>().GetBool("clicked") == false)
        {
           GetComponent<Animator>().SetBool("clicked", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("clicked", false);
        }
        

	}

    
}

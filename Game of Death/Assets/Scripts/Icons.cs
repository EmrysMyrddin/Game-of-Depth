using UnityEngine;
using System.Collections;

public class Icons : MonoBehaviour {

    public Jauge jauge;
    public string button;

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown(button) &&  GetComponent<Animator>().GetBool("clicked") == false)
        {
            jauge.PerteVie(1);   
            GetComponent<Animator>().SetBool("clicked", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("clicked", false);
        }
        

	}

    
}

using UnityEngine;
using System.Collections;

public class Soldat : MonoBehaviour {

    // vie du soldat
    public int life;

    // le temps entre chaque deplacement (entre deux cases)
    public float moveRate;

    // le time du prochain deplacement (entre deux cases)
    private float nextMove;

    // la taille des cases
    public float moveSize;

	void Start () {
	    
	}
	
	
	void Update () {
	    
        // deplacement
        if (Time.time > moveRate)
        {
            // deplacement progressif
            StartCoroutine(Transition(moveSize));


            nextMove = Time.time + moveRate;
        }

    

	}

    private IEnumerator Transition (float moveSize)
	{
		// temps de la transformation
		float transitionDuration = 1.0f;
		float t = 0.0f;
		// position de depart
		Vector3 startingPoint = this.gameObject.transform.position;
        Vector3 finishPoint = new Vector3(startingPoint.x + moveSize, startingPoint.y, startingPoint.z);

		while (t < 1.0f)
		{
			t += Time.deltaTime * (Time.timeScale/transitionDuration);
			this.transform.position = Vector3.Lerp(startingPoint, finishPoint.transform.position, t);
			yield return 0;
		}
	}

/*    void OnTriggerEnter()
    {
        // contacts
        // avec le mur adverse
        if ()
        {

        }
        // avec une unité
        else if ()
        {
            // soldat
            if ()
            {

            }
            // tank
            // fou

        }
        // avec un projectile ?
    }
 */
}

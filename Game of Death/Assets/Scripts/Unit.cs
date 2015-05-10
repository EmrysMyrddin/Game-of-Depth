using UnityEngine;
using System.Collections;
using System;

public class Unit : MonoBehaviour {

	public int modelX, modelY;
	public int direction;
	public int attack;
	public int life;
	public string type;

	private float x,y,z;
	private Model model;
	private bool damagesHandled{ get; set;}
	private bool haveToResolve = false;
	private Unit enemy = null;

	// Use this for initialization
	void Start () {
		model = GameObject.Find ("Plateau").GetComponent("Model") as Model;
		type = gameObject.tag;
		damagesHandled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.layer != 8)
			gameObject.layer = 8;

		x = this.gameObject.transform.position.x;
		y = this.gameObject.transform.position.y;
		z = this.gameObject.transform.position.z;

		float limite = modelX - 15 + 0.01f * -direction;

		x += Time.deltaTime * model.unitAnimationSpeed * direction;

		if ((x >= limite && direction == 1) || (x <= limite && direction == -1)){
			x = modelX - 15;
			if (haveToResolve)
				resolveBattle (enemy);
		}

		gameObject.transform.position = new Vector3 (x, y, z);
	}

	public void move(){
		if (enemy != null)
			haveToResolve = true;
		modelX += direction;
		if (modelX > model.nbColone - 1 || modelX < 0)
			Destroy(gameObject);
	}


	public void rageQuit(){
		print ("RageQuit");
		gameObject.GetComponent<Rigidbody> ().useGravity = true;
		gameObject.GetComponent<Rigidbody> ().AddForceAtPosition (new Vector3 (0, rand (5, 10) * 0.00000001f, 0), gameObject.transform.position, ForceMode.Impulse);
	}

	private int rand(int min, int max){
		System.Random random = new System.Random ();
		return random.Next ();
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Break ();
		print ("Trigger");
		enemy = other.gameObject.GetComponent<Unit>();
		gameObject.GetComponent<Animation> ().Play ("Take 001");
		enemy.gameObject.GetComponent<Animation> ().Play("Take 001");
	}

	void resolveBattle(Unit opposant) {
		// tag opposé
		string tagOp = opposant.gameObject.tag;
		
		print("handled : " + opposant.damagesHandled);
		
		if (!opposant.damagesHandled)
		{
			// si le tag correspond à une unité
			if (tagOp == "Soldat" || tagOp == "Tank" || tagOp == "Cavalier")
			{
				bool everyOneAlive = true;
				
				while (everyOneAlive)
				{
					this.life = this.life - opposant.attack;
					opposant.life = opposant.life - this.attack;
					
					if (opposant.life <= 0)
					{
						everyOneAlive = false;
						Destroy(opposant.gameObject);
					}
					if (this.life <= 0)
					{
						everyOneAlive = false;
						Destroy(this.gameObject);
					}
				}
			}
			
			// indication que les dommages ont été gérés
			damagesHandled = true;
			
		} else {
			opposant.damagesHandled = false;
		}
	}
}
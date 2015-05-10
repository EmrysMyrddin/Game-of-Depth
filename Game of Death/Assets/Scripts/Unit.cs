﻿using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public int modelX, modelY;
	public int direction;
	public int attack;
	public int life;
	public string type;
    private bool damagesHandled { get; set; }
	private float x,y,z;
	private Model model;

	// Use this for initialization
	void Start () {
		model = GameObject.Find ("Plateau").GetComponent("Model") as Model;
		type = gameObject.tag;
        damagesHandled = false;
	}
	
	// Update is called once per frame
	void Update () {
		x = this.gameObject.transform.position.x;
		y = this.gameObject.transform.position.y;
		z = this.gameObject.transform.position.z;

		float limite = (modelX - 15) + 0.01f * -direction;

		if ((x < limite && direction == 1) || (x > limite && direction == -1)){
			x += Time.deltaTime * model.unitAnimationSpeed * direction;
		}
		else
		{
			x = (modelX - 15);
		}
		gameObject.transform.position = new Vector3 (x, y, z);
	}

	public void move(){
		modelX += direction;
		if(modelX > model.nbColone-1 || modelX < 0)
			Destroy(gameObject);
	}


	void OnTriggerEnter(Collider other) {
        
        // tag opposé
		string tagOp = other.gameObject.tag;
        // object opposé
		Unit opposant = other.gameObject.GetComponent<Unit>();

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyParts : MonoBehaviour {

	SnakeMovement SM;

	// Use this for initialization
	void Start () {
		
		SM = GameObject.Find("GameObject").GetComponent<SnakeMovement>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Bullet" && this.gameObject.tag == "BodyPart"){
			SM.RemoveBodyPart ();
			Destroy (gameObject);

		}

	}
}

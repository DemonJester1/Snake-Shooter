using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

	public float bSpeed = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(this.gameObject.transform.position.y >= 5.15f){
			Destroy (this.gameObject);
		}

		transform.Translate (Vector3.up *Time.deltaTime*bSpeed);

	}
	void OnCollisionEnter2D(Collision2D col){

		Destroy (this.gameObject);
	}
}

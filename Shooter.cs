using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject Bullets;
	public float fireRate = 1f;
	float timer;
	Vector2 position;

	// Use this for initialization
	void Start () {
		timer = 1f;
	}
	
	// Update is called once per frame
	void Update () {

		Move ();

		timer -= Time.deltaTime;

		if(timer < 0)
		{
			Instantiate (Bullets,new Vector2(transform.position.x,transform.position.y+0.6f),transform.rotation);
			timer = fireRate;
		}
	
	}

	public void Move()
	{
		/*if(Input.GetAxis("Horizontal") != 0){
			transform.Translate (Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * 3f );
		}*/
		if (Input.touchCount > 0) {
			position.x = (Input.GetTouch (0).position.x - 240f)/(480f/5.2f);
		}
		position = new Vector2 (position.x,transform.position.y);

		transform.position = position;


	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour {

	public List<Transform> BodyParts = new List<Transform>();

	public Shop Shp;

	public float mindistance = 0.25f;

	public int beginsize;
	public int size;

	public float speed = 1;
	public float rotationspeed = 50;

	public GameObject bodyprefab;

	private float dis;
	private Transform curBodyPart;
	private Transform PrevBodypart;

	public int value;

	float timer;
	float timer1;
	bool right;

	Renderer rend;
	Color StartCol;
	float H;
	float S;
	float V;

	// Use this for initialization
	void Start () {

		S = Random.Range (0.5f,1f);
		V = Random.Range (0.5f,1f);
		H = Random.Range (0f,1f);

		right = true;

		timer = Random.Range (0.5f,5f);

		value = 1;

		size = 20;

		for (int i = 0; i < beginsize -1; i++) {
			AddBodyPart ();
		}

		for(int i = 0; i < BodyParts.Count; i++){
			rend = BodyParts [i].GetComponent<Renderer> ();
			rend.material.color = Color.HSVToRGB (H+0.005f*i,V,S);
		}
	}

	// Update is called once per frame
	void Update () {

		Move ();
		if(BodyParts.Count != 0){
		Timer ();
		gameObject.transform.GetChild (0).gameObject.tag = "BodyPart";
		if(BodyParts[BodyParts.Count-1].transform.position.y <= -7f){
				DestroySnake ();
			}
		}
	
		if (BodyParts.Count > 1 && BodyParts [0].position.y > BodyParts [1].position.y) {
			Destroy (gameObject.transform.GetChild (0).gameObject);
		}

		if(BodyParts.Count == 0){
			Transform newpart = (Instantiate(bodyprefab,new Vector3(Random.Range(-3.14f,3.14f),transform.position.y,transform.position.z),transform.rotation) as GameObject).transform;

			newpart.SetParent (transform);

			BodyParts.Add (newpart);

			S = Random.Range (0.7f,1f);
			V = Random.Range (0.7f,1f);
			H = Random.Range (0f,1f);

			for (int i = 0; i < size-1; i++) {
				AddBodyPart ();
				}
			for(int i = 0; i < BodyParts.Count; i++){
				rend = BodyParts [i].GetComponent<Renderer> ();
				rend.material.color = Color.HSVToRGB (H+0.005f*i,V,S);
			}
			}
		}

	public void Move()
	{
		float curspeed = speed;

		if(BodyParts.Count != 0){
			BodyParts [0].Translate (-BodyParts [0].up * curspeed * Time.smoothDeltaTime,Space.World);
		}

//		if (BodyParts.Count != 0)
//			BodyParts [0].Rotate  ();
		if(BodyParts.Count != 0 && right == true){
			BodyParts [0].Translate (BodyParts[0].right*curspeed*Time.deltaTime);
		}
		if(BodyParts.Count != 0 && right == false){
			BodyParts [0].Translate (-BodyParts[0].right*curspeed*Time.deltaTime);
		}

		
		for (int i = 1; i < BodyParts.Count; i++) 
		{
			curBodyPart = BodyParts[i];

			PrevBodypart = BodyParts[i-1];

			dis = Vector3.Distance(PrevBodypart.position, curBodyPart.position);

			Vector3 newpos = PrevBodypart.position;

			newpos.z = BodyParts[0].position.z;

			float T = Time.deltaTime * dis/mindistance*curspeed;

			if(T>0.5f)
				T = 0.5f;

			curBodyPart.position = Vector3.MoveTowards(curBodyPart.position,newpos,T);
			curBodyPart.rotation = Quaternion.RotateTowards(curBodyPart.rotation,PrevBodypart.rotation,T);
		}
	}

	public void AddBodyPart()
	{
		Transform newpart = (Instantiate(bodyprefab,BodyParts[BodyParts.Count-1].position,BodyParts[BodyParts.Count-1].rotation) as GameObject).transform;

		newpart.SetParent (transform);

		BodyParts.Add (newpart);
	}

	public void Timer(){

		timer -= Time.deltaTime;
		if(timer <= 0 && right == true){
			right = false;
			timer = Random.Range (0.5f,5f);
		}else if(timer <= 0 && right == false){
			right = true;
			timer = Random.Range (0.5f,5f);
		}

		if(BodyParts[0].transform.position.x > 3f && right == true){
			right = false;
			timer = Random.Range (0.5f,5f);
		}else if(BodyParts[0].transform.position.x < -3f && right == false){
			right = true;
			timer = Random.Range (0.5f,5f);
		}

	}

	public void RemoveBodyPart(){
		if (BodyParts.Count > 1) {
			BodyParts.RemoveAt (0);
			Destroy (gameObject.transform.GetChild (0).gameObject);
			gameObject.transform.GetChild (1).gameObject.tag = "BodyPart";
			Shp.AddMoney (1);
		} else {
			BodyParts.RemoveAt (0);
			Destroy (gameObject.transform.GetChild (0).gameObject);
			Shp.AddMoney (1);
		}
	}

	public void DestroySnake(){
		if (BodyParts.Count > 1) {
			BodyParts.RemoveAt (0);
			Destroy (gameObject.transform.GetChild (0).gameObject);
		} else {
			BodyParts.RemoveAt (0);
			Destroy (gameObject.transform.GetChild (0).gameObject);
		}
	}
		
}
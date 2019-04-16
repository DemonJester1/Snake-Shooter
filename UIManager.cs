using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Shop Shp;

	public Text fireRateText;
	public Text fireSpeedText;
	public Text lifeText;

	int FRprice;
	int FSprice;
	int Lprice;
	public int price;


	// Use this for initialization
	void Start () {

		FRprice = 10;
		FSprice = 10;
		Lprice = 10;

		fireRateText.text = "" + FRprice;
		fireSpeedText.text = "" + FSprice;
		lifeText.text = "" + Lprice;

	}
	
	// Update is called once per frame
	void Update () {
			
	}

	public void FireRate(){
		if(Shp.currentGold >= FRprice){
			price = FRprice;
			Shp.fireRate += 1;
			PlayerPrefs.SetInt ("FireRate",Shp.fireRate);
			Shp.BuyingShit();
		}
	}
	public void FireSpeed(){
		if(Shp.currentGold >= FSprice){
			price = FSprice;
			Shp.fireSpeed += 1;
			PlayerPrefs.SetInt("FireSpeed",Shp.fireSpeed);
			Shp.BuyingShit();
		}
	}
	public void Lifes(){
		if(Shp.currentGold >= Lprice){
			price = Lprice;
			Shp.life += 1;
			PlayerPrefs.SetInt ("Lifes",Shp.life);
			Shp.BuyingShit();
		}
	}
}

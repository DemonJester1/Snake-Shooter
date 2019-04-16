using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	public int fireRate;
	public int fireSpeed;
	public int life;

	public Text moneyText;
	public int currentGold;

	public UIManager UIM;

	// Use this for initialization
	void Start () {

		if (PlayerPrefs.HasKey ("FireRate")) {
			fireRate = PlayerPrefs.GetInt ("FireRate");
		} else {
			PlayerPrefs.SetInt ("FireRate",1);
		}

		if (PlayerPrefs.HasKey ("FireSpeed")) {
			fireSpeed = PlayerPrefs.GetInt ("FireSpeed");
		} else {
			PlayerPrefs.SetInt ("FireSpeed",1);
		}

		if (PlayerPrefs.HasKey ("Lifes")) {
			life = PlayerPrefs.GetInt ("Lifes");
		} else {
			PlayerPrefs.SetInt ("Lifes",1);
		}	
			
		if (PlayerPrefs.HasKey ("CurrentMoney")) {

			currentGold = PlayerPrefs.GetInt ("CurrentMoney");
		} else {
			currentGold = 0;
			PlayerPrefs.SetInt ("CurrentMoney", 0);
		}

		moneyText.text = "" + currentGold;
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddMoney(int goldToAdd){
		currentGold += goldToAdd;
		PlayerPrefs.SetInt ("CurrentMoney", currentGold);
		moneyText.text = "" + currentGold;
	}

	public void BuyingShit(){
		currentGold -= UIM.price;
		PlayerPrefs.SetInt ("CurrentMoney", currentGold);
		moneyText.text = "" + currentGold;
	}
		
}

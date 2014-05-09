using UnityEngine;
using System.Collections;

public class WeaponValues : MonoBehaviour {

	//Gehört zum Player-Weapon-Trigger

	//Statuswerte der Waffe
	public string weaponName;
	public float damage;
	public float attackCost;
	public float weight;
	public int weaponLevel;
	Collider enemy;

	//fügt einmalig Schaden pro Berührung zu
	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Enemy" || collider.tag == "Boss"){
			Invoke ("DealDamage",0f);
			enemy = collider;
		}
	}

	/*
	void OnTriggerExit(Collider collider){
		if (collider.tag == "Enemy" || collider.tag == "Boss") {
			enemy = collider;
			CancelInvoke("DealDamage");
		}
	}*/
	
	//füge Gegner damage x Schaden zu 
	void DealDamage(){
		enemy.GetComponent<Stats> ().health -= damage;
		CancelInvoke ("DealDamage");
		Debug.Log (collider.name+" was hit by "+transform.name+" for "+damage+" damage.");
	}
}

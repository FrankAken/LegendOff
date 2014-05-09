using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {

	//Gehört zu einem Enemy-Trigger oder einem Enemy-Weapon-Trigger

	public float damage;
	public float damageDealt;
	public float blockDamage;
	public float damageRate;

	//fügt Schaden pro Berührung zu
	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			//Füge Spieler damage x Schaden zu
			damageDealt = damage - Persistent.persist.armorClass;
			Debug.Log (damageDealt+" Damage dealt to "+collider.name+" by "+transform.name);
			InvokeRepeating("DealDamage",0f,damageRate);
		}
	}

	//beende den Invoke und höre auf Schaden zu machen, wenn keine Berührung mehr stattfindet
	void OnTriggerExit(Collider collider){
		if (collider.tag == "Player") {
			CancelInvoke("DealDamage");
		}
	}

	//richte Schaden an
	void DealDamage(){
		//wenn Schaden höher ist als die Rüstungsklasse des Charakters, richte die Differenz an Schaden an
		//110 damage - 100 AC = 10 
		if ( damageDealt > 0f) {
			Persistent.persist.health -= damageDealt ;
		}
		if ( damageDealt <= 0f){
			Debug.Log ("Insufficient Damage");
			Persistent.persist.health -= blockDamage; 
		}
		if (Persistent.persist.health <= 0f) {
			CancelInvoke("DealDamage");
		}
		Debug.Log(transform.name+"'s DealDamage invoked");
	}
}

using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {

	//Gehört zu einem Enemy-Trigger oder einem Enemy-Weapon-Trigger

	public float damage;
	public float attackCost;

	//fügt Schaden pro Berührung zu
	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			//Füge Spieler damage x Schaden zu
			Persistent.persist.health -= damage;
		}
	}
}

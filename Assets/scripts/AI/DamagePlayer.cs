using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {

	//Gehört zu einem Enemy-Trigger oder einem Enemy-Weapon-Trigger

	public float damage;

	//fügt Schaden pro Berührung zu
	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			//Füge Spieler damage x Schaden zu
			float damageDealt = Persistent.persist.armorClass - damage;
			if(damageDealt > 0f ){
				Persistent.persist.health -= damageDealt;
			}
			else if(damageDealt < 0f){
				Persistent.persist.health += damageDealt;
			}
		}
	}
}

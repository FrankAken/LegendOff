using UnityEngine;
using System.Collections;

public class DamageEnemy : MonoBehaviour {

	//Gehört zum Player-Weapon-Trigger
	
	public float damage;
	public float attackCost;

	//fügt Schaden pro Berührung zu
	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Enemy"){
			//füge Gegner damage x Schaden zu 
			collider.GetComponent<Stats>().health -= damage;
		}
	}
}

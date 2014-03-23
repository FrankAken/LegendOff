using UnityEngine;
using System.Collections;

public class DamageEnemy : MonoBehaviour {

	//Is to be applied to a Weapon Trigger
	
	public float damage;
	public float attackCost;
	
	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Enemy"){
			//Deal Damage to Enemy
			collider.GetComponent<Stats>().health -= damage;
		}
	}
}

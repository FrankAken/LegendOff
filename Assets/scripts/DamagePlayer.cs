using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {

	//Is to be applied to a enemys Trigger or a enemys weapon Trigger

	public float damage = 1f;

	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			//Deal Damage to Player
			collider.GetComponent<Stats>().health -= damage;
		}
	}
}

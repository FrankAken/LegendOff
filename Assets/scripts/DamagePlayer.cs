using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {

	public float damage = 1f;
	public float knockback = 100f;

	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			//Deal Damage to Player
			collider.GetComponent<Stats>().health -= 1f;
		}
	}
}

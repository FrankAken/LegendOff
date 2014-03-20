using UnityEngine;
using System.Collections;

public class DamageEnemy : MonoBehaviour {
	
	public float damage = 1f;
	public float knockback = 100f;
	
	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Enemy"){
			transform.parent.transform.renderer.material.color = Color.red;
			//Deal Damage to Enemy
			collider.GetComponent<Stats>().health -= 1f;
		}
	}

	void OnTriggerExit(Collider collider){
		transform.parent.transform.renderer.material.color = Color.white;
	}
}

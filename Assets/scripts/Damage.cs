using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	public float damage = 1f;
	public float knockback = 100f;

	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			//Deal Damage to Player
			collider.GetComponent<Stats>().health -= 1f;
			//Knockback Player
			//collider.rigidbody.AddForce(new Vector3(-1,0,-1));
		}
	}
}

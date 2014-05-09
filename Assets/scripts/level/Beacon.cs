using UnityEngine;
using System.Collections;

public class Beacon : MonoBehaviour {

	//bei Berührung wird der Spawnpunkt des Spielers auf die Position des gameObject gelegt

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player") {
			Persistent.persist.spawn = new Vector3(transform.parent.position.x,Persistent.persist.player.transform.position.y,transform.parent.position.z);
			Persistent.persist.health = Persistent.persist.maxHealth;
			Persistent.persist.stamina = Persistent.persist.maxStamina;
		}
	}
}

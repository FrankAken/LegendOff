using UnityEngine;
using System.Collections;

public class Beacon : MonoBehaviour {

	//bei Berührung wird der Spawnpunkt des Spielers auf die Position des gameObject gelegt

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player") {		
			transform.renderer.material.color = Color.green;
			collider.GetComponent<Stats>().spawn = transform.position;
		}
	}
}

using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player") {		
			Debug.Log ("You rest here");
			transform.renderer.material.color = Color.green;
			collider.GetComponent<Stats>().spawn = transform.position;
		}
	}
}

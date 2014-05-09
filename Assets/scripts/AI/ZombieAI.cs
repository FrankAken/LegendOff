using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

	//AI der Zombies

	public float speed = 0.5f;
	
	void Update () {
		if(transform.parent.GetComponentInChildren<CameraController>().visited){
			Attack();
		}

		if(transform.GetComponent<Stats>().dead){
			Destroy (gameObject);
		}
	}
	
	//bewegt gameObject zu position
	void Attack(){
		Vector3 player = GameObject.FindGameObjectWithTag("Player").transform.position;
		Vector3 attackPosition = new Vector3 (player.x, transform.position.y, player.z);
		transform.position = Vector3.Lerp(transform.position,attackPosition,Time.deltaTime * speed);
		CancelInvoke("Attack");
	}
}

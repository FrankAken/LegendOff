using UnityEngine;
using System.Collections;

public class GuardianAI : MonoBehaviour {

	//AI der Wächter
	
	public float speed = 0.7f;

	void Update () {
		//greift an wenn der Spieler im Raum ist
		if(transform.parent.GetComponentInChildren<CameraController>().visited){
			Attack();
		}

		//ist der Wächter tot, wird sein GameObject zerstört
		if(transform.GetComponent<Stats>().dead){
			Destroy (gameObject);
		}
	}
	
	//attackiere attackPosition
	void Attack(){
		Vector3 player = GameObject.FindGameObjectWithTag("Player").transform.position;
		Vector3 attackPosition = new Vector3 (player.x, transform.position.y, player.z);
		transform.position = Vector3.Lerp(transform.position,attackPosition,Time.deltaTime * speed);
		CancelInvoke("Attack");
	}


}

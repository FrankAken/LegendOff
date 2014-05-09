using UnityEngine;
using System.Collections;

public class LorkhanAI : MonoBehaviour {
	
	//AI von Lorkhan, wird nicht resettet, da Bosse tot bleiben nachdem sie besiegt wurden

	public float speed;
	public float attackDelay;
	Vector3 attackPosition;
	GameObject room;

	void Start(){
		//Position die als Nächstes attackiert werden soll, brauch eigene Höhe des enthaltenden transforms, da sonst Fehler
		attackPosition = transform.position;//new Vector3(transform.parent.position.x,transform.position.y,transform.parent.position.z);
	}

	void Update(){
		//beginne anzugreifen wenn der Bossraum besucht ist
		if(transform.parent.GetComponentInChildren<CameraController> ().visited){
			//schließe die Tür
			transform.parent.GetComponentInChildren<Bossdoor>().closed = true;
			//greift zunächst Raummitte an, danach wird die anzugreifende Position auf die des Spielers gesetzt
			if(transform.position != attackPosition){
				Invoke ("Attack",0f);
			}
			//update anzugreifende Position
			else{
				Invoke ("DetectPlayer",0f);
			}
		}
		else{
			//öffne die Tür wenn der Spieler nicht im Raum ist
			transform.parent.GetComponentInChildren<Bossdoor>().closed = false;
		}

		if (transform.GetComponent<Stats>().dead) {
			Persistent.persist.lorkhanDefeated = true;
			transform.parent.GetComponentInChildren<Bossdoor>().closed = false;
			Destroy(gameObject);
		}
	}
	
	//zeigt verbleibende Lebenspunkte an
	void OnGUI(){	
		if (transform.parent.GetComponentInChildren<CameraController> ().visited) {
			GUI.Box (new Rect (0, 0, Screen.width, 30), "Quickblade Lorkhan : "+GetComponent<Stats> ().health + " / " + GetComponent<Stats> ().maxHealth);
		}
	}

	//Bewege das transform zu position
	void Attack(){
		transform.position = Vector3.MoveTowards (transform.position, attackPosition, Time.deltaTime * speed);
	}

	//finde aktuelle Position des Spielers
	void DetectPlayer(){
		Vector3 player = GameObject.FindGameObjectWithTag("Player").transform.position;
		attackPosition = new Vector3 (player.x, transform.position.y, player.z);
		CancelInvoke("DetectPlayer");
	}
}

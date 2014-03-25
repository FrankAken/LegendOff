using UnityEngine;
using System.Collections;

public class KeyboardControls : MonoBehaviour {

	//Standard Eingabemethode
	//WASD = Bewegung
	//O = laufe wenn gehalten
	//J = greife mit ausgerüsteter Waffe an
	//L = in gesteuerte Richtung ausweichen

	//GameObject player;
	GameObject weaponInstance;

	void Start(){
		//player = GameObject.FindWithTag("Player");
	}

	void Update () {
		CharacterControl();
	}

	//CharacterControls, Tastenbelegung oben
	void CharacterControl(){
		//physikbasierte Bewegung
		//bewege Vorwärts
		if (Input.GetKey(KeyCode.W)) {
			Persistent.persist.moving = true;
			if(Persistent.persist.running){
				rigidbody.AddForce (transform.up * Persistent.persist.speed * Persistent.persist.runMultiplier);
			}
			else{
				rigidbody.AddForce (transform.up * Persistent.persist.speed);
			}
		}
		//bewege Rückwärts
		if (Input.GetKey(KeyCode.S)) {
			Persistent.persist.moving = true;
			if(Persistent.persist.running){
				rigidbody.AddForce (-transform.up * Persistent.persist.speed * Persistent.persist.runMultiplier);
			}
			else{
				rigidbody.AddForce (-transform.up * Persistent.persist.speed);
			}
		}
		//bewege nach rechts
		if (Input.GetKey(KeyCode.D)) {
			Persistent.persist.moving = true;
			if(Persistent.persist.running){
				rigidbody.AddForce (transform.right * Persistent.persist.speed * Persistent.persist.runMultiplier);
			}
			else{
				rigidbody.AddForce (transform.right * Persistent.persist.speed);
			}
		}

		//bewege nach links
		if (Input.GetKey(KeyCode.A)) {	
			Persistent.persist.moving = true;
			if(Persistent.persist.running){
				rigidbody.AddForce (-transform.right * Persistent.persist.speed * Persistent.persist.runMultiplier);
			}
			else{
				rigidbody.AddForce (-transform.right * Persistent.persist.speed);
			}
		}
		//laufe während der Knopf gehalten wird, subtrahiert gewissen Betrag von der Ausdauer pro gewisser Zeiteinheit
		if(Input.GetKeyDown(KeyCode.O)){
			//Renne nur wenn genügend Ausdauer vorhanden
			if(Persistent.persist.stamina > 0){
				Persistent.persist.running = true;
			}
		}

		//höre auf zu laufen, wenn der Knopf nicht mehr gehalten wird
		if(Input.GetKeyUp(KeyCode.O)){
			Persistent.persist.running = false;
		}

		//Schlage mit ausgerüsteter Waffe zu, Waffe bleibt draussen solange der Knopf gehalten wird 
		//Fügt einem Gegner nur einmalig Schaden zu
		if(Input.GetKeyDown(KeyCode.J)){
			strike ();
		}
		//Mache Waffe unsichtbar wenn nicht angegriffen wird
		if (Input.GetKeyUp (KeyCode.J)) {			
			weaponInstance.SetActive (false);
		}
		//Ausweichen, subtrahiert dashCost von der vorhandenen Ausdauer
		//Ist die Ausdauer erschöpft oder negativ ist Ausweichen nicht erlaubt und wird nicht ausgeführt
		if (Input.GetKeyDown (KeyCode.L)) {	
			if(Persistent.persist.stamina > 0){
				Persistent.persist.stamina -= Persistent.persist.dashCost;
				Persistent.persist.speed *= Persistent.persist.dashMultiplier;
				Invoke("ResetSpeed",Persistent.persist.dashDuration);
			}
		}
	}

	//Angriffsmethode
	void strike(){
		if (weaponInstance == null) {
			weaponInstance = (GameObject)Instantiate (Persistent.persist.weapon, gameObject.transform.position, Quaternion.identity);
			weaponInstance.transform.Rotate (90, 0, 90);
		}
		if (Persistent.persist.stamina > 0) {
			Persistent.persist.stamina -= weaponInstance.GetComponent<DamageEnemy> ().attackCost;
			weaponInstance.SetActive (true);
			weaponInstance.transform.parent = gameObject.transform;
			weaponInstance.transform.localPosition = new Vector3 (0.3f, -0.2f, -0.01f);
		}
	}

	//Setze Geschwindigkeit zurück wenn der Spieler nicht mehr läuft
	void ResetSpeed(){
		Persistent.persist.speed /= Persistent.persist.runMultiplier;
	}
}

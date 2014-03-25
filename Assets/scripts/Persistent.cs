using UnityEngine;
using System.Collections;

public class Persistent : MonoBehaviour {
	
	//Speicher in dem Daten abgelegt werden können, die zwischen den Szenen erhalten bleiben sollen

	public static Persistent persist; 
	public GameObject player;
	public GameObject playerInstance;
	//Werte des Spielers
	public string playerName;
	public float health;
	public float stamina;
	public int souls;
	public GameObject weapon;
	//Statusveränderungen
	bool poisoned;
	float poisonDamage;
	float poisonClock;
	bool bleeding;
	float bleedDamage;
	float bleedClock;
	//Backups
	float _health;
	float _stamina;
	int _souls;
	//Werte für Spielerbewegung
	public bool moving;
	public bool running;
	public float runCost;
	public float runClock;
	public float runMultiplier;
	public float dashCost;
	public float dashMultiplier;
	public float dashDuration;
	public float speed;
	public Vector3 spawn;
	//Werte für Weltinteraktion
	public bool interactable;
	public string lastLevel;
	//Kamera-Einstellungen
	public float camHeight;
	public float camSpeed;

	void Awake(){
		//wenn persist leer ist, dann mache aus DIESEM gameObject persist
		if (persist == null) {
			DontDestroyOnLoad (gameObject);
			persist = this;
		} 

		//wenn persist existiert, dann zerstöre DIESES gameObject und lasse persist unverändert
		else if(persist != this){
			Destroy(gameObject);
		}
	}

	void Start(){
		//erstelle Spielerinstanz an spawn
		playerInstance = (GameObject)Instantiate (player, spawn, Quaternion.identity);
		//drehen, damit der Charakter auch sichtbar ist
		playerInstance.transform.Rotate (90, 0, 0);
	}

	void Update(){
		//wenn der Spieler stirbt, lasse Seelen auf den Boden fallen, setze Spielerseelen auf 0 
		//dann zerstöre die Spielerinstanz und erzeuge neue Spielerinstanz an spawn
		if(health <= 0){
			Instantiate(Resources.Load("Drop"),GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
			souls = 0;
			Destroy (playerInstance);
			playerInstance = (GameObject)Instantiate (player, spawn, Quaternion.identity);
		}

		//Verletze den Spieler um poisonDamage alle poisonClock x Sekunden
		/*if(poisoned){
			gameObject.transform.renderer.material.color = Color.green;
			health -= poisonDamage;
		}*/
		
		//Verletze den Spieler um bleedDamage alle bleedClock x Sekunden
		/*if(bleeding){
			gameObject.transform.renderer.material.color = Color.red;
			health -= bleedDamage;
		}*/

		//eschöpfe den Ausdauervorrat nur wenn gerannt UND gelaufen wird (also NICHT im stehen)
		//um runCost alle runClock x Sekunden
		if (running && moving) {
			InvokeRepeating("RunExhaustion",0f,runClock);
		}

		//wenn nicht gerannt wird, beende auch die Ausdauer zu erschöpfen
		if (!running) {
			CancelInvoke("RunExhaustion");
		}

		//wenn die Ausdauer erschöpft ist, höre auf zu rennen
		if (stamina <= 0) {
			running = false;
		}

		moving = false;
	}

	//erschöpft die Ausdauer einmalig um runCost
	void RunExhaustion(){
		stamina -= runCost;
	}
}

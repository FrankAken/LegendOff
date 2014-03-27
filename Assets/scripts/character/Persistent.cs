using UnityEngine;
using System.Collections;

public class Persistent : MonoBehaviour {
	
	//Speicher in dem Daten abgelegt werden können, die zwischen den Szenen erhalten bleiben sollen

	//zum globalen Zugriff auf die Eigenschaften von persist
		public static Persistent persist; 

	//der Spieler
		public GameObject player;

	//Werte des Spielers
		//Name
		public string playerName;
		//aktuelle Lebenskraft
		public float health;
		//maximale Lebenskraft
		public float maxHealth;
		//aktuelle Ausdauer
		public float stamina;
		//maximale Ausdauer
		public float maxStamina;
		//Wert um den sich die Ausdauer bei Ruhe regeneriert alle regenClock x Sekunden
		public float recoveryRate;
		//Takt in Sekunden in den sich die Ausdauer um recoveryRate erhöht
		public float regenClock;
		//Verzögerung nach der die Ausdauerregeneration ausgeführt wird
		public float regenDelay;
		//gesammelte Seelen
		public int souls;
		//ausgerüstete Waffe
		public GameObject weapon;
		//ausgerüsteter Helm
		public GameObject helmet;
		//ausgerüstete Körperrüstung
		public GameObject cuirass;
		//ausgerüstete Hosen
		public GameObject trousers;
		//ausgerüstete Schuhe
		public GameObject boots;
		//gesamte Rüstungsklasse des Charakters
		public float armorClass;

	//Statusveränderungen
		//ist der Charakter vergiftet?
		bool poisoned;
		//Schaden der vom Gift alle poisonClock x Sekunden angerichtet wird
		float poisonDamage;
		//alle poisonClock x Sekunden wird einmal poisonDamage angerichtet
		float poisonClock;
		//blutet der Charakter?
		bool bleeding;
		//Schaden der vom Bluten alle bleedClock x Sekunden angerichtet wird
		float bleedDamage;
		//alle bleedClock x Sekunden wird einmal bleedDamage angerichtet
		float bleedClock;

	//Werte für Spielerbewegung
		//bewegt sich der Charakter?
		public bool moving;
		//rennt der Charakter?
		public bool running;
		public float runCost;
		public float runClock;
		public float runMultiplier;
		public float dashCost;
		public float dashMultiplier;
		public float dashDuration;
		public float speed;
		public Vector3 spawn;

	//Backups
		float _speed;

	//Werte für Weltinteraktion
		public bool interactable;
		public string lastLevel;

	//Kamera-Einstellungen
		public float camHeight;
		public float camSpeed;

	//Instanzen
		GameObject playerInstance;
		GameObject armorInstance;

	//Physik
		//beeinflusst wie stark das Gewicht der Rüstung sich auf die physikalische Masse auswirkt
		public float armorDivider;

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
		_speed = speed;
		//erstelle Spielerinstanz an spawn
		playerInstance = (GameObject)Instantiate (player, spawn, Quaternion.identity);
		//Erstelle Instanz der ausgerüsteten Rüstung
		armorInstance = (GameObject)Instantiate (cuirass, gameObject.transform.position, Quaternion.identity);
		armorInstance.transform.position = new Vector3(playerInstance.transform.position.x,playerInstance.transform.position.y,playerInstance.transform.position.z - 0.01f);
		armorInstance.transform.parent = playerInstance.transform;
		//drehen, damit der Charakter auch sichtbar ist
		playerInstance.transform.Rotate (90, 0, 0);
	}

	void Start(){
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
			CancelInvoke("StaminaRegeneration");
			InvokeRepeating("StaminaExhaustion",0f,runClock);
		}

		//wenn nicht gerannt wird, beende auch die Ausdauer zu erschöpfen
		if (!running) {
			CancelInvoke("StaminaExhaustion");
			if(stamina < maxStamina){
				InvokeRepeating("StaminaRegeneration",regenDelay,regenClock);
			}
			else{
				CancelInvoke("StaminaRegeneration");
				stamina = maxStamina;
			}
		}

		//wenn die Ausdauer erschöpft ist, höre auf zu rennen
		if (stamina <= 0) {
			running = false;
		}

		moving = false;
	}

	//erschöpft die Ausdauer einmalig um runCost
	void StaminaExhaustion(){
		stamina -= runCost;
	}

	void StaminaRegeneration(){
		stamina += recoveryRate;
	}

	public float getSpeedBackup(){
		return _speed;
	}
}

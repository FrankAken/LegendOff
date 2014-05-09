using UnityEngine;
using System.Collections;

public class Persistent : MonoBehaviour {
	
	//Speicher in dem Daten abgelegt werden können, die zwischen den Szenen erhalten bleiben sollen

	//zum globalen Zugriff auf die Eigenschaften von persist
		public static Persistent persist; 

	//der Spieler
		public GameObject player;
		GameObject drop;
		public int deathCounter;

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
		public int ViewDir;

	//Backups
		float _speed;

	//Kamera-Einstellungen
		public Camera playerCamera;
		public float camHeight;
		public float camSpeed;

	//Prefabs
		public GameObject dropPrefab;
	//Instanzen
		public GameObject playerInstance;
		public GameObject weaponInstance;
		public GameObject cuirassInstance;

	//Physik
		//beeinflusst wie stark das Gewicht der Rüstung sich auf die physikalische Masse auswirkt
		public float weightDivider;

	//Welche Bosse sind besiegt?		
		//Tür zum letzten Boss öffnet sich erst, wenn die beiden ersten besiegt sind
		public bool lorkhanDefeated = false;
		public bool oldKnightDefeated = false;
		//Tür zum letzten Raum öffnet sich nur, wenn alle Bosse besiegt wurden
		public bool queenDefeated = false;

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
		//Backup von speed
		_speed = speed;
		SpawnPlayer ();
	}

	void Update(){
		//wenn der Spieler stirbt, lasse Seelen auf den Boden fallen, setze Spielerseelen auf 0 
		//dann zerstöre die Spielerinstanz und erzeuge neue Spielerinstanz an spawn
		if(health <= 0){
			Invoke("SoulsDropped",0f);
			deathCounter += 1;
			Destroy (playerInstance);
			SpawnPlayer();
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

		//ändert die Position und Rotation der Waffe basierend auf der Richtungstaste die während einem Angriff gedrückt ist
		switch(ViewDir){
		//bei Angriff nach oben
		case 1:	
			if(weaponInstance != null){
				weaponInstance.transform.localPosition = new Vector3 (2.1f, -0.2f, -0.1f);
				weaponInstance.transform.localRotation = Quaternion.identity;
				weaponInstance.transform.Rotate(0,0,270);
			}
			break;
		//bei Angriff nach rechts
		case 3:
			if(weaponInstance != null){
				weaponInstance.transform.localPosition = new Vector3 (2.1f, -0.2f, -0.1f);
				weaponInstance.transform.localRotation = Quaternion.identity;
				weaponInstance.transform.Rotate(0,0,180);
			}
			break;
		//bei Angriff nach unten
		case 5:
			if(weaponInstance != null){
				weaponInstance.transform.localPosition = new Vector3 (2.1f, -0.2f, -0.1f);
				weaponInstance.transform.localRotation = Quaternion.identity;
				weaponInstance.transform.Rotate(0,0,90);
			}
			break;
		//bei Angriff nach links
		case 7:
			if(weaponInstance != null){
				weaponInstance.transform.localPosition = new Vector3 (-2.1f, -0.2f, -0.1f);
				weaponInstance.transform.localRotation = Quaternion.identity;
				weaponInstance.transform.Rotate(0,0,360);
			}
			break;
		//bei Angriff während dem Stehen
		default:
			if(weaponInstance != null){
				weaponInstance.transform.localPosition = new Vector3 (2.1f, -0.2f, -0.1f);
				weaponInstance.transform.localRotation = Quaternion.identity;
				weaponInstance.transform.Rotate(0,0,90);
			}
			break;
		}

		//Basiswerte für Dynamik
		moving = false;
		ViewDir = 0;
	}

	//erschöpft die Ausdauer einmalig um runCost
	void StaminaExhaustion(){
		stamina -= runCost;
	}

	//regeneriert die Ausdauer einmalig um recoveryRate
	void StaminaRegeneration(){
		stamina += recoveryRate;
	}

	//um speed zurücksetzen zu können
	public float getSpeedBackup(){
		return _speed;
	}

	//wird aufgerufen nach Waffen-Upgrade, löscht die alte Instanz und erstellt eine neue, geupgradete an deren Stelle
	public void UpdateWeapon(){
		Destroy(weaponInstance);		
		weaponInstance = (GameObject)Instantiate (weapon, gameObject.transform.position, Quaternion.identity);
		weaponInstance.transform.parent = playerInstance.transform;		
		weaponInstance.transform.localPosition = new Vector3 (0.3f, -0.2f, -0.01f);
		weaponInstance.transform.Rotate (90, 0, 90);
		weaponInstance.SetActive (false);
	}

	//wird aufgerufen nach Kürass-Upgrade, löscht die alte Instanz und erstellt eine neue, geupgradete an deren Stelle
	public void UpdateCuirass(){
		Destroy (cuirassInstance);
		cuirassInstance = (GameObject)Instantiate (cuirass, gameObject.transform.position, Quaternion.identity);
		cuirassInstance.transform.parent = playerInstance.transform;
		cuirassInstance.transform.localPosition = new Vector3 (0,0, -0.01f);
		cuirassInstance.transform.Rotate (90, 0, 0);
	}

	void SoulsDropped(){	
		if(drop == null){
			drop = (GameObject)Instantiate(dropPrefab,GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
			drop.transform.Rotate(90,0,0);
			drop.GetComponent<DroppedPosessions>().StoreSouls(souls);
		}
		souls = 0;
		CancelInvoke("SoulsDropped");
	}

	void SpawnPlayer(){			
		health = maxHealth;
		stamina = maxStamina;
		//erstelle Spielerinstanz an spawn
		playerInstance = (GameObject)Instantiate (player, spawn, Quaternion.identity);
		//Erstelle Instanz der ausgerüsteten Waffe
		weaponInstance = (GameObject)Instantiate (weapon, gameObject.transform.position, Quaternion.identity);
		weaponInstance.transform.parent = playerInstance.transform;		
		weaponInstance.transform.localPosition = new Vector3 (2.1f, -0.2f, -0.1f);
		weaponInstance.transform.Rotate (0, 0, 90);
		weaponInstance.SetActive (false);
		//Erstelle Instanz der ausgerüsteten Rüstung
		cuirassInstance = (GameObject)Instantiate (cuirass, gameObject.transform.position, Quaternion.identity);
		cuirassInstance.transform.parent = playerInstance.transform;
		cuirassInstance.transform.localPosition = new Vector3 (0,0, -0.01f);
		//drehen, damit der Charakter auch sichtbar ist
		playerInstance.transform.Rotate (90, 0, 0);
	}
}

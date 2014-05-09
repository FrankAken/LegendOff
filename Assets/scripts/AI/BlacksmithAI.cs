using UnityEngine;
using System.Collections;

public class BlacksmithAI : MonoBehaviour {

	//AI für den Schmied, der für den Spieler gegen Seelen dessen Ausrüstung aufwertet

	bool inRange;
	public GameObject upgrade;
	string dialog;
	GameObject upgradeInstance;

	void Start(){
		inRange = false;
		dialog = "Hello " + Persistent.persist.playerName + ", would you like me to take a look over your equipment?";
	}

	void OnTriggerEnter(Collider collider){
		//Spieler ist in der Nähe des Schmieds
		if (collider.tag == "Player") {
			inRange = true;
		}
	}

	void OnTriggerExit(Collider collider){
		//Spieler ist nicht in der Nähe des Schmieds
		if (collider.tag == "Player") {
			inRange = false;
		}
	}

	void OnGUI(){
		//zeige Dialog wenn der Spieler in der Nähe ist
		if (inRange && upgradeInstance == null) {
			GUI.Box (new Rect (0, 0, Screen.width, 30), dialog);
		}
	}

	void Update(){		
		//wenn der Spieler in der Nähe des Schmieds ist, kommt er durch Drücken von I zum Upgrade-Menü
		if (Input.GetKey (KeyCode.I) && inRange && upgradeInstance == null) {
			upgradeInstance = (GameObject)Instantiate (upgrade, new Vector3(0.5f,0.5f,0.5f), Quaternion.identity);
		} 
		//verlässt der Spieler den Range-Collider des Schmieds, wird das Upgrade-Menu wieder geschlossen
		else if (!inRange) {
			Destroy(upgradeInstance);
		}
	}
}

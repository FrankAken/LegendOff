using UnityEngine;
using System.Collections;

public class BlacksmithAI : MonoBehaviour {

	//AI für den Schmied, der für den Spieler gegen Seelen dessen Ausrüstung aufwertet

	bool inRange;

	void Start(){
		inRange = false;
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player") {
			inRange = true;
		}
	}

	void OnTriggerExit(Collider collider){
		if (collider.tag == "Player") {
			inRange = false;
		}
	}

	void OnGUI(){
		if (inRange) {
			Persistent.persist.interactable = true;
			GUI.Box (new Rect (0,Screen.height - 30, Screen.width, 30), "Hello "+Persistent.persist.playerName+", would you like me to take a look over your equipment?");
		}
	}

	void Update(){		
		//wenn der Spieler in der Nähe des Schmieds ist, wechselt er durch Drücken von I in das Upgrad-Menü
		if (Input.GetKey (KeyCode.I) && Persistent.persist.interactable) {
			Persistent.persist.lastLevel = Application.loadedLevelName;
			Application.LoadLevel("upgrading");
		}
	}
}

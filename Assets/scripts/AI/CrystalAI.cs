using UnityEngine;
using System.Collections;

public class CrystalAI : MonoBehaviour {

	bool inRange;
	string dialog;

	// Use this for initialization
	void Start () {
		inRange = false;
		dialog = "Congratulations, "+Persistent.persist.playerName+", you have finished the game.";
	}
	
	void OnTriggerEnter(Collider collider){
		//Spieler ist in der Nähe des Kristalls
		if (collider.tag == "Player") {
			inRange = true;
		}
	}
	
	void OnTriggerExit(Collider collider){
		//Spieler ist nicht in der Nähe des Kristalls
		if (collider.tag == "Player") {
			inRange = false;
		}
	}
	
	void OnGUI(){
		//zeige Dialog wenn der Spieler in der Nähe ist
		if (inRange) {
			GUI.Box (new Rect (0, 0, Screen.width, 30), dialog);
			Invoke ("LoadMainMenu",5f);
		}
	}

	void Update(){
		if (Persistent.persist.lorkhanDefeated && Persistent.persist.oldKnightDefeated && Persistent.persist.queenDefeated) {
			transform.parent.GetComponentInChildren<Bossdoor> ().closed = false;
		}
		else{
			transform.parent.GetComponentInChildren<Bossdoor>().closed = true;
		}
	}

	void LoadMainMenu(){
		Application.LoadLevel("MainMenu");
		CancelInvoke("LoadMainMenu");
	}
}

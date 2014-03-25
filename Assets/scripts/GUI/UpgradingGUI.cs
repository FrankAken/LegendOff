using UnityEngine;
using System.Collections;

public class UpgradingGUI : MonoBehaviour {

	void OnGUI(){
		GUI.Box (new Rect (0, 0, Screen.width, Screen.height),"");
	}

	void Update(){
		//durch Escape kommt der Spieler zurück in die letzte Szene
		if (Input.GetKey (KeyCode.Escape)) {
			Application.LoadLevel(Persistent.persist.lastLevel);
		}
	}
}

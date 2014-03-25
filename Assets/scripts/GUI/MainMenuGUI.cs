using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

	//GUI für das Hauptmenü

	float widthCenter, heightCenter;
	void Awake () {
		widthCenter = Screen.currentResolution.width / 2f;
		heightCenter = Screen.currentResolution.height / 2f; 
	}

	void OnGUI () {
	}

	void Update(){
		if (Input.GetKey (KeyCode.Return)) {
			Application.LoadLevel("testing");
		}
	}
}

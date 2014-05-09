using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

	//GUI für das Hauptmenü
	public string load;

	void Update(){
		if (Input.GetKey (KeyCode.Return)) {
			Application.LoadLevel(load);
		}
	}
}

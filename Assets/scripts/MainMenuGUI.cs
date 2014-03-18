using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

	float widthCenter, heightCenter;
	
	// Use this for initialization
	void Awake () {
		widthCenter = Screen.currentResolution.width / 2f;
		heightCenter = Screen.currentResolution.height / 2f; 
		
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.Label(new Rect(widthCenter - 50, heightCenter, 100, 20),"Press Start");
	}
}

using UnityEngine;
using System.Collections;

public class GamepadControls : MonoBehaviour {

	//Steuerung wenn ein Gamepad verbunden ist und in den Optionen aktiviert ist

	GameObject player;

	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		CharacterControl();
	}

	void CharacterControl(){
	}
}

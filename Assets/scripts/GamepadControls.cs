using UnityEngine;
using System.Collections;

public class GamepadControls : MonoBehaviour {

	GameObject player;
	// Use this for initialization
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

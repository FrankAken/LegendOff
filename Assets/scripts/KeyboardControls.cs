using UnityEngine;
using System.Collections;

public class KeyboardControls : MonoBehaviour {

	GameObject player;
	// Use this for initialization
	void Start(){
		player = GameObject.FindWithTag("Player");
	}

	// Update is called once per frame, deltaTime varies
	void Update () {
		CharacterControl();
	}

	void CharacterControl(){
		//physicsbased Movement
		if (Input.GetKey(KeyCode.W)) {
			//move forwards and set View Direction
			player.GetComponent<Stats>().viewDir = 1;
			if(player.GetComponent<Stats>().running){
				rigidbody.AddForce (transform.up * player.GetComponent<Stats>().speed * 2f);
			}
			else{
				rigidbody.AddForce (transform.up * player.GetComponent<Stats>().speed);
			}
		}

		if (Input.GetKey(KeyCode.S)) {
			//move backwards
			if(player.GetComponent<Stats>().running){
				rigidbody.AddForce (-transform.up * player.GetComponent<Stats>().speed * 2f);
			}
			else{
				rigidbody.AddForce (-transform.up * player.GetComponent<Stats>().speed);
			}
		}

		if (Input.GetKey(KeyCode.D)) {		
			//move right
			if(player.GetComponent<Stats>().running){
				rigidbody.AddForce (transform.right * player.GetComponent<Stats>().speed * 2f);
			}
			else{
				rigidbody.AddForce (transform.right * player.GetComponent<Stats>().speed);
			}
		}

		if (Input.GetKey(KeyCode.A)) {	
			//move left
			if(player.GetComponent<Stats>().running){
				rigidbody.AddForce (-transform.right * player.GetComponent<Stats>().speed * 2f);
			}
			else{
				rigidbody.AddForce (-transform.right * player.GetComponent<Stats>().speed);
			}
		}

		if(Input.GetKey(KeyCode.I)){
			//Inventory
		}

		if(Input.GetKey(KeyCode.K)){
			//Block
		}

		if(Input.GetKey(KeyCode.L)){
			//Dodge
		}

		if(Input.GetKey(KeyCode.J)){
			strike ();
		}
		if(Input.GetKey(KeyCode.R)){
			//Reset Player
			player.GetComponent<Stats>().Reset();
		}
		if(Input.GetKeyDown(KeyCode.O)){
			//Run when pressed
			player.GetComponent<Stats>().running = true;
		}
		if(Input.GetKeyUp(KeyCode.O)){
			//stop running when not pressed
			player.GetComponent<Stats>().running = false;
		}
		if(Input.GetKey(KeyCode.P)){
		}
	}

	void strike(){
		Debug.Log("Strike!");

	}
}

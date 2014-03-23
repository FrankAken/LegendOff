using UnityEngine;
using System.Collections;

public class KeyboardControls : MonoBehaviour {

	//Standard Input Method
	//WASD = Movement
	//O = run while pressed
	//J = Attack with equipped Weapon
	//L = Dash (to evade)

	float weaponAngle;
	GameObject player, weaponInstance;
	// Use this for initialization
	void Start(){
		player = GameObject.FindWithTag("Player");
	}

	// Update is called once per frame, deltaTime varies
	void Update () {
		CharacterControl();
	}

	//CharacterControls, Keymapping above
	void CharacterControl(){
		//physicsbased Movement
		if (Input.GetKey(KeyCode.W)) {
			//move forwards and set View Direction
			player.GetComponent<Stats>().viewDir = 1;
			player.GetComponent<Stats>().moving = true;
			if(player.GetComponent<Stats>().running){
				rigidbody.AddForce (transform.up * player.GetComponent<Stats>().speed * 2f);
			}
			else{
				rigidbody.AddForce (transform.up * player.GetComponent<Stats>().speed);
			}
		}

		if (Input.GetKey(KeyCode.S)) {
			//move backwards
			player.GetComponent<Stats>().moving = true;
			if(player.GetComponent<Stats>().running){
				rigidbody.AddForce (-transform.up * player.GetComponent<Stats>().speed * 2f);
			}
			else{
				rigidbody.AddForce (-transform.up * player.GetComponent<Stats>().speed);
			}
		}

		if (Input.GetKey(KeyCode.D)) {		
			//move right
			player.GetComponent<Stats>().moving = true;
			if(player.GetComponent<Stats>().running){
				rigidbody.AddForce (transform.right * player.GetComponent<Stats>().speed * 2f);
			}
			else{
				rigidbody.AddForce (transform.right * player.GetComponent<Stats>().speed);
			}
		}

		if (Input.GetKey(KeyCode.A)) {	
			//move left
			player.GetComponent<Stats>().moving = true;
			if(player.GetComponent<Stats>().running){
				rigidbody.AddForce (-transform.right * player.GetComponent<Stats>().speed * 2f);
			}
			else{
				rigidbody.AddForce (-transform.right * player.GetComponent<Stats>().speed);
			}
		}

		//Run while Button is pressed, detracts certain amount of Stamina while running;
		if(Input.GetKeyDown(KeyCode.O)){
			//Run when pressed and if stamina allows
			if(player.GetComponent<Stats>().stamina > 0){
				player.GetComponent<Stats>().running = true;
			}
		}

		//Stop running when Key is not longer pressed
		if(Input.GetKeyUp(KeyCode.O)){
			//stop running when not pressed
			player.GetComponent<Stats>().running = false;
			//CancelInvoke("RunExhaustion");
		}

		//Strike with equipped Weapon. Weapon is out as long as Button is pressed. 
		//Does Damage only once when a Enemy touches the Weapon.
		if(Input.GetKeyDown(KeyCode.J)){
			strike ();
		}

		if (Input.GetKeyUp (KeyCode.J)) {			
			weaponInstance.SetActive (false);
		}

		//Dash, subtracts Value of dashCost from total Stamina. 
		//When the Stamina is Zero or lower, Dashing is not allowed and will not be executed
		if (Input.GetKeyDown (KeyCode.L)) {	
			if(player.GetComponent<Stats>().stamina > 0){
				player.GetComponent<Stats>().stamina -= player.GetComponent<Stats>().dashCost;
				player.GetComponent<Stats>().speed *= player.GetComponent<Stats>().dashMultiplier;
				Invoke("ResetSpeed",player.GetComponent<Stats>().dashDuration);
			}
		}
	}

	//Attack with Weapon
	void strike(){
		if (weaponInstance == null) {
			weaponInstance = (GameObject)Instantiate (player.GetComponent<Stats> ().weapon, player.transform.position, Quaternion.identity);
			weaponInstance.transform.Rotate (90, 0, 90);
		}
		if (player.GetComponent<Stats> ().stamina > 0) {
			player.GetComponent<Stats> ().stamina -= weaponInstance.GetComponent<DamageEnemy> ().attackCost;
			weaponInstance.SetActive (true);
			weaponInstance.transform.parent = player.transform;
			weaponInstance.transform.localPosition = new Vector3 (0.3f, -0.2f, -0.01f);
		}
	}

	//Reset Speed when the player is NOT longer running
	void ResetSpeed(){
		player.GetComponent<Stats> ().speed = player.GetComponent<Stats> ()._speed;
	}

	//Drain Stamina while Running
	void RunExhaustion(){
		player.GetComponent<Stats> ().stamina -= player.GetComponent<Stats> ().runCost;
	}
}

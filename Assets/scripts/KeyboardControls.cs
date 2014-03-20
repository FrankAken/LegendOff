using UnityEngine;
using System.Collections;

public class KeyboardControls : MonoBehaviour {

	float weaponAngle;

	GameObject player, weaponInstance;
	public float weaponSwingSpeed = 1f;
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

		//Run while Button is pressed, detracts certain amount of Stamina while running;
		if(Input.GetKeyDown(KeyCode.O)){
			//Run when pressed and if stamina allows
			if(player.GetComponent<Stats>().stamina > 0){
				player.GetComponent<Stats>().running = true;
			}
		}

		/*if(Input.GetKey (KeyCode.O)) {
			if(player.GetComponent<Stats>().running == true){
				InvokeRepeating("RunExhaustion",0f,1f);
			}
		}*/

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

		if(Input.GetKey(KeyCode.I)){
			//Inventory
		}

		if(Input.GetKey(KeyCode.K)){
			//Block
		}
		if(Input.GetKey(KeyCode.R)){
			//Reset Player
			player.GetComponent<Stats>().Reset();
		}
		if(Input.GetKey(KeyCode.P)){
		}
	}

	void strike(){
		Debug.Log("Strike!");
		if (weaponInstance == null) {
			weaponInstance = (GameObject)Instantiate (player.GetComponent<Stats> ().weapon, player.transform.position, Quaternion.identity);
			weaponInstance.transform.Rotate (90, 0, 90);
		}
		weaponInstance.SetActive(true);
		weaponInstance.transform.parent = player.transform;
		weaponInstance.transform.localPosition = new Vector3 (0.3f, -0.2f, -0.01f);
	}

	void ResetSpeed(){
		player.GetComponent<Stats> ().speed = player.GetComponent<Stats> ()._speed;
	}

	void RunExhaustion(){
		player.GetComponent<Stats> ().stamina -= player.GetComponent<Stats> ().runCost;
	}
}

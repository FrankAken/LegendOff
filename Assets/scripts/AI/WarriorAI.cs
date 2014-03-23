using UnityEngine;
using System.Collections;

public class WarriorAI : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(transform.parent.GetComponent<RoomController>().visited){
			MoveTo(DetectPlayer());
		}
	}

	//Returns current position of the player
	Vector3 DetectPlayer(){
		Vector3 player = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
		return player;
	}

	//Moves gameObject to specified location 
	void MoveTo(Vector3 position){
		transform.position = Vector3.Lerp(transform.position,position,Time.deltaTime);
	}

	//Resets Stats of the Warrior
	public void Reset(){
		transform.position = gameObject.GetComponent<Stats>().spawn;
		//Debug.Log (transform.name+" was resetted.");
	}
}

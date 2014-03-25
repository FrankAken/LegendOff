using UnityEngine;
using System.Collections;

public class WarriorAI : MonoBehaviour {

	//AI des Warrior-Gegners

	void Update () {
		if(transform.parent.GetComponent<RoomController>().visited){
			MoveTo(DetectPlayer());
		}
	}

	//gibt aktuelle Position des Spielers zurück
	Vector3 DetectPlayer(){
		Vector3 player = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
		return player;
	}

	//bewegt gameObject zu position
	void MoveTo(Vector3 position){
		transform.position = Vector3.Lerp(transform.position,position,Time.deltaTime);
	}

	//setze Stats des Gegners zurück
	public void Reset(){
		transform.position = gameObject.GetComponent<Stats>().spawn;
		//Debug.Log (transform.name+" was resetted.");
	}
}

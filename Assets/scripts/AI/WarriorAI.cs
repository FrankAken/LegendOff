using UnityEngine;
using System.Collections;

public class WarriorAI : MonoBehaviour {

	public Vector3 origPos;

	void Start(){
		origPos = transform.position;
	}
	// Update is called once per frame
	void Update () {
		if(transform.parent.GetComponent<RoomController>().visited){
			MoveTo(DetectPlayer());
		}
	}

	Vector3 DetectPlayer(){
		Vector3 player = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
		return player;
	}

	void MoveTo(Vector3 position){
		transform.position = Vector3.Lerp(transform.position,position,Time.deltaTime);
	}

	/*void Attack(){
	}*/

	public void Reset(){
		transform.position = origPos;
		Debug.Log (transform.name+" was resetted.");
	}
}

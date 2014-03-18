using UnityEngine;
using System.Collections;

public class CameraController: MonoBehaviour {
	//supposedly a Component of the Tile-Collider
	public Camera playerCamera;
	public float camHeight = 6f;
	public float camSpeed;
	bool visited = false;

	void Start(){
		Vector3 playerPos = GameObject.FindWithTag("Player").gameObject.transform.position;
		playerCamera.transform.position = new Vector3(playerPos.x,camHeight,playerPos.z);
		camSpeed = GameObject.FindWithTag("Player").GetComponent<Stats>().speed;
	}

	void Update(){
		if(visited){
			Vector3 nextPos = new Vector3(transform.position.x,camHeight,transform.position.z);
			playerCamera.transform.position = Vector3.MoveTowards(playerCamera.transform.position,nextPos,Time.deltaTime*camSpeed);
		}

	}

	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			visited = true;
			transform.parent.GetComponent<RoomController>().visited = true;
		}
	}

	void OnTriggerExit(Collider collider){
		if(collider.tag == "Player"){
			visited = false;
			transform.parent.GetComponent<RoomController>().visited = false;
			transform.parent.GetComponent<RoomController>().Reset();
		}
	}
}

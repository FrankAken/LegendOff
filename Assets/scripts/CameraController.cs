using UnityEngine;
using System.Collections;

public class CameraController: MonoBehaviour {

	//Kontrolliert die Kamerabewegung und stellt fest ob der Raum auf den die Kamera zeigt besucht ist oder nicht (vom Spieler)

	public Camera playerCamera;
	float camHeight;
	float camSpeed;
	Vector3 playerPos;
	GameObject player;
	bool visited = false;

	void Start(){
		camHeight = Persistent.persist.camHeight;
		camSpeed = Persistent.persist.camSpeed;
		player = GameObject.FindWithTag ("Player");
		playerPos = player.gameObject.transform.position;
		playerCamera.transform.position = new Vector3(playerPos.x,camHeight,playerPos.z);
	}

	void Update(){
		//Bewegt die Kamera auf besuchten Raum
		if(visited){
			Vector3 nextPos = new Vector3(transform.position.x,camHeight,transform.position.z);
			//Interpoliert die Punkte zwischen Anfangspunkt und Endpunkt der Kamerabewegung (Kamerafahrt)
			playerCamera.transform.position = Vector3.MoveTowards(playerCamera.transform.position,nextPos,Time.deltaTime*camSpeed);
		}

	}

	//setzt den Raum als besucht, wenn der Spieler in den Collider eindringt und meldet dies an den RoomController weiter
	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			visited = true;
			transform.parent.GetComponent<RoomController>().visited = true;
		}
	}

	//setzt den Raum als unbesucht, wenn der Spieler den Raum verlässt und meldet dies an den RoomController weiter,
	//setzt außerdem den Raum zurück
	void OnTriggerExit(Collider collider){
		if(collider.tag == "Player"){
			visited = false;
			transform.parent.GetComponent<RoomController>().visited = false;
			transform.parent.GetComponent<RoomController>().Reset();
		}
	}
}

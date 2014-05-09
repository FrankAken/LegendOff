using UnityEngine;
using System.Collections;

public class CameraController: MonoBehaviour {

	//Kontrolliert die Kamerabewegung und stellt fest ob der Raum auf den die Kamera zeigt besucht ist oder nicht (vom Spieler)

	Camera playerCamera;
	public float camHeight;
	float camSpeed;
	Vector3 playerPos;
	GameObject player;
	public bool visited = false;

	void Start(){
		playerCamera = Persistent.persist.playerCamera;
		if (Persistent.persist.camHeight == camHeight) {
			camHeight = Persistent.persist.camHeight;
		} 
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
		//stirbt der Spieler in dem Raum, gilt dieser auch als nicht mehr besucht
		if(Persistent.persist.health <= 0){
			visited = false;
		}

	}

	//setzt den Raum als besucht, wenn der Spieler in den Collider eindringt
	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			visited = true;
		}
	}

	//setzt den Raum als unbesucht, wenn der Spieler den Raum verlässt
	//setzt außerdem den Raum zurück
	void OnTriggerExit(Collider collider){
		if(collider.tag == "Player"){
			visited = false;
			ResetRoom();
		}
	}

	//setzt alles in dem Raum zurück
	public void ResetRoom(){
		foreach (Stats enemy in transform.parent.GetComponentsInChildren<Stats>()) {
			enemy.Reset();
		}
	}
}

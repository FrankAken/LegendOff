using UnityEngine;
using System.Collections;

public class Bossdoor : MonoBehaviour {

	public bool closed = false;
	
	// Update is called once per frame
	void Update () {
		if (closed) {
			Close();
		}
		else{
			Open ();
		}
		/*if (transform.parent.GetComponentInChildren<CameraController> ().visited && !lorkhanDefeated) {
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,0,transform.position.z), Time.deltaTime);
			up = true;
		}
		if(lorkhanDefeated && transform.parent.GetComponentInChildren<CameraController> ().visited){
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,-5,transform.position.z), Time.deltaTime);
		}
		if (!transform.parent.GetComponentInChildren<CameraController> ().visited && lorkhanDefeated) {
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x, 0, transform.position.z), Time.deltaTime);
		}*/
	}
	
	void Open(){		
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,-5,transform.position.z), Time.deltaTime);
	}
	
	void Close(){		
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,0,transform.position.z), Time.deltaTime);
	}
}

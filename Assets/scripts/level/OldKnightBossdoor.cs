using UnityEngine;
using System.Collections;

public class OldKnightBossdoor : MonoBehaviour {
	
	public bool knightDefeated = false;
	
	// Update is called once per frame
	void Update () {
		if (transform.parent.GetComponentInChildren<CameraController> ().visited && !knightDefeated) {
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,0,transform.position.z), Time.deltaTime);
		}
		if(knightDefeated && transform.parent.GetComponentInChildren<CameraController> ().visited){
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,-5,transform.position.z), Time.deltaTime);
		}
		/*if (!transform.parent.GetComponentInChildren<CameraController> ().visited && knightDefeated) {
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x, 0, transform.position.z), Time.deltaTime);
		}*/
	}
}

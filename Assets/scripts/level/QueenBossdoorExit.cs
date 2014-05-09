using UnityEngine;
using System.Collections;

public class QueenBossdoorExit : MonoBehaviour {
	
	public bool lorkhanDefeated = false;
	public bool knightDefeated = false;
	public bool queenDefeated = false;
	
	// Update is called once per frame
	void Update () {
		if (lorkhanDefeated && knightDefeated && queenDefeated && !transform.parent.GetComponentInChildren<CameraController> ().visited) {
			transform.position = Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,-5,transform.position.z),Time.deltaTime);
		}
		
		if (transform.parent.GetComponentInChildren<CameraController> ().visited) {			
			transform.position = Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,0,transform.position.z),Time.deltaTime);
		}
	}
}

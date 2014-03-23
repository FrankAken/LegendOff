using UnityEngine;
using System.Collections;

public class RoomController : MonoBehaviour {

	//Is to be applied to 
	//Can reset the room to its former state, eg Enemy- and Trappositions- and states

	public bool visited = false;

	public void OnTriggerEnter(Collider collider){
		visited = true;
	}

	public void OnTriggerExit(Collider collider){
		visited = false;
	}

	public void Reset(){
		/*
		GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject[] traps = GameObject.FindGameObjectsWithTag("Trap");
		foreach(GameObject enemy in enemys){
			enemy.GetComponent<WarriorAI>().Reset();
		}
		foreach(GameObject trap in traps){			
			trap.GetComponent<SpiketrapAI>().Reset();
		}*/
	}	
}

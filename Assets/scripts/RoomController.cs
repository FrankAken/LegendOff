using UnityEngine;
using System.Collections;

public class RoomController : MonoBehaviour {

	public bool visited = false;

	public void Reset(){
		GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject[] traps = GameObject.FindGameObjectsWithTag("Trap");
		foreach(GameObject enemy in enemys){
			enemy.GetComponent<WarriorAI>().Reset();
		}
		foreach(GameObject trap in traps){			
			trap.GetComponent<SpiketrapAI>().Reset();
		}
	}	
}

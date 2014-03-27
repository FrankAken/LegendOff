using UnityEngine;
using System.Collections;

public class RoomController : MonoBehaviour {

	//gehört zu einem Raum und weiß ob dieser besucht ist oder nicht vom CameraController
	//kann den Raum zum Ursprungzustand zurücksetzen

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

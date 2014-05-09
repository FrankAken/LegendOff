using UnityEngine;
using System.Collections;

public class PetrousQueenAI : MonoBehaviour {

	//AI der versteinerten Königin

	GameObject leftBinding;
	GameObject rightBinding;
	public bool leftAlive = false;
	public bool rightAlive = false;
	public float respawnTime;
	public GameObject guardianLeftPrefab;
	public GameObject guardianRightPrefab;
	//Wächter-Instanzen	
	GameObject leftInstance;
	GameObject rightInstance;

	void Start(){
		//finde Bindings die den Damage-Collider beeinflussen
		leftBinding = gameObject.transform.FindChild ("EnergyBindingLeft").gameObject;
		rightBinding = gameObject.transform.FindChild ("EnergyBindingRight").gameObject;
		SpawnLeft ();
		SpawnRight ();
	}

	void Update(){
		//schließt die Tür wenn der Spieler den Raum betritt
		if (transform.parent.GetComponentInChildren<CameraController> ().visited) {
			transform.parent.GetComponentInChildren<Bossdoor>().closed = true;
		}
		else{
		//öffne die Tür wenn der Spieler nicht im Raum ist, sowie Lorkhan und der alte Ritter besiegt sind
			if(Persistent.persist.lorkhanDefeated && Persistent.persist.oldKnightDefeated){
				transform.parent.GetComponentInChildren<Bossdoor>().closed = false;
			}
		}

		//Königin ist nur angreifbar wenn beide Wächter besiegt wurden
		if (!leftAlive && !rightAlive) {
			transform.tag = "Boss";
		}
		//ansonsten kann die Waffe keinen Schaden an ihr anrichten
		else {			
			transform.tag = "Invulnerable";
		}
		
		//überprüfe ob linke Wächter-Instanz noch exisitiert
		if (leftInstance == null) {
			//deaktiviere linkes Binding
			leftBinding.SetActive (false);
			//linker Wächter ist aktuell tot
			leftAlive = false;
			//respawne linken Wächter
			Invoke ("SpawnLeft", respawnTime);
		}
		//überprüfe ob rechte Wächter-Instanz noch exisitiert
		if (rightInstance == null) {
			//deaktiviere rechtes Binding
			rightBinding.SetActive (false);
			//rechter Wächter ist aktuell tot
			rightAlive = false;
			//respawne rechten Wächter
			Invoke ("SpawnRight", respawnTime);
		}

		if(transform.GetComponent<Stats>().dead){
			Persistent.persist.queenDefeated = true;
			Destroy(gameObject);
		}
	}
	
	//zeigt verbleibende Lebenspunkte an	
	void OnGUI(){	
		if (transform.parent.GetComponentInChildren<CameraController> ().visited) {
			GUI.Box (new Rect (0, 0, Screen.width, 30), "Perous Queen : "+GetComponent<Stats> ().health + " / " + GetComponent<Stats> ().maxHealth);
		}
	}

	//spawne rechten Wächter
	void SpawnRight(){
		rightInstance = (GameObject)Instantiate (guardianRightPrefab, new Vector3(0,0,0) ,guardianRightPrefab.transform.rotation);
		rightInstance.transform.parent = transform.parent;
		rightInstance.transform.localPosition = guardianRightPrefab.transform.position;
		rightInstance.transform.localScale = guardianRightPrefab.transform.localScale;
		rightAlive = true;
		rightBinding.SetActive (true);
		CancelInvoke("SpawnRight");
	}

	//spawne linken Wächter
	void SpawnLeft(){
		leftInstance = (GameObject)Instantiate (guardianLeftPrefab, new Vector3(0,0,0) ,guardianLeftPrefab.transform.rotation);
		leftInstance.transform.parent = transform.parent;
		leftInstance.transform.localPosition = guardianLeftPrefab.transform.position;
		leftInstance.transform.localScale = guardianLeftPrefab.transform.localScale;
		leftAlive = true;
		leftBinding.SetActive (true);
		CancelInvoke("SpawnLeft");

	}
}

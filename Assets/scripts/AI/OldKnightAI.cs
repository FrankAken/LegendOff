using UnityEngine;
using System.Collections;

public class OldKnightAI : MonoBehaviour {
	
	//AI des alten Ritters

	Vector3 newPos;
	public float speed = 0.5f;
	Vector3 posA;
	Vector3 posB;

	void Start(){
		posA = new Vector3 (3f, transform.localPosition.y, 2.5f);
		posB = new Vector3 (3f, transform.localPosition.y, -2.5f);
		newPos = posA;
	}

	void Update(){
		if (transform.parent.GetComponentInChildren<CameraController> ().visited) {
			//schließt die Tür wenn der Spieler im Raum ist
			transform.parent.GetComponentInChildren<Bossdoor>().closed = true;
			//bewege den alten Ritter
			Move ();
		}
		else{
			//ansonsten ist die Tür offen
			transform.parent.GetComponentInChildren<Bossdoor>().closed = false;
		}

		if (transform.GetComponent<Stats> ().dead) {
			//beim Tod des alten Ritters ist eine der Vorraussetzunge erfüllt um die letzte Tür zu öffnen
			Persistent.persist.oldKnightDefeated = true;
			//öffne die Tür
			transform.parent.GetComponentInChildren<Bossdoor>().closed = false;
			//zerstöre das gameObject
			Destroy(gameObject);
		}
	}

	//zeigt verbleibende Lebenspunkte an
	void OnGUI(){	
		if (transform.parent.GetComponentInChildren<CameraController> ().visited) {
			GUI.Box (new Rect (0, 0, Screen.width, 30), "Old Knight : " + GetComponent<Stats> ().health + " / " + GetComponent<Stats> ().maxHealth);
		}
	}
	
	//stellt nächste Position des gameObject fest
	void Move(){
		transform.localPosition = Vector3.MoveTowards(transform.localPosition,newPos,Time.deltaTime * speed);
		if(transform.localPosition == posA){
			newPos = posB;
		}
		if(transform.localPosition == posB){
			newPos = posA;
		}
	}
}

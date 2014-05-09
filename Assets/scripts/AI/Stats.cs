using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	//enthält Statuswerte für einen Schergen

	public Vector3 spawn;
	public float health;
	public float maxHealth;
	public bool dead = false;
	public int souls;

	//setze Position des transform als spawn-Punkt für Reset()
	void Start(){
		spawn = transform.position;
	}

	void Update(){
		//füge Seelen zu Spielerkonto hinzu und zerstöre gameObject
		if(health <= 0f){
			Persistent.persist.souls += souls;
			dead = true;
			Debug.Log (transform.name+" was killed");
		}
	}

	//wird ausgeführt wenn der Spieler rastet, NICHT beim Tod des Gegners
	public void Reset(){
		health = maxHealth;
		transform.position = spawn;
		Debug.Log (transform.name+" 's Reset was called");
	}
}

using UnityEngine;
using System.Collections;

public class DroppedPosessions : MonoBehaviour {

	//Gehört zum gameObject das der Spieler aufsammeln muss um seine Seelen nach einem Tod zurückzuerhalten
	//ist nur existent in der ersten Runde nach dem Spielertod und wird beim nächsten neu gesetzt mit den dann akkumulierten Seelen

	int soulsDropped;
	public float despawnDuration;

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player") {
			Persistent.persist.souls = soulsDropped;
			Destroy (gameObject,despawnDuration);
		}
	}

	void DropSouls(int souls){
		soulsDropped = souls;
	}
}

using UnityEngine;
using System.Collections;

public class DroppedPosessions : MonoBehaviour {

	//Gehört zum gameObject das der Spieler aufsammeln muss um seine Seelen nach einem Tod zurückzuerhalten
	//ist nur existent in der ersten Runde nach dem Spielertod und wird beim nächsten neu gesetzt mit den dann akkumulierten Seelen

	int soulsDropped;
	int deathsWhenDropped;
	public float despawnDuration;

	//erhalte Seelen zurück bei Berührung
	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player") {
			Persistent.persist.souls = soulsDropped;
			Destroy (gameObject,despawnDuration);
		}
	}

	//ausführen wenn der Charakter stirbt
	public void StoreSouls(int souls){
		soulsDropped = souls;
		deathsWhenDropped = Persistent.persist.deathCounter;
	}
	void Update(){
		if (Persistent.persist.deathCounter > deathsWhenDropped) {
			Destroy(gameObject);
		}
	}
}

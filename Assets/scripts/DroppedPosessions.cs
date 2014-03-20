using UnityEngine;
using System.Collections;

public class DroppedPosessions : MonoBehaviour {

	public string pickupMessage;
	public float despawnDuration;
	GameObject player;

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player") {
			Debug.Log(pickupMessage);
			gameObject.transform.renderer.material.color = Color.green;
			//player.GetComponent<Stats>().souls = player.GetComponent<Stats>()._souls;
			Destroy (gameObject,despawnDuration);
		}
	}
}

using UnityEngine;
using System.Collections;

public class DroppedPosessions : MonoBehaviour {

	//Is to be applied to the GameObject the player has to pick up to regain his souls
	//Is only collectable with previous amount of souls when picked up the first round after dying

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

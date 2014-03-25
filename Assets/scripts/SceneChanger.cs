using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {

	//Wechsel zur definierten Szene wenn der Collider berührt wird

	public string changeTo = "testing";

	void OnTriggerEnter(Collider collider){
		Application.LoadLevel(changeTo);
	}
}

using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {

	//Change to defined Scene when entering Trigger

	public string changeTo = "testing";

	void OnTriggerEnter(Collider collider){
		Application.LoadLevel(changeTo);
	}
}

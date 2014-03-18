using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {

	public string changeTo = "testing";

	void OnTriggerEnter(Collider collider){
		Application.LoadLevel(changeTo);
	}
}

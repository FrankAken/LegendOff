using UnityEngine;
using System.Collections;

public class ArmorValues : MonoBehaviour {

	//Gehört zu einer Rüstung

	//Statuswerte des Kürass
	public string cuirassName;
	public float armorValue;
	public float weight;
	public float armorLevel;
	public float recoveryRateReduction;

	void Start(){
		if (gameObject.transform.parent.tag == "Player") {
			Persistent.persist.armorClass += armorValue;
			transform.root.rigidbody.mass += weight / Persistent.persist.weightDivider;
		}
	}
}

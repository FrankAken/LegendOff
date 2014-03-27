using UnityEngine;
using System.Collections;

public class ArmorValues : MonoBehaviour {

	public float armorValue;
	public float weight;

	void Start(){
		if (gameObject.transform.parent.tag == "Player") {
			Persistent.persist.armorClass += armorValue;
			transform.root.rigidbody.mass += weight / Persistent.persist.armorDivider;
		}
		else if (gameObject.transform.parent.tag == "Enemy") {
			transform.root.GetComponent<Stats>().armorClass += armorValue;
			Persistent.persist.armorClass += armorValue;
			transform.root.rigidbody.mass += weight / Persistent.persist.armorDivider;
		}
	}
}

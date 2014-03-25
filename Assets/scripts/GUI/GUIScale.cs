using UnityEngine;
using System.Collections;

public class GUIScale : MonoBehaviour {

	//skaliert die GUI-Element anhand des aus der Auflösung errechneten Seitenverhältnisses

	float currentAspectRatio;

	void Start(){
		//stelle aktuelles Seitenverhältnis fest
		currentAspectRatio = (float)Screen.width / Screen.height;
	}
}

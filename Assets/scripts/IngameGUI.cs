using UnityEngine;
using System.Collections;

public class IngameGUI : MonoBehaviour {

	float widthCenter, heightCenter;
	GameObject player;
	public Texture2D lifeBar;
	public Texture2D staminaBar;
	public Texture2D items;

	// Use this for initialization
	void Awake () {
		widthCenter = Screen.currentResolution.width / 2f;
		heightCenter = Screen.currentResolution.height / 2f; 
		player = GameObject.FindGameObjectWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI(){
		GUI.DrawTexture (new Rect (10, 10, lifeBar.width, lifeBar.height), lifeBar);
		GUI.DrawTexture (new Rect (10, 20 + lifeBar.height, staminaBar.width, staminaBar.height), staminaBar);
		GUI.DrawTexture (new Rect (10, 30 + staminaBar.height, items.width, items.height), items);
	}
}

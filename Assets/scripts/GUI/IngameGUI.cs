using UnityEngine;
using System.Collections;

public class IngameGUI : MonoBehaviour {

	//GUI die im Spiel angezeigt wird, gibt Auskunft über Leben, Ausdauer, Seelen, Waffe etc

	float widthCenter, heightCenter, widthBG, heightBG;
	public float guiScale = 1f;
	public Texture2D background;
	public Texture2D lifebar;
	public Texture2D staminaBar;
	public Texture2D poisonIcon;
	public Texture2D bleedIcon;
	string soulDisplay, healthDisplay, staminaDisplay;

	void Awake () {
		widthCenter = Screen.width / 2f;
		heightCenter = Screen.height / 2f; 
		widthBG = (Screen.width / 3f) * guiScale;
		heightBG = widthBG / 4f;
	}

	//Zeichnet GUI
	void OnGUI(){
		//GUI.DrawTexture (new Rect (0, 0, widthBG, heightBG), background);
		//Debug
		GUI.Box(new Rect(10,heightBG + 10, 100,20), "Health: "+healthDisplay);
		GUI.Box(new Rect(10,heightBG + 40, 100,20), "Stamina: "+staminaDisplay);
		GUI.Box(new Rect(10,heightBG + 70, 100,20), "Souls: "+soulDisplay);
		GUI.Box(new Rect(10,heightBG + 100, 100,20), Screen.width+"x"+Screen.height);
	}

	void FixedUpdate(){
		//Escape lädt das Hauptmenü
		if (Input.GetKey (KeyCode.Escape)) {
			Application.LoadLevel("mainmenu");
		}
		//Update der Charakterwerte
		soulDisplay = ""+Persistent.persist.souls;
		healthDisplay = "" +Persistent.persist.health;
		staminaDisplay = "" +Persistent.persist.stamina;
	}
}

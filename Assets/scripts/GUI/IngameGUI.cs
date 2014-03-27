using UnityEngine;
using System.Collections;

public class IngameGUI : MonoBehaviour {

	//GUI die im Spiel angezeigt wird, gibt Auskunft über Leben, Ausdauer, Seelen, Waffe etc

	float widthCenter, heightCenter, widthBG, heightBG;
	public bool debugHud;
	public bool releaseHud;
	public float guiScale = 1f;
	public Texture2D background;
	public Texture2D lifebar;
	public Texture2D staminaBar;
	public Texture2D poisonIcon;
	public Texture2D bleedIcon;
	string soulDisplay, healthDisplay, staminaDisplay;

	//Zeichnet GUI
	void OnGUI(){
		//HUD wie sie im fertigen Spiel aussehen soll
		if (releaseHud) {
			GUI.DrawTexture (new Rect (90, 15, (lifebar.width / 3f) * guiScale, (lifebar.height / 3f) * guiScale), lifebar);
			GUI.DrawTexture (new Rect (75, 75, (staminaBar.width / 3f) * guiScale, (staminaBar.height / 3f) * guiScale), staminaBar);
			GUI.DrawTexture (new Rect (0, 0, (background.width / 3f) * guiScale, (background.height / 3f) * guiScale), background);
		}
		//Debug
		if (debugHud) {
			GUI.Box (new Rect (10, Screen.height - 40, 100, 20), "Health: " + healthDisplay);
			GUI.Box (new Rect (110, Screen.height - 40, 100, 20), "Stamina: " + staminaDisplay);
			GUI.Box (new Rect (210, Screen.height - 40, 100, 20), "Souls: " + soulDisplay);
			GUI.Box (new Rect (310, Screen.height - 40, 100, 20), Screen.width + "x" + Screen.height);
		}
	}

	void Update(){
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

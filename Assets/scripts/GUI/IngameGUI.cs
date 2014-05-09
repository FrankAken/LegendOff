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
	WeaponValues playerWeaponStats;
	ArmorValues playerHelmetStats;
	ArmorValues playerCuirassStats;
	ArmorValues playerTrousersStats;
	ArmorValues playerBootsStats;

	
	void Start(){
		playerWeaponStats = Persistent.persist.weapon.GetComponent<WeaponValues> ();
		//playerHelmetStats = Persistent.persist.helmet.GetComponent<ArmorValues> ();
		playerCuirassStats = Persistent.persist.cuirass.GetComponent<ArmorValues> ();
		//playerTrousersStats = Persistent.persist.trousers.GetComponent<ArmorValues> ();
		//playerBootsStats = Persistent.persist.boots.GetComponent<ArmorValues> ();
	}

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
			GUI.Box (new Rect (410, Screen.height - 40, 100, 20), Screen.width + "x" + Screen.height);
			GUI.Box (new Rect (510, Screen.height - 40, 100, 20), "ViewDir"+Persistent.persist.ViewDir);
			GUI.Box (new Rect (Screen.width - 210, Screen.height - 40, 200, 20), playerCuirassStats.cuirassName+"+"+playerCuirassStats.armorLevel);
			GUI.Box (new Rect (Screen.width - 210, Screen.height - 60, 200, 20), playerWeaponStats.weaponName+"+"+playerWeaponStats.weaponLevel);
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

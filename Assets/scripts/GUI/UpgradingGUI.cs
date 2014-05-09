using UnityEngine;
using System.Collections;

public class UpgradingGUI : MonoBehaviour {

	//GUI, die bei Ansprechen eines Schmieds aufgerufen wird um die Ausrüstung des Charakters zu verbessern

	public string upgradeWeapon;
	public string upgradeArmor;
	public int upgradeCap;
	//Werte für Waffenausbau
	WeaponValues playerWeaponStats;
	public float damageIncrease;
	public float attackCostDecrease;
	public int weaponUpgradeCosts;
	//Werte für Helmausbau
	ArmorValues playerHelmetStats;
	public float helmetIncrease;
	//Werte für Kürassausbau
	ArmorValues playerCuirassStats;
	public float cuirassIncrease;
	public int cuirassUpgradeCosts;
	//Werte für Handschuhausbau
	ArmorValues playerGauntletsStats;
	public float gauntletsIncrease;
	//Werte für Beinschienenausbau
	ArmorValues playerLeggingsStats;
	public float leggingsIncrease;

	void Start(){
		playerWeaponStats = Persistent.persist.weapon.GetComponent<WeaponValues> ();
		playerCuirassStats = Persistent.persist.cuirass.GetComponent<ArmorValues> ();
		upgradeWeapon = weaponUpgradeCosts+" Souls: " + playerWeaponStats.weaponName + "+" + playerWeaponStats.weaponLevel;
		upgradeArmor = cuirassUpgradeCosts+" Souls: " + playerCuirassStats.cuirassName + "+" + playerCuirassStats.armorLevel;
	}

	void OnGUI(){
		//Waffenausbau erhöht Schaden und verringert die Ausdauerkosten pro Angriff
		if (GUI.Button (new Rect (Screen.width / 2f - 100, Screen.height / 4f, 200, 40), upgradeWeapon)) {
			if(playerWeaponStats.weaponLevel < upgradeCap){
				if(Persistent.persist.souls >= weaponUpgradeCosts){
					Persistent.persist.souls -= weaponUpgradeCosts;
					weaponUpgradeCosts += 1000;
					playerWeaponStats.weaponLevel += 1;
					playerWeaponStats.damage += damageIncrease;
					playerWeaponStats.attackCost -= attackCostDecrease;
					upgradeWeapon = weaponUpgradeCosts+" Souls: " + playerWeaponStats.weaponName + "+" + playerWeaponStats.weaponLevel;
					Persistent.persist.UpdateWeapon();
				}
				else{
					GUI.Box (new Rect (0, 0, Screen.width, 30), "Not enough souls to upgrade Weapon");
					Debug.Log ("Not enough souls to upgrade Weapon");
				}
			}
			else if(playerWeaponStats.weaponLevel >= upgradeCap){
				Debug.Log ("Weapon is already fully upgraded");
			}
		}
		//Kürassausbau erhöht den Rüstungswert auf der Brustplatte und erhöht die Ausdauerregeneration
		else if(GUI.Button (new Rect (Screen.width / 2f -100, Screen.height / 4f + 60, 200, 40), upgradeArmor)){
			if(playerCuirassStats.armorLevel < upgradeCap){
				if(Persistent.persist.souls >= cuirassUpgradeCosts){
					Persistent.persist.souls -= cuirassUpgradeCosts;
					cuirassUpgradeCosts += 1000;
					playerCuirassStats.armorLevel += 1;
					playerCuirassStats.armorValue += cuirassIncrease;
					upgradeArmor = cuirassUpgradeCosts+" Souls: " + playerCuirassStats.cuirassName + "+" + playerCuirassStats.armorLevel;
					Persistent.persist.UpdateCuirass();
				}
				else{
					GUI.Box (new Rect (0, 0, Screen.width, 30), "Not enough souls to upgrade Armor");
					Debug.Log("Not enough souls to upgrade Armor");
				}
			}
			else if (playerCuirassStats.armorLevel >= upgradeCap){
				Debug.Log ("Armor is already fully upgraded");
			}
		}
	}
}

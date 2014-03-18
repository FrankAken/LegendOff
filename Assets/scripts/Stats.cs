using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	public Vector3 spawn;
	public float health = 10f;
	public float _health = 10f;
	public float stamina = 20f;
	public float _stamina = 20f;
	public bool poisoned = false;
	public bool _poisoned = false;
	public float poisonDamage = 0.2f;
	public bool bleeding = false;
	public bool _bleeding = false;
	public float bleedDamage = 0.5f;	
	public float speed = 25f;
	public bool running = false;
	public float jumpAccel = 30f;
	public int viewDir = 6;
	//1=up,2=up-right,3=right,4=down-right,5=down,6=down-left,7=left,8=up-left
	public int _viewDir = 6;

	void Start(){
		spawn = transform.position;
	}

	void Update(){
		Debug.Log(gameObject.name+" | Health: "+health+" Stamina: "+stamina);
		if(health <= 0){
			Debug.Log("YOU DIED");
			Reset();
		}
		if(poisoned){
			//Recoloring will be replaced with Animation
			gameObject.transform.renderer.material.color = Color.green;
			health -= poisonDamage;
		}
		if(bleeding){
			//Recoloring will be replaced with Animation
			gameObject.transform.renderer.material.color = Color.red;
			health -= bleedDamage;
		}
	}

	public void Reset(){
		health = _health;
		stamina = _stamina;
		poisoned = _poisoned;
		bleeding = _bleeding;
		transform.position = spawn;
		viewDir = _viewDir;
	}
}

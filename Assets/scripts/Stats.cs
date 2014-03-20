using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	public Vector3 spawn;
	public float health;
	public float stamina;
	public bool poisoned;
	public float poisonDamage;
	public bool bleeding;
	public float bleedDamage;	
	public float speed;
	public bool running;
	public float dashMultiplier;
	public float dashDuration;
	public float dashCost;
	public float runCost;
	public int viewDir;
	//1=up,2=up-right,3=right,4=down-right,5=down,6=down-left,7=left,8=up-left
	public GameObject weapon;
	public int souls;
	public float _health;
	public float _stamina;
	public bool _poisoned;
	public bool _bleeding ;
	public int _viewDir;
	public int _souls;
	public float _speed;

	void Awake(){
		_health = health;
		_stamina = stamina;
		_poisoned = poisoned;
		_bleeding = bleeding;
		_viewDir = viewDir;
		_souls = souls;
		_speed = speed;
	}
	void Start(){
		spawn = transform.position;
	}

	void Update(){
		Debug.Log(gameObject.name+" | Health: "+health+" Stamina: "+stamina);
		if(health <= 0){
			Debug.Log(gameObject.name+" DIED");
			if(gameObject.tag == "Player"){
				Reset();
			}
			else{
				GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>().souls += souls;
				Destroy(gameObject);
			}
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
		if (running) {
			InvokeRepeating("RunExhaustion",0f,1f);
		}
		if (!running) {
			CancelInvoke("RunExhaustion");
		}
	}
	
	void RunExhaustion(){
		stamina -= runCost;
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

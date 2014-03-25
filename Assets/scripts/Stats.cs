using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	//enthält Statuswerte für einen Schergen

	public Vector3 spawn;
	public float health;
	public float stamina;
	public int souls;
	public int viewDir;
	//1=up,2=up-right,3=right,4=down-right,5=down,6=down-left,7=left,8=up-left
	public GameObject weapon;
	float _health;
	float _stamina;
	bool _poisoned;
	bool _bleeding ;
	int _viewDir;
	int _souls;

	void Awake(){
		_health = health;
		_stamina = stamina;
		_viewDir = viewDir;
		_souls = souls;
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
	}

	public void Reset(){
		health = _health;
		stamina = _stamina;
		transform.position = spawn;
		viewDir = _viewDir;
	}
}

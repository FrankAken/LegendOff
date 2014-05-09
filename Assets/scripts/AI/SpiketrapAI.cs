using UnityEngine;
using System.Collections;

public class SpiketrapAI : MonoBehaviour {

	//AI für die Stachelfalle

	Vector3 newPos;
	public bool stopped = false;
	public float speed = 7.0f;
	public Vector3 posA = new Vector3(0,0,0);
	public Vector3 posB = new Vector3(0,0,0);
	public Vector3 origPos;	
	
	void Awake(){
		newPos = posA;
	}

	void Start(){
		origPos = transform.position;
	}
	
	//beweget das gameObject kontinuierlich zwischen posA und posB hin- und her
	void Update () {
		if(transform.parent.GetComponent<CameraController>().visited){
			Move();	
		}
	}

	//stellt nächste Position des gameObject fest
	void Move(){
		transform.position = Vector3.MoveTowards(transform.position,newPos,Time.deltaTime * speed);
		if(transform.position == posA){
			newPos = posB;
		}
		if(transform.position == posB){
			newPos = posA;
		}
	}

	//setzt das gameObject auf seine Startposition zurück
	public void Reset(){
		transform.position = origPos;
	}
}
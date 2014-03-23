using UnityEngine;
using System.Collections;

public class SpiketrapAI : MonoBehaviour {

	//AI for the Spiketrap

	Vector3 newPos;
	public bool stopped = false;
	public float speed = 7.0f;
	public Vector3 posA = new Vector3(0,0,0);
	public Vector3 posB = new Vector3(0,0,0);
	public Vector3 origPos;

	void Start(){
		transform.renderer.material.color = Color.gray;
		origPos = transform.position;
	}

	void Awake(){
		newPos = posA;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.parent.GetComponent<RoomController>().visited){
			Move();	
		}
	}

	void Move(){
		transform.position = Vector3.MoveTowards(transform.position,newPos,Time.deltaTime * speed);
		if(transform.position == posA){
			newPos = posB;
		}
		if(transform.position == posB){
			newPos = posA;
		}
	}

	public void Reset(){
		transform.position = origPos;
	}
}
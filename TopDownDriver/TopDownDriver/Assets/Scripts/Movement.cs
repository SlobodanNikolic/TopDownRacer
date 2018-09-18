using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float xspeep = 0f;
	public float power = 0.001f;
	public float friction = 0.95f;
	public bool right = false;
	public bool left = false;
	public float speed;
	public Rigidbody body;

	void Start(){
		body = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void FixedUpdate () {


		if(right){
			xspeep += power;
		}
		if(left){
			xspeep -= power;
		}


	}

	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0)){
			if (Input.mousePosition.x > 390f) {
				right = true;
			} else {
				left = true;
			}
		}
		if(Input.GetMouseButtonUp(0)){
			if (Input.mousePosition.x > 390f) {
				right = false;
			} else {
				left = false;
			}
		}

		xspeep *= friction;
		body.velocity = Vector3.right * speed;
		//Ovo radi dobro
//		transform.Translate (-Vector3.forward * speed);
		transform.Translate(Vector3.right * -xspeep);



	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Road") {
			Debug.Log (other.name);
			RoadMaker.instance.PlaceNew ();
		}
	}
}
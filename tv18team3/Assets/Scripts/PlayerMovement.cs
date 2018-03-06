using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody rb;
	private bool walking;
	private float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		this.walking = false;

		this.speed = 50.0f;
	}
	
	// Update is called once per frame
	void Update () {
		// Conditional to detect if character can walk or not
		if (this.walking) {
			this.rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
			this.rb.velocity = Camera.main.transform.forward * speed * Time.deltaTime;
		}
	}

	// Setter for walking capability
	public void setWalkingTrue(){
		this.walking = true;
	}

	public void setWalkingFalse(){
		this.walking = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody rb;
	private bool walking;
	private float speed;
	private AudioSource footsteps;

	// Use this for initialization
	void Start () {
		this.rb = GetComponent<Rigidbody> ();

		this.footsteps = GetComponent<AudioSource> ();

		this.walking = false;

		this.speed = 150.0f;
	}
	
	// Update is called once per frame
	void Update () {
		// Conditional to detect if character can walk or not
		if (this.walking) {
			this.rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
			this.rb.velocity = Camera.main.transform.forward * speed * Time.deltaTime;
		} else {
			this.rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
		}
	}

	// Setter for walking capability
	public void isWalking(){
		this.walking = true;
		this.footsteps.Play ();
	}

	public void isNotWalking(){
		this.walking = false;
		this.footsteps.Pause ();
	}
}

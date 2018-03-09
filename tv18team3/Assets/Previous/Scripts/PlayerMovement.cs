using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody rb;
	private bool walking;
	private float speed;
	private AudioSource footsteps;
	private bool sceneLoaded2;
	private bool sceneLoaded3;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);

		this.sceneLoaded2 = false;

		this.sceneLoaded3 = false;

		this.rb = GetComponent<Rigidbody> ();

		this.footsteps = GetComponent<AudioSource> ();

		this.walking = false;

		this.speed = 50.0f;
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

	public void loadScene2(){
		SceneManager.LoadScene ("City3", LoadSceneMode.Additive);
		this.sceneLoaded2 = true;
		
	}

	public void loadScene3(){
		
		SceneManager.LoadScene ("City2", LoadSceneMode.Additive);
		this.sceneLoaded3 = true;

	}
}

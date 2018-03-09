using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalChangeScene : MonoBehaviour {

	public float timeAwake;
	GameObject player;
	// Use this for initialization
	void Start () {
		timeAwake = 0;
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		timeAwake += Time.deltaTime;
		if (timeAwake > 65) {
			Destroy (player);
			SceneManager.LoadScene ("Credits", LoadSceneMode.Single);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lastCamera : MonoBehaviour {

	public float timeToFade;
	public Image img;
	// Use this for initialization
	void Start () {
		timeToFade = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeToFade <= 10) {
			Color old = img.color;
			img.color = new Color (old.r, old.g, old.b, timeToFade / 10.0f);
		} else {
			SceneManager.LoadScene ("GameOver", LoadSceneMode.Single);
		}
		timeToFade += Time.deltaTime;
	}
}

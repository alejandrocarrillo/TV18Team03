using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorUI : MonoBehaviour {

	private Image image;
	private GameObject player;
	private PlayerCondition pc;
	public string type;
	// Use this for initialization
	void Start () {
		this.image = GetComponent<Image> ();
		this.player = GameObject.Find ("Player");
		this.pc = this.player.GetComponent<PlayerCondition> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.type == "fear") {
			Color oldColor = this.image.color;
			this.image.color = new Color (oldColor.r, oldColor.g, oldColor.b, (this.pc.fear)/100.0f);
		} else if(this.type == "health") {
			Color oldColor = this.image.color;
			this.image.color = new Color (oldColor.r, oldColor.g, oldColor.b, (100 - this.pc.health)/100.0f);
		}
	}
}

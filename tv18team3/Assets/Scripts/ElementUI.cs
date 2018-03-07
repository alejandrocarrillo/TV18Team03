using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementUI : MonoBehaviour {

	public List<Sprite> sprites;
	public string type;

	private Sprite currentSprite;
	private GameObject player;
	private PlayerCondition pc;
	private Image image;

	private static readonly string HUNGER = "hunger";
	private static readonly string THIRST = "thirst";

	// Use this for initialization
	void Start () {
		this.image = gameObject.GetComponent<Image> ();
		this.currentSprite = sprites [0];
		this.player = GameObject.Find ("Player");
		this.pc = this.player.GetComponent<PlayerCondition> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (this.type == HUNGER) {
			if (this.pc.hunger == 0) {
				this.currentSprite = sprites [5];
			} else if (this.pc.hunger < 20) {
				this.currentSprite = sprites [4];
			} else if (this.pc.hunger < 40) {
				this.currentSprite = sprites [3];
			} else if (this.pc.hunger < 60) {
				this.currentSprite = sprites [2];
			} else if (this.pc.hunger < 80) {
				this.currentSprite = sprites [1];
			} else {
				this.currentSprite = sprites [0];
			}
		} else if (this.type == THIRST) {
			if (this.pc.thirst == 0) {
				this.currentSprite = sprites [4];
			} else if (this.pc.thirst < 25) {
				this.currentSprite = sprites [3];
			} else if (this.pc.thirst < 50) {
				this.currentSprite = sprites [2];
			} else if (this.pc.thirst < 75) {
				this.currentSprite = sprites [1];
			} else {
				this.currentSprite = sprites [0];
			}
		}

		this.image.sprite = this.currentSprite;
	}
}

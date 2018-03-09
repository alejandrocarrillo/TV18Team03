using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementUI : MonoBehaviour {

	public List<Sprite> sprites;
	public string type;
	public List<AudioClip> audios;

	private Sprite currentSprite;
	private GameObject player;
	private PlayerCondition pc;
	private Image image;
	private AudioSource audio;

	private static readonly string HUNGER = "hunger";
	private static readonly string THIRST = "thirst";

	// Use this for initialization
	void Start () {
		this.audio = gameObject.GetComponent<AudioSource> ();
		this.image = gameObject.GetComponent<Image> ();
		this.currentSprite = this.sprites [0];
		this.player = GameObject.Find ("Player");
		this.pc = this.player.GetComponent<PlayerCondition> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (this.type == HUNGER) {
			if (this.pc.hunger == 0) {
				playSoundWhenChange (5);
				this.currentSprite = this.sprites [5];
			} else if (this.pc.hunger < 20) {
				playSoundWhenChange (4);
				this.currentSprite = this.sprites [4];
			} else if (this.pc.hunger < 40) {
				playSoundWhenChange (3);
				this.currentSprite = this.sprites [3];
			} else if (this.pc.hunger < 60) {
				playSoundWhenChange (2);
				this.currentSprite = this.sprites [2];
			} else if (this.pc.hunger < 80) {
				playSoundWhenChange (1);
				this.currentSprite = this.sprites [1];
			} else {
				playSoundWhenChange (0);
				this.currentSprite = this.sprites [0];
			}
		} else if (this.type == THIRST) {
			if (this.pc.thirst == 0) {
				playSoundWhenChange (4);
				this.currentSprite = this.sprites [4];
			} else if (this.pc.thirst < 25) {
				playSoundWhenChange (3);
				this.currentSprite = this.sprites [3];
			} else if (this.pc.thirst < 50) {
				playSoundWhenChange (2);
				this.currentSprite = this.sprites [2];
			} else if (this.pc.thirst < 75) {
				playSoundWhenChange (1);
				this.currentSprite = this.sprites [1];
			} else {
				playSoundWhenChange (0);
				this.currentSprite = this.sprites [0];
			}
		}

		this.image.sprite = this.currentSprite;
	}

	// Function used to play sounds when icon in UI changes
	private void playSoundWhenChange(int i){
		if (i != 0) {
			if (this.currentSprite == this.sprites [i - 1]) {
				this.audio.clip = this.audios [0];
				this.audio.Play ();
			}
		} else if (this.currentSprite != this.sprites [i]) {
			this.audio.clip = this.audios [1];
			this.audio.Play ();
		}
	}
}

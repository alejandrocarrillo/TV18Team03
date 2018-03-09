using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour {

	public List<GameObject> items;

	public float thirst,
				 hunger,
				 health,
				 fear,
				 secondsAlive;	

	private int stalkers,
				prStalkers;

	// Use this for initialization
	void Start () {
		this.items = new List<GameObject> ();
		this.secondsAlive = 0;
		this.prStalkers = this.stalkers;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.prStalkers != this.stalkers) {
			feelingFear ();
			this.prStalkers = this.stalkers;
		}

		this.secondsAlive += Time.deltaTime;
		if (this.secondsAlive >= 10) {
			if (this.hunger > 0) {
				this.hunger -= 5;
			}
			if (this.thirst > 0) {
				this.thirst -= 10;
			}
			this.secondsAlive = 0;
		}

		if ((this.hunger <= 30 || this.thirst <= 30) && this.secondsAlive >= 10) {
			if (this.health > 0) {
				this.health -= 5;
			}
			this.secondsAlive = 0;
		}
	}

	// Methods for determining if player needs an item
	private bool isHungry(){
		return this.hunger <= 75;
	}

	private bool isThirsty(){
		return this.thirst <= 75;
	}

	private bool isDying(){
		return this.health <= 75;
	}

	// Check player condition
	private bool playerNeedsItem(GameObject item){
		Item i = item.GetComponent<Item> ();
		switch (i.type){
			case "food":
				if (isHungry ()) {
					return true;
				}
				break;
			case "water":
				if (isThirsty ()) {
					return true;
				}
				break;
			case "medicine":
				if (isDying ()) {
					return true;
				}
				break;
		}
		return false;
	}

	// What to do when clicking on an item
	public void decideOnItem(GameObject itemPrefab){
		Item i = itemPrefab.GetComponent<Item> ();
		if (playerNeedsItem (itemPrefab)) {
			switch (i.type) {
				case "food":
					this.eatFood (i.benefit);
					break;
				case "water":
					this.drinkWater (i.benefit);
					break;
				case "medicine":
					this.consumeMeds (i.benefit);
					break;
			}
		} else {
			this.storeItem (itemPrefab);
		}
	}

	public void destroyItem(GameObject item){
		Destroy (item);
	}

	// Trigger when there are no needs for player
	private void storeItem(GameObject item){
		this.items.Add (item);
	}

	// Trigger when drinking items
	private void drinkWater(float thirst){
		this.thirst += thirst;
		if (this.thirst > 100.0f) {
			this.thirst = 100.0f;
		}
	}

	// Trigger when eating items
	private void eatFood(float hunger){
		this.hunger += hunger;
		if (this.hunger > 100.0f) {
			this.hunger = 100.0f;
		}
	}

	// Trigger when consumind medicines
	private void consumeMeds(float health){
		this.health += health;
		if (this.health > 100.0f) {
			this.health = 100.0f;
		}
	}

	// There is someone following you
	public void stalkerFollowing(){
		this.stalkers++;
	}

	// Feeling fear
	private void feelingFear(){
		if (this.stalkers > 4) {
			this.fear = 100.0f;
		} else {
			this.fear = 25 * this.stalkers;
		}
	}
}

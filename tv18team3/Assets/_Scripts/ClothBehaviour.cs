using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cloth))]
public class ClothBehaviour : MonoBehaviour {
	[SerializeField] private bool wind = true;

	private Cloth cloth;
	private ClothWind clothWind;

	private void Awake() {
		cloth = GetComponent<Cloth>();
		clothWind = GetComponentInChildren<ClothWind>();
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(SetWind());
	}

	private IEnumerator SetWind () {
		Vector3 dir;
		do{
			dir = (transform.position - clothWind.transform.position).normalized;
			yield return new WaitForSeconds(0.1f);
			cloth.externalAcceleration = dir * clothWind.windForce;
		}while(wind);
	}
}

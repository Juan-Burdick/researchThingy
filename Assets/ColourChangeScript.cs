using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChangeScript : MonoBehaviour {
	//"warmth" - time looked at
	private float warmth = 0;
	private float startTime = 0;
	private bool doCount = false;

	// Use this for initialization
	void Start () {
		warmth = 0;
		startTime = 0;
		doCount = false;
		SetGazedAt(false);
		UpdateColor(warmth);
	}
	
	//tell the object if it is being looked at
	public void SetGazedAt(bool gazedAt) {
		if (gazedAt == true) {
			doCount = true;
			startTime = Time.time;
		}
		else {
			doCount = false;
			warmth = 0;
			UpdateColor (warmth);
		}
	}

	//update color over time
	public void UpdateColor(float warm) {
		if (warm > 7) {
			GetComponent<Renderer> ().material.color = Color.red;
		}
		else if (warm > 5 && warm <= 7) {
			GetComponent<Renderer> ().material.color = Color.yellow;
		}
		else if (warm > 3 && warm <= 5) {
			GetComponent<Renderer> ().material.color = Color.green;
		}
		else if (warm > 0 && warm <= 3) {
			GetComponent<Renderer> ().material.color = Color.blue;
		}
		else if (warm <= 0) {
			GetComponent<Renderer> ().material.color = Color.black;
		}
		else {
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		if (doCount) {
			warmth = Time.time - startTime;
			UpdateColor (warmth);
		}
	}
}

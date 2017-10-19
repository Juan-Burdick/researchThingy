using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChangeScript : MonoBehaviour {
	//"warmth" - time looked at
	private float warmth = 0;
	private float startTime = 0;
	private bool doCount = false;
	private bool doSubCount = false;
	private Color lengthLooked = Color.black;

	// Use this for initialization
	void Start () {
		warmth = 0;
		startTime = 0;
		doCount = false;
		doSubCount = false;
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

	public void SetGazedNear(bool gazedNear) {
		if (gazedNear == true) {
			doSubCount = true;
			startTime = Time.time;
		}
		else {
			doSubCount = false;
			warmth = 0;
			UpdateColor (warmth);
		}
	}

	//update color over time
	public void UpdateColor(float warm) {
		if (warm > 5) {
			GetComponent<Renderer> ().material.color = Color.Lerp(Color.yellow, Color.red,  (warm-5)/6);
		}
		else if (warm > 4 && warm <= 5) {
			GetComponent<Renderer> ().material.color = Color.Lerp(Color.green, Color.yellow, (warm-4));
		}
		else if (warm > 3 && warm <= 4) {
			GetComponent<Renderer> ().material.color = Color.Lerp(Color.blue, Color.green, (warm-3));
		}
		else if (warm > 2 && warm <= 3) {
			GetComponent<Renderer> ().material.color = Color.blue;
		}
		else if (warm > 0 && warm <= 2) {
			GetComponent<Renderer> ().material.color = Color.Lerp(Color.black, Color.blue, warm/2);
		}
		else if (warm <= 0) {
			GetComponent<Renderer> ().material.color = Color.black;
		}
		else {
			Destroy(gameObject);
		}
	}

	public void UpdateSplashedColor(float warm) {
		if (warm > 8) {
			GetComponent<Renderer> ().material.color = Color.Lerp(Color.yellow, Color.red,  (warm-8)/6);
		}
		else if (warm > 6 && warm <= 8) {
			GetComponent<Renderer> ().material.color = Color.Lerp(Color.green, Color.yellow, (warm-6)/2);
		}
		else if (warm > 4 && warm <= 6) {
			GetComponent<Renderer> ().material.color = Color.Lerp(Color.blue, Color.green, (warm-4)/2);
		}
		else if (warm > 2 && warm <= 4) {
			GetComponent<Renderer> ().material.color = Color.blue;
		}
		else if (warm > 0 && warm <= 3) {
			GetComponent<Renderer> ().material.color = Color.Lerp(Color.black, Color.blue, warm/3);
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
		if (doSubCount) {
			warmth = Time.time - startTime;
			if (warmth < 12)
			UpdateSplashedColor (warmth);
		}
	}
}

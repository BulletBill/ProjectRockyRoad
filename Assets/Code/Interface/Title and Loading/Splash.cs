using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class Splash : MonoBehaviour {

	SpriteRenderer sr;

	public float FadeInTime;
	float fadeInPerSec;
	public float FullTime;
	public float FadeOutTime;
	float fadeOutPerSec;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();

		if (null == sr) { GameObject.Destroy(gameObject); }
		sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.0f);

		fadeInPerSec = 1.0f / FadeInTime;
		fadeOutPerSec = 1.0f / FadeOutTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (FadeInTime > 0) {
			FadeInTime -= Time.deltaTime;
			Color colorDelta = sr.color;
			colorDelta.a += fadeInPerSec * Time.deltaTime;
			sr.color = colorDelta;
		} else if (FullTime > 0) {
			FullTime -= Time.deltaTime;
		} else if (FadeOutTime > 0) {
			FadeOutTime -= Time.deltaTime;
			Color colorDelta = sr.color;
			colorDelta.a -= fadeInPerSec * Time.deltaTime;
			sr.color = colorDelta;
		} else {
			SceneManager.LoadScene("Prefab Setup");
		}
	}
}

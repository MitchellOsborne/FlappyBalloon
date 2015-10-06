using UnityEngine;
using System.Collections;

public class KillTimer : MonoBehaviour {

	public float LifeTime = 0;
	private float LifeCounter = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		LifeCounter += Time.deltaTime;
		if (LifeCounter > LifeTime) {
			Destroy (gameObject);
		}
	}
}

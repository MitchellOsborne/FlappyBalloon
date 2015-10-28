using UnityEngine;
using System.Collections;

public class ParallaxScript : MonoBehaviour {
	public Vector3 ResetPos; //The position at when the bounces back
	public Vector3 NewPos; //The position the object bounces back to
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (transform.position.x < ResetPos.x) {
			float diff = transform.position.x - ResetPos.x;
			Vector3 diffVec = new Vector3(diff,0,0);
			transform.position = NewPos + diffVec;
		}
	}
}

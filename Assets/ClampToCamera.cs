using UnityEngine;
using System.Collections;

public class ClampToCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Rect bounds = Camera.main.GetComponent<CameraBounds>().bounds;
		transform.position = new Vector2(Mathf.Clamp(transform.position.x, bounds.x, bounds.x + bounds.width),
		                                 Mathf.Clamp (transform.position.y, bounds.y, bounds.y + bounds.height));
	}
}

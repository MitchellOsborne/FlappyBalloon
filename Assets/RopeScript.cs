using UnityEngine;
using System.Collections;

public class RopeScript : MonoBehaviour {
	public LineRenderer lr;
	public GameObject balloon;
	public GameObject man;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lr.SetPosition (0, balloon.transform.position);
		lr.SetPosition (1, man.transform.position);
	}
}

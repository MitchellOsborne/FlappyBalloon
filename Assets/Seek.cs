using UnityEngine;
using System.Collections;

public class Seek : MonoBehaviour {
	public GameObject Target;
	public float MoveSpeed;
	Vector3 Force = Vector3.zero;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		Target = GameObject.FindGameObjectWithTag ("Player");
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Target != null) {
			Vector3 tempVec = rb.position - Target.transform.position;
			tempVec.Normalize ();
			Force += -(tempVec);
		}
		Force.Normalize ();
		rb.AddForce((Force * MoveSpeed)*Time.deltaTime);
		Force = Vector3.zero;
	}
}

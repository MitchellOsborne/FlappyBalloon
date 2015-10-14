using UnityEngine;
using System.Collections;

public class Seek : MonoBehaviour {
	public GameObject Target;
	public float MoveSpeed;
	Vector2 Force = Vector2.zero;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		Target = GameObject.FindGameObjectWithTag ("Player");
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Target != null) {
			Vector2 tempVec = rb.position - new Vector2(Target.transform.position.x, Target.transform.position.y);
			tempVec.Normalize ();
			Force += -(tempVec);
		}
		Force.Normalize ();
		rb.AddForce((Force * MoveSpeed)*Time.deltaTime);
		Force = Vector2.zero;
	}
}

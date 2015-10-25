using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public ForceMode2D forceMode;
    public Rigidbody2D balloonRB;
    public float force = 1000.0f;      // Might make this private
    private bool hasControl = true;


	// Update is called once per frame
	void Update ()
    {
	    if(hasControl)
        {
			Vector2 f = new Vector2(
				Input.GetAxis ("Horizontal") * force * Time.deltaTime, 
				Input.GetAxis ("Vertical") * force * Time.deltaTime);

			balloonRB.AddForce(f, forceMode);

        }
	}

    void SetHasControl(bool newVal)
    {
        this.hasControl = newVal;
    }
}

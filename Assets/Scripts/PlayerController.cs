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
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                balloonRB.AddForce(new Vector2(-force, 0), forceMode);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                balloonRB.AddForce(new Vector2(force, 0), forceMode);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                balloonRB.AddForce(new Vector2(0, force), forceMode);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                balloonRB.AddForce(new Vector2(0, -force), forceMode);
            }

        }
	}

    void SetHasControl(bool newVal)
    {
        this.hasControl = newVal;
    }
}

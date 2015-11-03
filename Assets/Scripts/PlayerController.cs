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
        #if UNITY_STANDALONE
                    Vector2 f = new Vector2(
        				Input.GetAxis ("Horizontal") * force * Time.deltaTime, 
        				Input.GetAxis ("Vertical") * force * Time.deltaTime);
        
        			balloonRB.AddForce(f, forceMode);
        #endif

        #if UNITY_ANDROID || UNITY_IOS
                    Vector2 f = Vector2.zero;
        
                    if(Input.touchCount > 0)
                        f = Input.GetTouch(0).deltaPosition;
        
        			balloonRB.AddForce(f, forceMode);
        #endif

        }
    }

    void SetHasControl(bool newVal)
    {
        this.hasControl = newVal;
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
	public GameManager gm;
	public SpriteRenderer sr;
	private float flashTime = 0.1f;
	private float flashCounter = 0.1f;
	
	public void Update()
	{
		if (flashCounter < flashTime) {
			flashCounter += Time.deltaTime;
			sr.color = Color.red;
		} else {
			sr.color = Color.white;
		}
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        //TODO: make damage more flexible ie. Different enemy types = different damage amounts
        string tag = collider.gameObject.tag;
        if (tag == "Enemy" || tag == "Debris" || tag == "CameraBounds") {
			gm.ScoreMultiplier /= 2;
			flashCounter = 0;
		
		} else if (tag == "ScoreMultiplier") {
			gm.ScoreMultiplier *= 2;
			GameObject.Destroy(collider.gameObject);
		}
    }
}

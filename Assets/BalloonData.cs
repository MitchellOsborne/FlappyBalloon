﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BalloonData : MonoBehaviour {

	public int health = 100;
	public Slider hpSlider;
	public GameManager gm;
	public SpriteRenderer sr;
	public GameObject GameOverScreen;
	private float flashTime = 0.1f;
	private float flashCounter = 0.1f;
	
    void Start()
    {
        hpSlider.value = health;
    }

	public void Update()
	{
		if (IsDead()) {
			GameOverScreen.SetActive(true);
		}

		if (flashCounter < flashTime) {
			flashCounter += Time.deltaTime;
			sr.color = Color.red;
		}else
		{
			sr.color = Color.white;
		}
		if (health < 0) {
			health = 0;
		}
		hpSlider.value = health;

	}
	public void Damage(int amount)
	{
		health -= amount;
	}
	
	public bool IsDead()
	{
		return health <= 0;
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		//TODO: make damage more flexible ie. Different enemy types = different damage amounts
		string tag = collider.gameObject.tag;
		if (tag == "Enemy" || tag == "Debris")
		{
			Damage (collider.gameObject.GetComponent<EnemyData>().damage);
			flashCounter = 0;
		} else if (tag == "ScoreMultiplier") {
			gm.ScoreMultiplier *= 2;
			GameObject.Destroy(collider.gameObject);
		}
	}
}

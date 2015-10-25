using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text ScoreTxt;
	public int Score = 0;
	public int ScoreMultiplier = 1;
	private float fScore = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (ScoreMultiplier < 1) {
			ScoreMultiplier = 1;
		}
		fScore += Time.deltaTime * ScoreMultiplier;
		Score = (int)fScore;
		ScoreTxt.text = Score.ToString();
	}
}

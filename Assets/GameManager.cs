using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text ScoreTxt;
	public Text ScoreMultText;
	public int Score = 0;
	public int ScoreMultiplier = 1;
	private float fScore = 0;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (ScoreMultiplier < 1) {
			ScoreMultiplier = 1;
		}
		ScoreMultText.text = ScoreMultiplier.ToString ();
		fScore += Time.deltaTime * ScoreMultiplier;
		Score = (int)fScore;
		ScoreTxt.text = Score.ToString();
	}

	public void SetTimeScale(float ts)
	{
		Time.timeScale = ts;
	}
}

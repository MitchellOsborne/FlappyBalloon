using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class GameOver : MonoBehaviour {
	public GameManager gm;
	public Text PlayerScore;
	public Text[] Top5;
	private PlayerData pd = new PlayerData();
	private List<int> Scores;
	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		pd.LoadDataFromDefaultPath ();
		pd.RegisterNewScore (gm.Score);
		pd.SaveDataToDefaultPath ();

		Scores = pd.getHighScores ();
		Scores.Sort ();
		PlayerScore.text = gm.Score.ToString ();
		for (int i = 0; i < Scores.Count; ++i) {
			Top5[i].text = Scores[i].ToString ();
		}
	}
	
	public void OnMainMenuSelected()
    {
        Application.LoadLevel("MainMenu");
    }
}

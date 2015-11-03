using UnityEngine;
using SimpleJSON;
using System.Collections.Generic;

// Have an instance of this in the game manager
public class PlayerData
{
    private const int MAX_TOP_SCORES = 5;
    private const int MAX_SCORE_HISTORY = 5;

    private List<int> highScores = new List<int>(MAX_TOP_SCORES); // Highest scores
    private List<int> scoreHistory = new List<int>(MAX_SCORE_HISTORY); // Score from last few games

    public List<int> getHighScores()
    {
        return highScores;
    }

    public List<int> getScoreHistory()
    {
        return scoreHistory;
    }

    /// <summary>
    /// Serializes the current state of this object from filePath
    /// </summary>
    public void SaveDataToDefaultPath()
    {
        string highScoresStr = "";
        string pastScoresStr = "";

        for(int i = 0; i <  highScores.Count; ++i)
        {
            highScoresStr += (highScores[i].ToString() + ":");
        }

        for (int i = 0; i < scoreHistory.Count; ++i)
        {
            pastScoresStr += (scoreHistory[i].ToString() + ":");
        }

        PlayerPrefs.SetString("highScores", highScoresStr);
        PlayerPrefs.SetString("pastScores", pastScoresStr);

        //JSONClass json = new JSONClass();
        //
        //// Saving high scores
        //JSONArray hScores = new JSONArray();
        //for (int i = 0; i < highScores.Count; ++i)
        //{
        //    hScores[i] = highScores[i].ToString();
        //}
        //json.Add("highScores", hScores);
        //
        //// Saving score history
        //JSONArray sHistory = new JSONArray();
        //for (int i = 0; i < scoreHistory.Count; ++i)
        //{
        //    sHistory[i] = scoreHistory[i].ToString();
        //}
        //json.Add("scoreHistory", sHistory);
        //
        //Debug.Log(json.ToString());
        //json.SaveToFile(Application.persistentDataPath + "\\player.dat");
    }

    /// <summary>
    /// Loads serialized player data from filePath
    /// </summary>
    public void LoadDataFromDefaultPath()
    {
        if(PlayerPrefs.GetString("highScores") != "" && PlayerPrefs.GetString("pastScores") != "")
        {
            string[] highScoresStr = PlayerPrefs.GetString("highScores").Split(':');
            string[] pastScoresStr = PlayerPrefs.GetString("pastScores").Split(':');

            for (int i = 0; i < highScoresStr.Length; ++i)
            {
                if(highScoresStr[i] != "")
                    highScores.Add(int.Parse(highScoresStr[i]));
            }

            for (int i = 0; i < pastScoresStr.Length; ++i)
            {
                if (pastScoresStr[i] != "")
                    scoreHistory.Add(int.Parse(pastScoresStr[i]));
            }
        }

        //try
        //{
        //    JSONNode json = JSONNode.LoadFromFile(Application.persistentDataPath + "\\player.dat");
        //
        //    if (json == null)
        //        return false;
        //
        //    for (int i = 0; i < json["highScores"].Count; ++i)
        //    {
        //        highScores.Add(json["highScores"][i].AsInt);
        //    }
        //
        //    for (int i = 0; i < json["scoreHistory"].Count; ++i)
        //    {
        //        scoreHistory.Add(json["scoreHistory"][i].AsInt);
        //    }
        //
        //    Debug.Log(json.ToString());
        //    return true;
        //}
        //catch(System.IO.FileNotFoundException e)
        //{
        //    Debug.Log(e.Message);
        //    return false;
        //}
    }

    /// <summary>
    /// Called when the player eventually loses their game.
    /// Registers the score with the player data structure making sure it's saved.
    /// </summary>
    public void RegisterNewScore(int score)
    {
        UpdateHighScores(score);
        UpdateScoreHistory(score);
    }

    private void UpdateHighScores(int score)
    {
        highScores.Add(score);
        highScores.Sort();

        if(highScores.Count > MAX_TOP_SCORES)
        {
            highScores.RemoveRange(MAX_TOP_SCORES - 1, highScores.Count - MAX_TOP_SCORES);
        }
    }

    private void UpdateScoreHistory(int score)
    {
        scoreHistory.Add(score);

        if (scoreHistory.Count > MAX_SCORE_HISTORY)
        {
            scoreHistory.RemoveRange(MAX_SCORE_HISTORY - 1, scoreHistory.Count - MAX_SCORE_HISTORY);
        }
    }
}

using UnityEngine;
using SimpleJSON;
using System.Collections.Generic;

// Have an instance of this in the game manager
public class PlayerData
{
    private const int MAX_TOP_SCORES = 5;
    private const int MAX_SCORE_HISTORY = 5;

    [SerializeField]
    private string filePath;

    private List<int> highScores = new List<int>(MAX_TOP_SCORES); // Highest scores
    private List<int> scoreHistory = new List<int>(MAX_SCORE_HISTORY); // Score from last few games

    void Awake()
    {
        filePath = Application.dataPath + "player.dat";
    }

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
        JSONClass json = new JSONClass();

        // Saving high scores
        JSONArray hScores = new JSONArray();
        for (int i = 0; i < highScores.Count; ++i)
        {
            hScores[i] = highScores[i].ToString();
        }
        json.Add("highScores", hScores);

        // Saving score history
        JSONArray sHistory = new JSONArray();
        for (int i = 0; i < scoreHistory.Count; ++i)
        {
            sHistory[i] = scoreHistory[i].ToString();
        }
        json.Add("scoreHistory", sHistory);

        Debug.Log(json.ToString());
        json.SaveToFile(filePath);
    }

    /// <summary>
    /// Loads serialized player data from filePath
    /// </summary>
    public bool LoadDataFromDefaultPath()
    {
        JSONNode json = JSONNode.LoadFromFile(filePath);

        if (json == null)
            return false;

        for (int i = 0; i < json["highScores"].Count; ++i)
        {
            highScores.Add(json["highScores"][i].AsInt);
        }

        for (int i = 0; i < json["scoreHistory"].Count; ++i)
        {
            highScores.Add(json["scoreHistory"][i].AsInt);
        }

        Debug.Log(json.ToString());
        return true;
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

        for (int i = highScores.Count; i > MAX_TOP_SCORES; --i)
        {
            highScores.RemoveAt(i);
        }
    }

    private void UpdateScoreHistory(int score)
    {
        scoreHistory.Add(score);

        for (int i = scoreHistory.Count; i > MAX_SCORE_HISTORY; --i)
        {
            scoreHistory.RemoveAt(i);
        }
    }
}

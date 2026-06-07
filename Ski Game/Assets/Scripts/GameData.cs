using UnityEngine;
using System.Collections.Generic;

public class GameData : MonoBehaviour
{ 
    private static GameData instance;

    public List<float> bestTimes = new List<float>();

    public static GameData Instance
    {
        get { return instance; }
    }

    public string leaderboardKey = "LVL1-"; 

    private void Awake() 
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadLeaderboard();
    }

    void LoadLeaderboard()
    {
        bestTimes.Clear();

        for (int i = 0; i < 5; i++)
        {
            float time = PlayerPrefs.GetFloat(leaderboardKey + i, 999.99f);
            bestTimes.Add(time);
        }

        bestTimes.Sort();
    }

    void SaveLeaderboard()
    {
        bestTimes.Sort();

        for (int i = 0; i < 5; i++)
        { 
            if (i < bestTimes.Count)
            {
                PlayerPrefs.SetFloat(leaderboardKey + i, bestTimes[i]);
            }
        }

        PlayerPrefs.Save();
    }

    public void AddTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();

        if (bestTimes.Count > 5)
        {
            bestTimes.RemoveRange(5, bestTimes.Count - 5);
        }

        SaveLeaderboard();
    }
}

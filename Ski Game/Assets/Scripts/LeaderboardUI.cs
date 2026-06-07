using UnityEngine;
using TMPro;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField] private GameObject leaderboardPanel;
    [SerializeField] private TMP_Text[] leaderboardTexts;

    private void OnEnable()
    {
        FinishGate.EndRace += ShowLeaderboard;
    }

    private void OnDisable()
    {
        FinishGate.EndRace -= ShowLeaderboard;
    }

    private void Start()
    {
        leaderboardPanel.SetActive(false);
    }

    private void ShowLeaderboard()
    {
        leaderboardPanel.SetActive(true);

        for (int i = 0; i < leaderboardTexts.Length; i++)
        {
            if (GameData.Instance != null && i < GameData.Instance.bestTimes.Count)
            {
                float time = GameData.Instance.bestTimes[i];

                if (time >= 999f)
                {
                    leaderboardTexts[i].text = $"{i + 1}. --:--";
                }
                else
                {
                    leaderboardTexts[i].text = $"{i + 1}. {FormatTime(time)}";
                }
            }
            else
            {
                leaderboardTexts[i].text = $"{i + 1}. --:--";
            }
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int hundredths = Mathf.FloorToInt((time * 100f) % 100f);

        return $"{minutes:00}:{seconds:00}.{hundredths:00}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

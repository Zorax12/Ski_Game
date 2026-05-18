using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
 private DateTime raceStart;
 private TimeSpan raceTime;
 private TimeSpan penaltyTime;
 private bool racing;
 
 public delegate void TimerEvent();

 [SerializeField] private int penaltyValue = 3;
 [SerializeField] private TMP_Text Score;
 [SerializeField] private TMP_Text BestTimeText;
 [SerializeField] private string bestTimekey = "LVL1BestTime";
 [SerializeField] private TimeSpan bestTime;
 private void OnEnable()
 {
  StartGate.StartRace += OnRaceStart;
  FinishGate.EndRace += OnRaceEnd;
  SkiFlag.RacePenalty += AddRacePenalty;
 }

 private void OnDisable()
 {
  StartGate.StartRace -= OnRaceStart;
  FinishGate.EndRace -= OnRaceEnd;
  SkiFlag.RacePenalty -= AddRacePenalty;
 }
 

 void Start()
 {
  if (PlayerPrefs.HasKey(bestTimekey))
  {
   int bestTimeTicks = PlayerPrefs.GetInt(bestTimekey);
   bestTime = new TimeSpan(bestTimeTicks);
   BestTimeText.text = "BEST TIME: " + bestTime.ToString(@"ss\:ff");
  }
  else
  {
   bestTime = new TimeSpan(int.MaxValue);
   BestTimeText.text = "BEST TIME: --:--";
  }
  //PlayerPrefs.DeleteAll();
 }

 void OnRaceStart()
 {
  racing = true;
  raceStart = DateTime.Now;
 }

 void OnRaceEnd()
 {
  racing = false;
  float raceTimeF = (float)raceTime.TotalMilliseconds / 1000f;
  GameData.Instance.AddTime(raceTimeF);
  if (raceTime < bestTime)
  {
   bestTime = raceTime;
   BestTimeText.text = "BEST TIME: " + bestTime.ToString(@"ss\:ff");
   BestTimeText.color = Color.gold;
   PlayerPrefs.SetInt(bestTimekey, (int)bestTime.Ticks);
   PlayerPrefs.Save(); 
  }
  
 }
 
 void AddRacePenalty()
 {
  penaltyTime += new TimeSpan(0,0, penaltyValue);
 }

 private void Update()
 {
  if (racing)
  {
   raceTime =  DateTime.Now - raceStart + penaltyTime;
   Score.text = "TIME: " + raceTime.ToString(@"ss\:ff");;
  }
  
 }
 
}

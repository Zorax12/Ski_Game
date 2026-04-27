using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
 private DateTime raceStart;
 private TimeSpan raceTime;
 private bool racing;
 
 public delegate void TimerEvent();

 private void OnEnable()
 {
  StartGate.StartRace += OnRaceStart;
  FinishGate.EndRace += OnRaceEnd;
 }

 void OnRaceStart()
 {
  racing = true;
  raceStart = DateTime.Now;
  Debug.Log("race start");
 }

 void OnRaceEnd()
 {
  racing = false;
  Debug.Log("race end");
 }

 private void Update()
 {
  if (racing)
  {
   raceTime =  DateTime.Now - raceStart;
   Debug.Log("race time: " + raceTime);
  }
 }
}

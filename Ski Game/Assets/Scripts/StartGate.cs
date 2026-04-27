using UnityEngine;

public class StartGate : MonoBehaviour
{
  public static GameManager.TimerEvent StartRace;

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag.Equals("Player"))
    {
      StartRace.Invoke();;
    }
  }
}

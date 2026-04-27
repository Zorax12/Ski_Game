using UnityEngine;

public class FinishGate : MonoBehaviour
{
    public static GameManager.TimerEvent EndRace;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
           EndRace.Invoke();;
        }
    }
}

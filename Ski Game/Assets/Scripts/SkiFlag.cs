using UnityEngine;

public class SkiFlag : MonoBehaviour
{
    private bool flagPassed = false;
    private enum Direction { Left, Right };
    [SerializeField] private Direction direction;
    [SerializeField] private Material goodMat, badMat;

    public static event GameManager.TimerEvent RacePenalty;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControl.player != null && PlayerControl.player.position.z < transform.position.z && flagPassed == false)
        {
            Direction passingDirection = Direction.Right;
            
            if(PlayerControl.player.position.x < transform.position.x)
                passingDirection = Direction.Left;
            
            
            flagPassed = true;
            MeshRenderer mr = GetComponent<MeshRenderer>();
            if (passingDirection == direction)
            {
                mr.material = goodMat;
            }
            else
            {
                mr.material = badMat;
                RacePenalty.Invoke();
            }
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour {

    public Transform partToRotate;

    private Transform target;
    private int wpIndex = 0;

    private Player player;

    public GameManager gameManager;
    
	void Start ()
    {
        player = GetComponent<Player>();
        target = Waypoint.wp[0];
	}

	void Update ()
    {
        if (!gameManager.GameIsOver)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * player.speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            {
                getNextWaypoint();
            }

            TurnToTarget();

            player.speed = player.startSpeed;
        }
	}

    void getNextWaypoint()
    {
        if(wpIndex >= Waypoint.wp.Length - 1)
        {
            EndPath();
            return;
        }

        wpIndex++;
        target = Waypoint.wp[wpIndex];
    }

    void EndPath()
    {
        // Game end code
        gameManager.GameEnd(transform);
    }

    void TurnToTarget()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

        // Gentle turn to waypoint
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * player.turn).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}

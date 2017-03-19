using UnityEngine;

/// <summary>
/// Needs Player component, gets the waypoints that was put into an Waypoint array.
/// Gets the next waypoint in the array, turns the player to that target then moves to it.
/// Once the end is hit, calls game over and other scripts then do their own bits of code to stop the game.
/// </summary>

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour {

    public Transform partToRotate;

    private Player player;

    public GameManager gameManager;
    
    [Header("Waypoints")]
    private Transform waypointTarget;
    private int wpIndex = 0;

    void Start ()
    {
        player = GetComponent<Player>();
        waypointTarget = Waypoint.wp[0];
	}

	void Update ()
    {
        if (!gameManager.GameIsOver)
        {
            Vector3 dir = waypointTarget.position - transform.position;
            transform.Translate(dir.normalized * player.speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, waypointTarget.position) <= 0.4f)
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
        waypointTarget = Waypoint.wp[wpIndex];
    }

    void EndPath()
    {
        // Game end code
        gameManager.GameEnd(transform);
    }

    void TurnToTarget()
    {
        Vector3 dir = (waypointTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        // Gentle turn to waypoint
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation,  player.turn * Time.deltaTime).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}

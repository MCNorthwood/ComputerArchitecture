using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour {

    public Transform partToRotate;
    public float turnSpeed = 10f;

    private Transform target;
    private int wpIndex = 0;

    private Player player;
    
	void Start ()
    {
        player = GetComponent<Player>();
        target = Waypoint.wp[0];
	}

	void Update ()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * player.speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            getNextWaypoint();
        }

        TurnToTarget();

        player.speed = player.startSpeed;
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
        GameManager.GameIsOver = true;
        Time.timeScale = 0f;
    }

    void TurnToTarget()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

        //Vector3 dir = target.position - transform.position;
        //Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        //partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        //Vector3 dir = target.position - transform.position;
        //float step = player.speed * Time.deltaTime;
        //Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, step, 0.0F);
        //transform.rotation = Quaternion.LookRotation(newDir);

        //transform.LookAt(target);
    }
}

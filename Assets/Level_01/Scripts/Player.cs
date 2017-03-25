using UnityEngine;

/// <summary>
/// Holds the speed the player is moving and how quick they should turn
/// </summary>

public class Player : MonoBehaviour {

    public float startSpeed = 10f;
    public float turnSpeed = 10f;

    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float turn;

    void Start ()
    {
        speed = startSpeed;
        turn = turnSpeed;
	}
}

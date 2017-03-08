using UnityEngine;

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

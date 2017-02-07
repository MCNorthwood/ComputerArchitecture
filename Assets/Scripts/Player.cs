using UnityEngine;

public class Player : MonoBehaviour {

    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

	void Start ()
    {
        speed = startSpeed;
	}
}

using UnityEngine;

/// <summary>
/// Enemy bugs move between two locations on the z axis
/// </summary>

public class EnemyMovement : MonoBehaviour {

    public float speed = 5f;
    public float moveAxis = 10f;

    public Transform firstPosition;

    private Vector3 firstPos;
    private Vector3 secondPos;

    private bool hitSecond;

	// Use this for initialization
	void Awake () {
        firstPos = firstPosition.position;
        secondPos = new Vector3(firstPosition.position.x, firstPosition.position.y, firstPosition.position.z + moveAxis);
        hitSecond = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.activeSelf)
        {
            if (transform.position.z < secondPos.z && !hitSecond)
            {
                transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z + (speed * Time.deltaTime));
                if (transform.position.z >= secondPos.z)
                {
                    hitSecond = true;
                }
            }
            else if (transform.position.z > firstPos.z && hitSecond)
            {
                transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z - (speed * Time.deltaTime));

                if (transform.position.z <= firstPos.z)
                {
                    hitSecond = false;
                }
            }
        }
	}
}

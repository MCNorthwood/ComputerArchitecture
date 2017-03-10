using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed = 5f;

    public Transform firstPosition;

    private Vector3 firstPos;
    private Vector3 secondPos;

    private bool hitSecond;

	// Use this for initialization
	void Awake () {
        firstPos = firstPosition.position;
        secondPos = new Vector3(firstPosition.position.x + 10f, firstPosition.position.y, firstPosition.position.z);
        hitSecond = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.activeSelf)
        {
            if (transform.position.x < secondPos.x && !hitSecond)
            {
                transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
                if (transform.position.x >= secondPos.x)
                {
                    hitSecond = true;
                }
            }
            else if (transform.position.x > firstPos.x && hitSecond)
            {
                transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, transform.position.z);

                if (transform.position.x <= firstPos.x)
                {
                    hitSecond = false;
                }
            }
        }
	}
}

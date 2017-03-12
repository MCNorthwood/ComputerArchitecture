using UnityEngine;

public class RotateDisk : MonoBehaviour {

    public float angle = 10f;

	// Update is called once per frame
	void Update () {
        transform.Rotate(0, angle * Time.deltaTime, 0);
	}
}

using UnityEngine;

/// <summary>
/// Rotates the object continously in relation to the speed of the game
/// </summary>

public class RotateDisk : MonoBehaviour {

    public float angle = 10f;

	// Update is called once per frame
	void Update () {
        transform.Rotate(0, angle * Time.deltaTime, 0);
	}
}

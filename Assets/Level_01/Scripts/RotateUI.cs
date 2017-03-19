using UnityEngine;

/// <summary>
/// Simply rotates a UI elemnts to look at the camera,
/// so the player can see at all times directly what is said on the UI
/// </summary>

public class RotateUI : MonoBehaviour {

    public Camera lookAt;

	// Update is called once per frame
	void Update () {
        Vector3 v = lookAt.transform.position - transform.position;

        v.x = v.z = 0.0f;
        transform.LookAt(lookAt.transform.position - v);
        transform.Rotate(0, 180, 0);
    }
}
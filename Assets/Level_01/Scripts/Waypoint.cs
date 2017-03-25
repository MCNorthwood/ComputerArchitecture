using UnityEngine;

/// <summary>
/// Gather all the child objects that are empty objects into a Transform Array,
/// getting the Vector3 location of each object so the player can follow the route.
/// </summary>

public class Waypoint : MonoBehaviour {

    public static Transform[] wp;

    void Awake()
    {
        wp = new Transform[transform.childCount];
        for (int i = 0; i < wp.Length; i++)
        {
            wp[i] = transform.GetChild(i);
        }
    }
}

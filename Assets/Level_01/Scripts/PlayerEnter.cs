using UnityEngine;

/// <summary>
/// Similar to Trigger script but does different things
/// </summary>

public class PlayerEnter : MonoBehaviour {

    private bool triggered = false;
    private Collider collided;

    void Start()
    {
        collided = GetComponent<Collider>();
    }

    private void OnTriggerEnter()
    {
        if (!triggered)
        {
            transform.GetChild(0).transform.gameObject.SetActive(true);
            collided.enabled = false;
            triggered = true;
        }
    }
}

using UnityEngine;

/// <summary>
/// When the player enters the collision area which is a trigger by getting all the child objects
/// with a certain tag attached to it and hide it. It is done with the enemy object when entering and
/// particles when leaving its area.
/// </summary>

public class Trigger : MonoBehaviour {

    public string objectTag = "Default";
    private Collider collided;

    void Start()
    {
        collided = GetComponent<Collider>();
    } 

    private void OnTriggerEnter(Collider other)
    {
        if (objectTag == "EnemyPrefab")
        {
            Triggered();

            GameManager.SpinDisks = true;

            collided.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (objectTag == "Particles")
        {
            Triggered();

            collided.enabled = false;
        }
    }

    void Triggered()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(objectTag);

        foreach (GameObject obj in objects)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }
}

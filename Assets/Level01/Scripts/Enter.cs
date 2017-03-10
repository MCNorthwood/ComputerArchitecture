using UnityEngine;

public class Enter : MonoBehaviour {

    public string enemyTag = "EnemyPrefab";
    private Collider collided;

    void Start()
    {
        collided = GetComponent<Collider>();
    }

    private void OnTriggerEnter()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach(GameObject enemy in enemies)
        {
            enemy.SetActive(!enemy.activeSelf);
        }

        collided.enabled = false;
    }
}

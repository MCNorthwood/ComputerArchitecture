using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour {

    public GameObject deathEffect;

    public Transform enemyPos;

    public float gazeTime = 2f;
    private float timer;

    private bool gazedAt;

    private bool isDead = false;
	
	// Update is called once per frame
	void Update () {
        if (gazedAt)
        {
            timer += Time.deltaTime;

            if(timer >= gazeTime && !isDead)
            {
                timer = 0f;
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
            }
        }
	}

    public void PointerEnter()
    {
        gazedAt = true;
    }

    public void PointerExit()
    {
        gazedAt = false;
    }

    public void PointerDown()
    {
        Die();
    }

    void Die()
    {
        isDead = true;

        // Play particle effect to show death/neutralised
        GameObject effect = (GameObject)Instantiate(deathEffect, enemyPos.position, Quaternion.identity);
        Destroy(effect, 5f);

        // Count amount of enemies killed
        GameStats.EnemiesKilled++;

        Destroy(gameObject);

        gazedAt = false;
    }
}

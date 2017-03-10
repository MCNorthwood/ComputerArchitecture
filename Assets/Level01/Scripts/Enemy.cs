using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour {

    public GameManager gameManager;
    public GameObject deathEffect;
    public MathsUI maths;

    public Transform enemyPos;

    public float gazeTime = 2f;
    private float timer;
    private bool gazedAt;

    [HideInInspector]
    public bool isDead;
    
    private Collider collided;

    void Start()
    {
        collided = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update () {
        if (gazedAt && !gameManager.GameIsOver)
        {
            timer += Time.deltaTime;

            if(timer >= gazeTime && !isDead)
            {
                timer = 0f;
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
            }
        }
        else if (gameManager.GameIsOver)
        {
            collided.enabled = false;
        }
        else
        {
            collided.enabled = true;
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
        DeathEffect();
        collided.enabled = false;
        Die();
        StartCoroutine(maths.changeUI());
    }

    void Die()
    {
        // Count amount of enemies killed
        GameStats.EnemiesKilled++;

        Destroy(transform.GetChild(0).gameObject);
        Destroy(transform.parent.gameObject, 4f);
    }

    void DeathEffect()
    {
        isDead = true;

        // Play particle effect to show death/neutralised
        GameObject effect = (GameObject)Instantiate(deathEffect, enemyPos.position, Quaternion.identity);
        Destroy(effect, 5f);
    }
}

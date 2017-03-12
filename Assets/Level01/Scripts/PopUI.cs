using UnityEngine;
using UnityEngine.EventSystems;

public class PopUI : MonoBehaviour {

    public bool isRam = false;

    public float gazeTime = 2f;
    private bool gazedAt;
    private float timer;

    public GameObject ui;
    public GameStats gameStats;

    private Collider collided;
    public GameObject particle;

    void Start()
    {
        collided = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gazedAt)
        {
            timer += Time.deltaTime;

            if (timer >= gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                timer = 0f;
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
        if (!gameStats.cpuHit && !isRam)
        {
            Pop();
            gameStats.cpuHit = true;
        }
        else if (gameStats.cpuHit && isRam)
        {
            Pop();
        }
    }

    void Pop()
    {
        ui.SetActive(!ui.activeSelf);

        if (particle != null)
        {
            particle.SetActive(true);
        }

        collided.enabled = false;
    }
}

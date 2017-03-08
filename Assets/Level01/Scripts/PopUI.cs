using UnityEngine;
using UnityEngine.EventSystems;

public class PopUI : MonoBehaviour {
    
    public float gazeTime = 2f;
    private bool gazedAt;
    private float timer;

    public GameObject ui;
    public GameStats gameStats;

    private Collider collided;

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
        ui.SetActive(!ui.activeSelf);
        collided.enabled = false;
    }
}

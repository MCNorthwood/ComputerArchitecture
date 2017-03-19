using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Script is used for two objects rather than double the code and put it into two different scripts
/// Boolean checks whether the object is the Ram object and check if the cpu has already been hit
/// </summary>

public class PopUI : MonoBehaviour {

    public bool isRam = false;

    public float gazeTime = 2f;
    private bool gazedAt;
    private float timer;

    public GameObject ui;
    private Image[] image;
    public GameStats gameStats;

    private Collider collided;
    public GameObject particle;

    void Start()
    {
        collided = GetComponent<Collider>();

        image = GetComponentsInChildren<Image>();
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
            ChangeColour();
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

    void ChangeColour()
    {
        foreach(Image img in image)
        {
            img.color = Color.red;
        }
    }
}

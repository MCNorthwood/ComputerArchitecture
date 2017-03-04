using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlowGame : MonoBehaviour {

    public float gazeTime = 1f;
    private float timer;

    private bool gazedAt;

    [HideInInspector]
    public bool pause;

    public Text pauseText;
    public float slow = .2f;

    void Start()
    {
        pause = false;
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
        Toggle();
        gazedAt = false;
    }

    public void Toggle()
    {
        pause = !pause;

        if (pause)
        {
            Time.timeScale = slow;
            pauseText.text = "Look at to \nturn Normal";
        }
        else
        {
            Time.timeScale = 1f;
            pauseText.text = "Look at to \nSlow";
        }
    }
}

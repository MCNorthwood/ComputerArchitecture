using UnityEngine;
using UnityEngine.EventSystems;

public class PopUI : MonoBehaviour {

    public float gazeTime = 2f;
    private float timer;

    private bool gazedAt;

    public GameObject ui;
    public SlowGame slowGame;
    public GameStats gameStats;

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

        if (!gameStats.poppedUI)
        {
            slowGame.Toggle();
            gameStats.poppedUI = true;
        }
    }
}

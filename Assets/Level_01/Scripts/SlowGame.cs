using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Changes the speed the player is going, originally would slow the timescale 
/// of the game but realised it probably caused more problems with it being VR.
/// </summary>

public class SlowGame : MonoBehaviour {

    public float gazeTime = 1f;
    private float timer;
    private bool gazedAt;
    
    private bool pause;
    private Collider collided;

    public Text pauseText;
    public Player player;
    public GameManager gm;

    void Start()
    {
        pause = false;
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
                gazedAt = false;
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
        if (gm.GameIsOver)
        {
            collided.enabled = false;
        }

        pause = !pause;

        if (pause)
        {
            player.startSpeed = 20f;
            pauseText.text = "Double Speed";
        }
        else
        {
            player.startSpeed = 10f;
            pauseText.text = "Normal Speed";
        }
    }
}

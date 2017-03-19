using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This is the code for the main menu and how most of the VR Code works
/// When the Pointer enters the collision box it changes the private boolean to true
/// Then in the Update functions checks how long this is true for.
/// And then force the down (Button) as this cardboard app has no buttons used.
/// </summary>

public class MainStartUI : MonoBehaviour {

    public string levelToLoad = "Level_01";
    public SceneFader sceneFade;

    public float gazeTime = 2f;
    private float timer;
    private bool gazedAt;
    
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

    public void StartPointerDown()
    {
        sceneFade.FadeTo(levelToLoad);
    }

    public void ExitPointerDown()
    {
        Application.Quit();
    }
}

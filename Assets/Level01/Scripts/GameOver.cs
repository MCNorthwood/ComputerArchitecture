using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public string menuSceneName = "MainMenu";
    public SceneFader sceneFade;

    public float gazeTime = 2f;
    private float timer;

    private bool gazedAt;

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

    public void Restart()
    {
        sceneFade.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFade.FadeTo(menuSceneName);
    }
}

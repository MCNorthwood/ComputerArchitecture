using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainStartUI : MonoBehaviour {

    public string levelToLoad = "Level_01";

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

    public void StartPointerDown()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void ExitPointerDown()
    {
        Application.Quit();
    }
}

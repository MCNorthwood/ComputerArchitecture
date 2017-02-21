using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver;

    public GameObject completeLevelUI;

	void Start ()
    {
        GameIsOver = false;	
	}
	
	void Update ()
    {
        if (GameIsOver)
        {
            return;
        }
	}

    public void GameEnd()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}

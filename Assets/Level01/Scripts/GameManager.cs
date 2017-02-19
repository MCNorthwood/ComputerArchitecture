using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver;

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

    void GameEnd()
    {

    }
}

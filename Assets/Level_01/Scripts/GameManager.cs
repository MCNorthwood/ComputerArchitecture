using UnityEngine;

/// <summary>
/// Holds whether the game is over or not and if it is, grabs the last waypoint and the player
/// and forces it in place rather than trying to move onto the next non existant waypoint.
/// </summary>

public class GameManager : MonoBehaviour {

    [HideInInspector]
    public bool GameIsOver;

    public GameObject completeLevelUI;

    public Transform lastWaypoint;

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

    public void GameEnd(Transform player)
    {
        if(player.position.x == lastWaypoint.position.x &&
           player.position.z == lastWaypoint.position.z &&
           player.position.y == lastWaypoint.position.y)
        {
            player.position = lastWaypoint.position;
            player.rotation = lastWaypoint.rotation;
        }

        GameIsOver = true;
        completeLevelUI.SetActive(true);
        GetComponent<GameStats>().CheckForHighScore();
    }
}

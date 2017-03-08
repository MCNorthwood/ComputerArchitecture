using UnityEngine;

public class GameManager : MonoBehaviour {

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
        GameIsOver = true;
        completeLevelUI.SetActive(true);

        if(player.position.x == lastWaypoint.position.x &&
           player.position.z == lastWaypoint.position.z &&
           player.position.y == lastWaypoint.position.y)
        {
            player.position = lastWaypoint.position;
            player.rotation = lastWaypoint.rotation;
        }
    }
}

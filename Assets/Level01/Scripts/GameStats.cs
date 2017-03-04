using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour {

    public static int EnemiesKilled;

    public bool poppedUI;
	
	void Start ()
    {
        EnemiesKilled = 0;
        poppedUI = false;
	}
}
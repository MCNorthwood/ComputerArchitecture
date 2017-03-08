using UnityEngine;
using UnityEngine.UI;

public class KilledUI : MonoBehaviour {

    public Text killedText;
	
	// Update is called once per frame
	void Update () {
        killedText.text = GameStats.EnemiesKilled.ToString();
	}
}

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Every time an enemy is killed, will change the text of the Canvas attached to card by the value
/// </summary>

public class KilledUI : MonoBehaviour {

    public Text killedText;
	
	// Update is called once per frame
	void Update () {
        killedText.text = GameStats.EnemiesKilled.ToString();
	}
}

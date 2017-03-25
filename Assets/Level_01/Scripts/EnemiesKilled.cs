using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Animate the text at the end to go up to the amount of enemies that was killed
/// </summary>

public class EnemiesKilled : MonoBehaviour {

    public Text killedText;

    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        killedText.text = "0 / 45";
        int killed = 0;

        yield return new WaitForSeconds(.5f);

        while (killed < GameStats.EnemiesKilled)
        {
            killed++;
            killedText.text = killed.ToString() + " / 45";

            yield return new WaitForSeconds(.1f);
        }
    }
}

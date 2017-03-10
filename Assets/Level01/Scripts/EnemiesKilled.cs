using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesKilled : MonoBehaviour {

    public Text killedText;

    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        killedText.text = "0";
        int killed = 0;

        yield return new WaitForSeconds(.7f);

        while (killed < GameStats.EnemiesKilled)
        {
            killed++;
            killedText.text = killed.ToString() + " / 45";

            yield return new WaitForSeconds(.1f);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MathsUI : MonoBehaviour {
    
    public Text displayText;
    public Image panel;

    private string maths;
    private string[] correct = { "1 + 1 = 2", "2 / 2 = 1", "3 - 3 = 0", "4 x 4 = 16" };
    private string[] incorrect = { "1 + 1 = 0", "2 / 2 = 2", "3 - 3 = -3", "4 x 4 = 44" };

    private const float secondsWaited = 5f;

    // Use this for initialization
    void Start () {
        displayText.text = incorrect[Random.Range(0, incorrect.Length)];
        maths = displayText.text;
	}
	
	public IEnumerator changeUI()
    {
        if (maths.Contains("1"))
        {
            displayText.text = correct[0];
            panel.color = Color.green;
            yield return new WaitForSeconds(secondsWaited);
            gameObject.SetActive(!gameObject.activeSelf);
        }
        else if (maths.Contains("2"))
        {
            displayText.text = correct[1];
            panel.color = Color.green;
            yield return new WaitForSeconds(secondsWaited);
            gameObject.SetActive(!gameObject.activeSelf);
        }
        else if (maths.Contains("3"))
        {
            displayText.text = correct[2];
            panel.color = Color.green;
            yield return new WaitForSeconds(secondsWaited);
            gameObject.SetActive(!gameObject.activeSelf);
        }
        else if (maths.Contains("4"))
        {
            displayText.text = correct[3];
            panel.color = Color.green;
            yield return new WaitForSeconds(secondsWaited);
            gameObject.SetActive(!gameObject.activeSelf);
        }
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGBColour : MonoBehaviour {

    private Light lt;
    public bool blue;
    public bool red;
    public bool green;

    // Use this for initialization
    void Start () {
        lt = GetComponent<Light>();
	}

    void Update()
    {
        float t = Mathf.PingPong(Time.time, 1f) / 1f;
        
        if (blue)
        {
            lt.color = Color.Lerp(Color.blue, Color.green, t);
        }
        else if (red)
        {
            lt.color = Color.Lerp(Color.red, Color.blue, t);
        }
        else if (green)
        {
            lt.color = Color.Lerp(Color.green, Color.red, t);
        }
    }
}

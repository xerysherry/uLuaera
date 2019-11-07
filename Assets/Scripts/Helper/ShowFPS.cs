using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFPS : MonoBehaviour
{
    void Update ()
    {
        fps_count += 1;
        fps_time += Time.unscaledDeltaTime;
        if(fps_time > 1.0f)
        {
            fps = (Mathf.Floor((fps_count / fps_time) * 10) / 10).ToString();
            fps_count = 0;
            fps_time = 0;
        }
	}

    private void OnGUI()
    {
        var color = GUI.color;
        GUI.color = Color.red;
        GUI.Label(new Rect(1, 1, 100, 20), fps);
        GUI.color = Color.green;
        GUI.Label(new Rect(0, 0, 100, 20), fps);
        GUI.color = color;
    }

    float fps_time;
    int fps_count;
    string fps;
}
